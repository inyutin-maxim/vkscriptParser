using VkScript.Parser.Abstractions;
using VkScript.Parser.Compiler;
using VkScript.Parser.SyntaxTree.Declarations.Locals;

namespace VkScript.Parser.SyntaxTree
{
	public static  class Expr
	{
		public static VkScriptVarDeclarationNode Var(string name, VkScriptSyntaxNode expr)
		{
			return new VkScriptVarDeclarationNode(name) {Value = expr};
		}

		public static VkScriptVarDeclarationNode Var(string name, TypeSignature type)
		{
			return new VkScriptVarDeclarationNode(name) {Type = type};
		}

		public static VkScriptVarDeclarationNode Var(Local name, TypeSignature type)
		{
			return new VkScriptVarDeclarationNode {Local = name, Type = type};
		}

	}
}