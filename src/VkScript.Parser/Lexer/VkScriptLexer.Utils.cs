using System.Diagnostics;
using JetBrains.Annotations;
using VkScript.Parser.Exceptions;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Lexer
{
	public partial class VkScriptLexer
	{
		/// <summary>
		/// Ключевые слова
		/// </summary>
		/// <remarks>
		/// https://github.com/impworks/lens/blob/fd84f2622bba04048729e4041a83dd1e9e1e1437/Lens/Lexer/LensLexer.Utils.cs#L12
		/// </remarks>
		private static readonly VkScriptStaticLexemeDefinition[] Keywords =
		{
			new VkScriptStaticLexemeDefinition("while", VkScriptLexemeType.While),
			new VkScriptStaticLexemeDefinition("do", VkScriptLexemeType.Do),
			new VkScriptStaticLexemeDefinition("if", VkScriptLexemeType.If),
			new VkScriptStaticLexemeDefinition("else", VkScriptLexemeType.Else),
			new VkScriptStaticLexemeDefinition("true", VkScriptLexemeType.True),
			new VkScriptStaticLexemeDefinition("false", VkScriptLexemeType.False),
			new VkScriptStaticLexemeDefinition("var", VkScriptLexemeType.Var),
			new VkScriptStaticLexemeDefinition("null", VkScriptLexemeType.Null),
			new VkScriptStaticLexemeDefinition("return", VkScriptLexemeType.Return),
			new VkScriptStaticLexemeDefinition("delete", VkScriptLexemeType.Delete)
		};

		/// <summary>
		/// Список операторов
		/// </summary>
		/// <remarks>
		/// https://github.com/impworks/lens/blob/fd84f2622bba04048729e4041a83dd1e9e1e1437/Lens/Lexer/LensLexer.Utils.cs#L53
		/// </remarks>
		private static readonly VkScriptStaticLexemeDefinition[] Operators =
		{
			new VkScriptStaticLexemeDefinition("==", VkScriptLexemeType.Equal),
			new VkScriptStaticLexemeDefinition("<=", VkScriptLexemeType.LessOrEqual),
			new VkScriptStaticLexemeDefinition(">=", VkScriptLexemeType.GreaterOrEqual),
			new VkScriptStaticLexemeDefinition("+", VkScriptLexemeType.Plus),
			new VkScriptStaticLexemeDefinition("-", VkScriptLexemeType.Minus),
			new VkScriptStaticLexemeDefinition("*", VkScriptLexemeType.Multiply),
			new VkScriptStaticLexemeDefinition("/", VkScriptLexemeType.Divide),
			new VkScriptStaticLexemeDefinition("=", VkScriptLexemeType.Assign),
			new VkScriptStaticLexemeDefinition("!=", VkScriptLexemeType.NotEqual),
			new VkScriptStaticLexemeDefinition(";", VkScriptLexemeType.Semicolon),
			new VkScriptStaticLexemeDefinition(":", VkScriptLexemeType.Colon),
			new VkScriptStaticLexemeDefinition("(", VkScriptLexemeType.RoundOpen),
			new VkScriptStaticLexemeDefinition(")", VkScriptLexemeType.RoundClose),
			new VkScriptStaticLexemeDefinition("[", VkScriptLexemeType.SquareOpen),
			new VkScriptStaticLexemeDefinition("]", VkScriptLexemeType.SquareClose),
			new VkScriptStaticLexemeDefinition("{", VkScriptLexemeType.CurlyOpen),
			new VkScriptStaticLexemeDefinition("}", VkScriptLexemeType.CurlyClose),
			new VkScriptStaticLexemeDefinition(",", VkScriptLexemeType.Comma),
			new VkScriptStaticLexemeDefinition(">>>", VkScriptLexemeType.RightFillingShift),
			new VkScriptStaticLexemeDefinition("<<", VkScriptLexemeType.LeftShift),
			new VkScriptStaticLexemeDefinition(">>", VkScriptLexemeType.RightShift),
			new VkScriptStaticLexemeDefinition("<", VkScriptLexemeType.Less),
			new VkScriptStaticLexemeDefinition(">", VkScriptLexemeType.Greater),
			new VkScriptStaticLexemeDefinition("||", VkScriptLexemeType.Or),
			new VkScriptStaticLexemeDefinition("&&", VkScriptLexemeType.And),
			new VkScriptStaticLexemeDefinition("!", VkScriptLexemeType.Not),
			new VkScriptStaticLexemeDefinition("&", VkScriptLexemeType.BitAnd),
			new VkScriptStaticLexemeDefinition("|", VkScriptLexemeType.BitOr),
			new VkScriptStaticLexemeDefinition("~", VkScriptLexemeType.BitNot),
			new VkScriptStaticLexemeDefinition("^^", VkScriptLexemeType.DoubleXor),
			new VkScriptStaticLexemeDefinition("^", VkScriptLexemeType.ExcludingOr),
			new VkScriptStaticLexemeDefinition("@.", VkScriptLexemeType.ArrayFilter),
			new VkScriptStaticLexemeDefinition("%", VkScriptLexemeType.Modulus)
		};

		/// <summary>
		/// Список лексем построенных посредством регулярных выражений
		/// </summary>
		/// <remarks>
		/// https://github.com/impworks/lens/blob/fd84f2622bba04048729e4041a83dd1e9e1e1437/Lens/Lexer/LensLexer.Utils.cs#L105
		/// </remarks>
		private static readonly VkScriptRegexLexemeDefinition[] RegexLexemes =
		{
			new VkScriptRegexLexemeDefinition(@"(0|[1-9][0-9]*)(\.[0-9]+)?", VkScriptLexemeType.Number),
			new VkScriptRegexLexemeDefinition(@"([a-zA-Z_][0-9a-zA-Z_]*)", VkScriptLexemeType.Identifier)
		};

	#region Escaping

		/// <summary>
		/// Возвращает экранированную версию данного символа.
		/// </summary>
		private char EscapeChar(char input)
		{
			switch (input)
			{
				case 't':
					return '\t';

				case 'n':
					return '\n';

				case 'r':
					return '\r';

				case '\\':
				case '"':
				case '\'':
					return input;
			}

			Error(LexerMessages.UnknownEscape, input);

			return ' ';
		}

	#endregion

	#region Helper methods

		/// <summary>
		/// Возвращает текущий символ
		/// </summary>
		[DebuggerStepThrough]
		private char GetCurrentChar()
		{
			return _source[_position];
		}

		/// <summary>
		/// Возвращает следующий символ, если он есть.
		/// </summary>
		[DebuggerStepThrough]
		private char? GetNextChar(int offset = 1)
		{
			var position = _position + offset;

			if (position < 0 || position >= _source.Length)
			{
				return null;
			}

			return _source[position];
		}

		/// <summary>
		/// Выдает новое исключение, связанное с указанным объектом местоположения.
		/// </summary>
		[ContractAnnotation("=> halt")]
		[DebuggerStepThrough]
		private void Error(LocationEntity location, string source, params object[] args)
		{
			throw new VkScriptCompilerException(string.Format(source, args), location);
		}

		/// <summary>
		/// Выдает новое исключение, привязанное к текущему местоположению в
		/// проанализированном тексте.
		/// </summary>
		[ContractAnnotation("=> halt")]
		[DebuggerStepThrough]
		private void Error(string source, params object[] args)
		{
			var location = new LocationEntity
			{
				StartLocation = GetPosition(), EndLocation = new LexemeLocation
				{
					Line = _line,
					Offset = _position
				}
			};

			Error(location, source, args);
		}

		/// <summary>
		/// Проверяет, вышел ли курсор за пределы строки.
		/// </summary>
		[DebuggerStepThrough]
		private bool InBounds()
		{
			return _position < _source.Length;
		}

		/// <summary>
		/// Проверяет, находится ли курсор в начале комментария.
		/// </summary>
		[DebuggerStepThrough]
		private bool IsComment()
		{
			if (GetCurrentChar() != '/' || GetNextChar() != '/')
			{
				return false;
			}

			Skip(2);

			return true;
		}

		/// <summary>
		/// Пропускает один или несколько символов.
		/// </summary>
		[DebuggerStepThrough]
		private void Skip(int count = 1)
		{
			_position += count;
			_offset += count;
		}

		/// <summary>
		/// Возвращает текущую позицию в строке.
		/// </summary>
		[DebuggerStepThrough]
		private LexemeLocation GetPosition()
		{
			return new LexemeLocation
			{
				Line = _line,
				Offset = _offset
			};
		}

	#endregion
	}
}