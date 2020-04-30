namespace VkScript.Parser.Lexer
{
	/// <summary>
	/// Базовое определение лексемы.
	/// </summary>
	public abstract class VkScriptLexemeDefinitionBase
	{
		/// <summary>
		/// Инициализация определения лексемы
		/// </summary>
		/// <param name="type"> Тип лексемы </param>
		protected VkScriptLexemeDefinitionBase(VkScriptLexemeType type)
		{
			Type = type;
		}

		/// <summary>
		/// Тип лексемы
		/// </summary>
		public VkScriptLexemeType Type { get; }
	}
}