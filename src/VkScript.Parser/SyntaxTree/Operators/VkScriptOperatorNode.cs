using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Operators
{
	/// <summary>
	/// Базовая нода для всех операторов
	/// </summary>
	public abstract class VkScriptOperatorNode : VkScriptSyntaxNode
	{
	#region Operator basics

		/// <summary>
		/// Текстовое представление оператора
		/// </summary>
		protected abstract string OperatorRepresentation { get; }

		/// <summary>
		/// The name of the method that C# compiler uses for method overloading.
		/// </summary>
		protected virtual string OverloadedMethodName => null;

	#endregion
	}
}