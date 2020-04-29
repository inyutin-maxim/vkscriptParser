using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using VkScript.Parser.Exceptions;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Lexer
{
	/// <inheritdoc />
	[UsedImplicitly]
	public partial class VkScriptLexer : IVkScriptLexer
	{
		/// <summary>
		/// Исходный код в виде одной строки.
		/// </summary>
		private string _source;

		/// <inheritdoc />
		public List<VkScriptLexeme> Parse(string sourceCode)
		{
			_source = sourceCode;

			while (InBounds())
			{
				if (_newLine)
				{
					ProcessIndent();
					_newLine = false;
				}

				if (ProcessNewLine())
				{
					continue;
				}

				if (IsComment())
				{
					var startCommentOffset = new LexemeLocation
					{
						Line = _line,
						Offset = _offset
					};

					while (InBounds() && !IsEndOfLine())
					{
						Skip();
					}

					var commentText = _source.Substring(startCommentOffset.Offset, _position - startCommentOffset.Offset).Trim();

					Lexemes.Add(new VkScriptLexeme(VkScriptLexemeType.Comment,
						startCommentOffset,
						GetPosition(),
						commentText));

					ProcessNewLine();

					continue;
				}

				if (IsStringBegin())
				{
					ProcessStringLiteral();

					if (!InBounds())
					{
						break;
					}
				} else
				{
					var lex = ProcessStaticLexeme() ?? ProcessRegexLexeme();

					if (lex == null)
					{
						Error(LexerMessages.UnknownLexeme);
					}

					Lexemes.Add(lex);
				}

				SkipSpaces();
			}

			AddLexeme(VkScriptLexemeType.Eof, GetPosition());
			FilterNewlines();

			return Lexemes;
		}

		/// <summary>
		/// Проверка начала строкового литерала
		/// </summary>
		/// <returns></returns>
		private bool IsStringBegin()
		{
			return GetCurrentChar() == '"' || GetCurrentChar() == '\'';
		}

	#region Fields

		/// <summary>
		/// Сгенерированный список лексем.
		/// </summary>
		private List<VkScriptLexeme> Lexemes { get; set; } = new List<VkScriptLexeme>();

		/// <summary>
		/// Текущая позиция во всей исходной строке.
		/// </summary>
		private int _position;

		/// <summary>
		/// Текущая строка в источнике.
		/// </summary>
		private int _line = 1;

		/// <summary>
		/// Горизонтальное смещение в текущей строке.
		/// </summary>
		private int _offset = 1;

		/// <summary>
		/// Флаг, указывающий, что линия только что началась.
		/// </summary>
		private bool _newLine = true;

	#endregion

	#region Private methods

		/// <summary>
		/// Обнаруживает изменения отступа.
		/// </summary>
		private void ProcessIndent()
		{
			while (GetCurrentChar() == ' ' || GetCurrentChar() == '\t')
			{
				Skip();
			}
		}

		/// <summary>
		/// Перемещает курсор вперед к первому не пробельному символу.
		/// </summary>
		private void SkipSpaces()
		{
			while (InBounds() && _source[_position] == ' ')
			{
				Skip();
			}
		}

		/// <summary>
		/// Разбирает строку из исходного кода.
		/// </summary>
		private void ProcessStringLiteral()
		{
			var start = GetPosition();

			Skip();

			var startPosition = GetPosition();
			var sb = new StringBuilder();
			var isEscaped = false;

			while (InBounds())
			{
				var currentChar = GetCurrentChar();

				if (!isEscaped && currentChar == '\\')
				{
					isEscaped = true;

					continue;
				}

				if (isEscaped)
				{
					var nextChar = GetNextChar();

					if (nextChar.HasValue)
					{
						sb.Append(EscapeChar(nextChar.Value));
						Skip(2);
					}

					isEscaped = false;

					continue;
				}

				switch (currentChar)
				{
					case '"':
						Skip();
						Lexemes.Add(new VkScriptLexeme(VkScriptLexemeType.String, startPosition, GetPosition(), sb.ToString()));

						return;
					case '\'':
						Skip();
						Lexemes.Add(new VkScriptLexeme(VkScriptLexemeType.String, startPosition, GetPosition(), sb.ToString()));

						return;
					case '\n':
						_offset = 1;
						_line++;

						break;
				}

				sb.Append(currentChar);
				Skip();
			}

			var end = GetPosition();

			throw new VkScriptCompilerException(LexerMessages.UnclosedString).BindToLocation(start, end);
		}

		/// <summary>
		/// Попытки найти ключевое слово или оператор в текущей позиции в файле.
		/// </summary>
		private VkScriptLexeme ProcessStaticLexeme()
		{
			return ProcessLexemeList(Keywords, ch => ch != '_' && !char.IsLetterOrDigit(ch))
					?? ProcessLexemeList(Operators);
		}

		/// <summary>
		/// Попытки найти любую из данных лексем в текущей позиции в строке.
		/// </summary>
		private VkScriptLexeme ProcessLexemeList(IEnumerable<VkScriptStaticLexemeDefinition> lexemes, Func<char, bool> nextChecker = null)
		{
			foreach (var currentLexeme in lexemes)
			{
				var representation = currentLexeme.Representation;
				var length = representation.Length;

				if (_position + length > _source.Length || _source.Substring(_position, length) != representation)
				{
					continue;
				}

				if (_position + length < _source.Length)
				{
					var nextChar = _source[_position + length];

					if (nextChecker != null && !nextChecker(nextChar))
					{
						continue;
					}
				}

				var start = GetPosition();
				Skip(length);
				var end = GetPosition();

				return new VkScriptLexeme(currentLexeme.Type, start, end);
			}

			return null;
		}

		/// <summary>
		/// Попытки найти любую из заданных лексем, определенных в регулярном выражении, в текущей позиции в строке.
		/// </summary>
		private VkScriptLexeme ProcessRegexLexeme()
		{
			foreach (var currentLexeme in RegexLexemes)
			{
				var match = currentLexeme.Regex.Match(_source, _position);

				if (!match.Success)
				{
					continue;
				}

				var start = GetPosition();
				Skip(match.Length);
				var end = GetPosition();

				return new VkScriptLexeme(currentLexeme.Type, start, end, match.Value);
			}

			return null;
		}

		/// <summary>
		/// Проверяет, содержит ли текущая позиция символ новой строки.
		/// </summary>
		private bool ProcessNewLine()
		{
			if (!InBounds())
			{
				return false;
			}

			if (!IsEndOfLine())
			{
				return false;
			}

			Skip(2);
			AddLexeme(VkScriptLexemeType.NewLine, GetPosition());

			_offset = 1;
			_line++;
			_newLine = true;

			return true;
		}

		/// <summary>
		/// Проверка на окончание строки
		/// </summary>
		/// <returns></returns>
		private bool IsEndOfLine()
		{
			return GetCurrentChar() == '\r' && GetNextChar() == '\n';
		}

		/// <summary>
		/// Добавляет новую лексему в список.
		/// </summary>
		private void AddLexeme(VkScriptLexemeType type, LexemeLocation location)
		{
			Lexemes.Add(new VkScriptLexeme(type, location, default));
		}

		/// <summary>
		/// Удаляет лишние новые строки из списка.
		/// </summary>
		private void FilterNewlines()
		{
			var eaters = new[] { VkScriptLexemeType.Indent, VkScriptLexemeType.Dedent, VkScriptLexemeType.Eof };
			var result = new List<VkScriptLexeme>(Lexemes.Count);

			var isStart = true;
			VkScriptLexeme newLine = null;

			foreach (var currentLexeme in Lexemes)
			{
				if (currentLexeme.Type == VkScriptLexemeType.NewLine)
				{
					if (!isStart)
					{
						newLine = currentLexeme;
					}
				} else
				{
					if (newLine != null)
					{
						if (!currentLexeme.Type.IsAnyOf(eaters))
						{
							result.Add(newLine);
						}

						newLine = null;
					}

					isStart = false;
					result.Add(currentLexeme);
				}
			}

			Lexemes = result;
		}

	#endregion
	}
}