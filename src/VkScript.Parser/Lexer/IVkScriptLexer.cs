using System.Collections.Generic;

namespace VkScript.Parser.Lexer
{
	/// <summary>
	/// Лексический анализатор для VkScript
	/// </summary>
	public interface IVkScriptLexer
	{
		/// <summary>
		/// Преобразовать входную строку в список лексем.
		/// </summary>
		List<VkScriptLexeme> Parse(string sourceCode);
	}
}