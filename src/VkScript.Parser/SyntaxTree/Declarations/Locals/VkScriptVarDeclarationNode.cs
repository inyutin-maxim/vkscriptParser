namespace VkScript.Parser.SyntaxTree.Declarations.Locals
{
	/// <summary>
	/// Узел объявления переменных.
	/// </summary>
	public class VkScriptVarDeclarationNode : VkScriptNameDeclarationNodeBase
	{
		/// <inheritdoc />
		public VkScriptVarDeclarationNode(string name = null) : base(name, false)
		{
		}
	}
}