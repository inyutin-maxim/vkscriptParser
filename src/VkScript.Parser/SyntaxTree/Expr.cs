using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Enums;
using VkScript.Parser.Compiler;
using VkScript.Parser.SyntaxTree.Declarations.Locals;
using VkScript.Parser.SyntaxTree.Operators.Binary;

namespace VkScript.Parser.SyntaxTree
{
	public static class Expr
	{
		public static VkScriptVarDeclarationNode Var(string name, VkScriptSyntaxNode expr)
		{
			return new VkScriptVarDeclarationNode(name) { Value = expr };
		}

		public static VkScriptVarDeclarationNode Var(string name, TypeSignature type)
		{
			return new VkScriptVarDeclarationNode(name) { Type = type };
		}

		public static VkScriptVarDeclarationNode Var(Local name, TypeSignature type)
		{
			return new VkScriptVarDeclarationNode { Local = name, Type = type };
		}

		#region Operators

			public static VkScriptBooleanOperatorNode And(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return new VkScriptBooleanOperatorNode { Kind = VkScriptLogicalOperatorKind.And, LeftOperand = left, RightOperand = right };
			}

			public static VkScriptBooleanOperatorNode Or(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return new VkScriptBooleanOperatorNode { Kind = VkScriptLogicalOperatorKind.Or, LeftOperand = left, RightOperand = right };
			}

			public static VkScriptExcludingOrOperatorNode ExcludingOr(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return Op<VkScriptExcludingOrOperatorNode>(left, right);
			}

			public static VkScriptShiftOperatorNode LeftShift(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return new VkScriptShiftOperatorNode { LeftOperand = left, RightOperand = right, IsLeft = true };
			}

			public static VkScriptShiftOperatorNode RightShift(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return new VkScriptShiftOperatorNode { LeftOperand = left, RightOperand = right, IsLeft = false };
			}

			public static VkScriptPlusOperatorNode Add(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return Op<VkScriptPlusOperatorNode>(left, right);
			}

			public static VkScriptMinusOperatorNode Sub(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return Op<VkScriptMinusOperatorNode>(left, right);
			}

			public static VkScriptMultiplayOperatorNode Mult(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return Op<VkScriptMultiplayOperatorNode>(left, right);
			}

			public static VkScriptDivideOperatorNode Div(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return Op<VkScriptDivideOperatorNode>(left, right);
			}

			public static VkScriptModulusOperatorNode Mod(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
			{
				return Op<VkScriptModulusOperatorNode>(left, right);
			}

		private static T Op<T>(VkScriptSyntaxNode left, VkScriptSyntaxNode right) where T : VkScriptBinaryOperator, new()
			{
				return new T { LeftOperand = left, RightOperand = right };
			}
		#endregion
	}
}