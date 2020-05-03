using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Исключающая нода
	/// </summary>
	public class VkScriptExcludingOrOperatorNode : VkScriptBinaryOperator
	{
	#region Operator basics

		protected override string OperatorRepresentation => "^";

		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptExcludingOrOperatorNode { LeftOperand = left, RightOperand = right };
		}

	#endregion
	}
}
