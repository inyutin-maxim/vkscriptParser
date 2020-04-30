using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Базовая нода для бинарных операторов
	/// </summary>
	public abstract class VkScriptBinaryOperator : VkScriptOperatorNode
	{
	#region Fields

		/// <summary>
		/// Левый операнд
		/// </summary>
		public VkScriptSyntaxNode LeftOperand { get; set; }

		/// <summary>
		/// Правый операнд
		/// </summary>
		public VkScriptSyntaxNode RightOperand { get; set; }

		/// <summary>
		/// Checks if numeric type casting checks should be applied to operands.
		/// </summary>
		protected virtual bool IsNumericOperator => true;

		#endregion

		/// <summary>
		/// Создаёт объект с таким же типом
		/// </summary>
		/// <param name="left">Левый операнд</param>
		/// <param name="right">Правый операнд</param>
		/// <returns></returns>
		protected abstract VkScriptBinaryOperator ReСreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right);
	}
}
