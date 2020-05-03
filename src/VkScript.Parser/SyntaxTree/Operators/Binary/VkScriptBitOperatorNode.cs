using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Enums;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Нода для битовых операторов
	/// </summary>
	public class VkScriptBitOperatorNode : VkScriptBinaryOperator
	{
	#region Constructor

		public VkScriptBitOperatorNode(VkScriptLogicalOperatorKind kind = default(VkScriptLogicalOperatorKind))
		{
			Kind = kind;
		}

	#endregion

	#region Fields

		/// <summary>
		/// The kind of boolean operator.
		/// </summary>
		public VkScriptLogicalOperatorKind Kind { get; set; }

	#endregion

	#region Operator basics

		protected override string OperatorRepresentation => Kind == VkScriptLogicalOperatorKind.And ? "&" : (Kind == VkScriptLogicalOperatorKind.Or ? "|" : "^");

		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptBitOperatorNode(Kind) { LeftOperand = left, RightOperand = right };
		}

	#endregion
	}
}
