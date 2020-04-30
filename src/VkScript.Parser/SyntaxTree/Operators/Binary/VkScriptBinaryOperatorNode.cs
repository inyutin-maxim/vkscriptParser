using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators.Binary
{
	/// <summary>
	/// Базовая нода для бинарных операторов
	/// </summary>
	public abstract class VkScriptBinaryOperator : VkScriptOperatorNode
	{
		/// <summary>
		/// Создаёт объект с таким же типом
		/// </summary>
		/// <param name="left"> Левый операнд </param>
		/// <param name="right"> Правый операнд </param>
		/// <returns> </returns>
		protected abstract VkScriptBinaryOperator RecreateSelfWithArgs(VkScriptSyntaxNode left, VkScriptSyntaxNode right);

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
	}
}