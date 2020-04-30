using System.Collections.Generic;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Lexer;

namespace VkScript.Parser.Parser
{
	/// <summary>
	/// Парсер VkScript
	/// </summary>
	public interface IVkScriptParser
	{
		/// <summary>
		/// Преобразовать лексемы в синтаксическое дерево
		/// </summary>
		/// <param name="lexemes"> Список лексем </param>
		/// <returns> Список нод синтаксического дерева </returns>
		IEnumerable<VkScriptSyntaxNode> Parse(IEnumerable<VkScriptLexeme> lexemes);
	}
}