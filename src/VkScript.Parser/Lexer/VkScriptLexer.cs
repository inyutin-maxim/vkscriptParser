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

				if (CurrChar() == '"' || CurrChar() == '\'')
				{
					ProcessStringLiteral();

					if (!InBounds())
					{
						break;
					}
				} else if (IsComment())
				{
					while (InBounds() && CurrChar() != '\r' && CurrChar() != '\n')
					{
						_position++;
					}
				} else if (CurrChar() == '\t')
				{
					Error(LexerMessages.TabChar);
				} else
				{
					var lex = ProcessStaticLexeme() ?? ProcessRegexLexeme();

					if (lex == null)
					{
						Error(LexerMessages.UnknownLexem);
					}

					Lexemes.Add(lex);
				}

				SkipSpaces();
			}

			if (Lexemes[Lexemes.Count - 1].Type != VkScriptLexemeType.NewLine)
			{
				AddLexeme(VkScriptLexemeType.NewLine, GetPosition());
			}

			while (_indentLookup.Count > 1)
			{
				AddLexeme(VkScriptLexemeType.Dedent, GetPosition());
				_indentLookup.Pop();
			}

			if (Lexemes[Lexemes.Count - 1].Type == VkScriptLexemeType.NewLine)
			{
				Lexemes.RemoveAt(Lexemes.Count - 1);
			}

			AddLexeme(VkScriptLexemeType.Eof, GetPosition());
			FilterNewlines();

			return Lexemes;
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

		/// <summary>
		/// Поиск уровней отступов.
		/// </summary>
		private readonly Stack<int> _indentLookup = new Stack<int>();

	#endregion

	#region Private methods

		/// <summary>
		/// Обнаруживает изменения отступа.
		/// </summary>
		private void ProcessIndent()
		{
			var currIndent = 0;

			while (CurrChar() == ' ')
			{
				Skip();
				currIndent++;
			}

			// empty line?
			if (CurrChar() == '\n' || CurrChar() == '\r')
			{
				return;
			}

			// first line?
			if (_indentLookup.Count == 0)
			{
				_indentLookup.Push(currIndent);
			}

			// indent increased
			else if (currIndent > _indentLookup.Peek())
			{
				_indentLookup.Push(currIndent);
				AddLexeme(VkScriptLexemeType.Indent, GetPosition());
			}

			// indent decreased
			else if (currIndent < _indentLookup.Peek())
			{
				while (true)
				{
					if (_indentLookup.Count > 0)
					{
						_indentLookup.Pop();
					} else
					{
						Error(LexerMessages.InconsistentIdentation);
					}

					AddLexeme(VkScriptLexemeType.Dedent, GetPosition());

					if (currIndent == _indentLookup.Peek())
					{
						break;
					}
				}
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

			var startPos = GetPosition();
			var sb = new StringBuilder();
			var isEscaped = false;

			while (InBounds())
			{
				var ch = CurrChar();

				if (!isEscaped && ch == '\\')
				{
					isEscaped = true;

					continue;
				}

				if (isEscaped)
				{
					var nextChar = NextChar();

					if (nextChar.HasValue)
					{
						sb.Append(EscapeChar(nextChar.Value));
						Skip(2);
					}

					isEscaped = false;

					continue;
				}

				switch (ch)
				{
					case '"':
						Skip();
						Lexemes.Add(new VkScriptLexeme(VkScriptLexemeType.String, startPos, GetPosition(), sb.ToString()));

						return;
					case '\'':
						Skip();
						Lexemes.Add(new VkScriptLexeme(VkScriptLexemeType.String, startPos, GetPosition(), sb.ToString()));

						return;
					case '\n':
						_offset = 1;
						_line++;

						break;
				}

				sb.Append(ch);
				Skip();
			}

			var end = GetPosition();

			throw new LensCompilerException(LexerMessages.UnclosedString).BindToLocation(start, end);
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
			foreach (var curr in lexemes)
			{
				var rep = curr.Representation;
				var len = rep.Length;

				if (_position + len > _source.Length || _source.Substring(_position, len) != rep)
				{
					continue;
				}

				if (_position + len < _source.Length)
				{
					var nextCh = _source[_position + len];

					if (nextChecker != null && !nextChecker(nextCh))
					{
						continue;
					}
				}

				var start = GetPosition();
				Skip(len);
				var end = GetPosition();

				return new VkScriptLexeme(curr.Type, start, end);
			}

			return null;
		}

		/// <summary>
		/// Попытки найти любую из заданных лексем, определенных в регулярном выражении, в текущей позиции в строке.
		/// </summary>
		private VkScriptLexeme ProcessRegexLexeme()
		{
			foreach (var curr in RegexLexemes)
			{
				var match = curr.Regex.Match(_source, _position);

				if (!match.Success)
				{
					continue;
				}

				var start = GetPosition();
				Skip(match.Length);
				var end = GetPosition();

				return new VkScriptLexeme(curr.Type, start, end, match.Value);
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

			if (CurrChar() == '\r')
			{
				Skip();

				return false;
			}

			if (CurrChar() != '\n')
			{
				return false;
			}

			AddLexeme(VkScriptLexemeType.NewLine, GetPosition());

			Skip();
			_offset = 1;
			_line++;
			_newLine = true;

			return true;
		}

		/// <summary>
		/// Добавляет новую лексему в список.
		/// </summary>
		private void AddLexeme(VkScriptLexemeType type, LexemeLocation loc)
		{
			Lexemes.Add(new VkScriptLexeme(type, loc, default));
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

			foreach (var curr in Lexemes)
			{
				if (curr.Type == VkScriptLexemeType.NewLine)
				{
					if (!isStart)
					{
						newLine = curr;
					}
				} else
				{
					if (newLine != null)
					{
						if (!curr.Type.IsAnyOf(eaters))
						{
							result.Add(newLine);
						}

						newLine = null;
					}

					isStart = false;
					result.Add(curr);
				}
			}

			Lexemes = result;
		}

	#endregion
	}
}