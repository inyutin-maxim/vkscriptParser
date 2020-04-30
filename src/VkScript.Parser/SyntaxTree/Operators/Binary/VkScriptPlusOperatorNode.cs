using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Нода умножает два числа
	/// </summary>
	public class VkScriptPlusOperatorNode : VkScriptBinaryOperator
	{
		protected override string OperatorRepresentation => "+";

		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptPlusOperatorNode { LeftOperand = left, RightOperand = right };
		}
	}
}