using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Enums;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Нода операторов сравнения
	/// </summary>
	public class VkScriptComparisonOperatorNode : VkScriptBinaryOperator
	{
		#region Constructor

		public VkScriptComparisonOperatorNode(VkScriptComparisonOperatorKind kind = default)
		{
			Kind = kind;
		}

		#endregion

		#region Fields

		public VkScriptComparisonOperatorKind Kind { get; set; }

		#endregion

		#region Operator basics

		protected override string OperatorRepresentation
		{
			get
			{
				switch (Kind)
				{
					case VkScriptComparisonOperatorKind.Equals: return "==";
					case VkScriptComparisonOperatorKind.NotEquals: return "<>";
					case VkScriptComparisonOperatorKind.Less: return "<";
					case VkScriptComparisonOperatorKind.LessEquals: return "<=";
					case VkScriptComparisonOperatorKind.Greater: return ">";
					case VkScriptComparisonOperatorKind.GreaterEquals: return ">=";

					default: throw new ArgumentException("Comparison operator kind is invalid!");
				}
			}
		}


		protected override VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right)
		{
			return new VkScriptComparisonOperatorNode(Kind) { LeftOperand = left, RightOperand = right };
		}

		#endregion
	}
}
