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
		/// Имя метода, используемого компилятором C # для перегрузки метода.
		/// </summary>
		protected virtual string OverloadedMethodName => null;

	#endregion
	}
}