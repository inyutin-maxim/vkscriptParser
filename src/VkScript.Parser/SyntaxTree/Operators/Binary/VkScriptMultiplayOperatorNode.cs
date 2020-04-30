using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Нода умножает два числа
	/// </summary>
	public class VkScriptMultiplayOperatorNode : VkScriptBinaryOperator
	{
		protected override string OperatorRepresentation => "*";

		protected override VkScriptBinaryOperator ReСreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptMultiplayOperatorNode { LeftOperand = left, RightOperand = right };
		}
	}
}
