using JetBrains.Annotations;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Lexer
{
	/// <summary>
	/// Лексемы для VkScript
	/// </summary>
	[UsedImplicitly]
	public class VkScriptLexeme : LocationEntity
	{
		/// <summary>
		/// Тип текущей лексемы.
		/// </summary>
		public readonly VkScriptLexemeType Type;

		/// <summary>
		/// Фактическое значение (для некоторых типов лексем, таких как числа или
		/// идентификаторы).
		/// </summary>
		public readonly string Value;

		/// <summary>
		/// Инициализация лексемы VkScript
		/// </summary>
		/// <param name="type"> Тип лексемы </param>
		/// <param name="start"> Начальное положение лексемы </param>
		/// <param name="end"> Конечное положение лексемы </param>
		/// <param name="value"> Значение </param>
		public VkScriptLexeme(VkScriptLexemeType type, LexemeLocation start, LexemeLocation end, string value = null)
		{
			Type = type;
			Value = value;
			StartLocation = start;
			EndLocation = end;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((VkScriptLexeme) obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				return (Type.GetHashCode() * 397)^(Value != null ? Value.GetHashCode() : 0);
			}
		}

		/// <summary>
		/// Сравнить текущую лексему с другой
		/// </summary>
		/// <param name="other"> Другая лексема </param>
		/// <returns>
		/// <c> true </c> - если лексемы одинаковые, иначе <c> false </c>
		/// </returns>
		private bool Equals(VkScriptLexeme other)
		{
			return Type.Equals(other.Type) && string.Equals(Value, other.Value);
		}

		/// <inheritdoc />
		public override string ToString()
		{
			var format = string.IsNullOrEmpty(Value) ? "{0}" : "{0}({1})";

			return string.Format(format, Type, Value);
		}
	}
}