using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	public class VkScriptShiftOperatorNode : VkScriptBinaryOperator
	{
	#region Fields

		/// <summary>
		/// Индикатор направление сдвига влево или вправо
		/// </summary>
		public bool IsLeft;

	#endregion

	#region Operator basics

		protected override string OperatorRepresentation => IsLeft ? "<<" : ">>";

		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptShiftOperatorNode { IsLeft = IsLeft, LeftOperand = left, RightOperand = right };
		}

	#endregion
	}
}
