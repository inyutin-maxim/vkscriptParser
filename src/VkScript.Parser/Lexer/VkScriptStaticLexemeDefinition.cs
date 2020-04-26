namespace VkScript.Parser.Lexer
{
	/// <summary>
	/// Определение описания статической лексемы (ключевые слова, операторы)
	/// </summary>
	public class VkScriptStaticLexemeDefinition : VkScriptLexemeDefinitionBase
	{
		/// <summary>
		/// Представление
		/// </summary>
		public readonly string Representation;

		/// <summary>
		/// Инициализация описания статической лексемы
		/// </summary>
		/// <param name="representation">Представление</param>
		/// <param name="type">Тип лексемы</param>
		public VkScriptStaticLexemeDefinition(string representation, VkScriptLexemeType type) : base(type)
		{
			Representation = representation;
		}
	}
}