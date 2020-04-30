using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Нода умножает два числа
	/// </summary>
	public class VkScriptDivideOperatorNode : VkScriptBinaryOperator
	{
		protected override string OperatorRepresentation => "/";

		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptDivideOperatorNode { LeftOperand = left, RightOperand = right };
		}
	}
}