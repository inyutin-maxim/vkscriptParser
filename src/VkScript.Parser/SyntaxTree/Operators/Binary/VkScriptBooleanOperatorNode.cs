using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Enums;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Булева нода
	/// </summary>
	public class VkScriptBooleanOperatorNode : VkScriptBinaryOperator
	{
	#region Constructor

		public VkScriptBooleanOperatorNode(VkScriptLogicalOperatorKind kind = default(VkScriptLogicalOperatorKind))
		{
			if (kind == VkScriptLogicalOperatorKind.Xor)
				throw new ArgumentException("Use XorOperatorNode to represent a XOR ");

			Kind = kind;
		}

	#endregion

	#region Fields

		public VkScriptLogicalOperatorKind Kind;

	#endregion

	#region Operator basics

		protected override bool IsNumericOperator => false;

		protected override string OperatorRepresentation => Kind == VkScriptLogicalOperatorKind.And ? "&&" : "||";

		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptBooleanOperatorNode(Kind) { LeftOperand = left, RightOperand = right };
		}

	#endregion
	}
}
