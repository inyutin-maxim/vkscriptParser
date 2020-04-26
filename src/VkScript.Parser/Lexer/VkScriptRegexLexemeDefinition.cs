using System.Text.RegularExpressions;

namespace VkScript.Parser.Lexer
{
	/// <summary>
	/// Определение лексемы через регулярное выражение
	/// </summary>
	public class VkScriptRegexLexemeDefinition : VkScriptLexemeDefinitionBase
	{
		/// <summary>
		/// Регулярное выражение для текущей лексемы
		/// </summary>
		public readonly Regex Regex;

		/// <summary>
		/// Инициализация описания лексемы через регулярное выражение
		/// </summary>
		/// <param name="regex">Регулярное выражение</param>
		/// <param name="type">Тип лексемы</param>
		public VkScriptRegexLexemeDefinition(string regex, VkScriptLexemeType type) : base(type)
		{
			Regex = new Regex(@"\G" + regex, RegexOptions.Compiled);
		}
	}
}