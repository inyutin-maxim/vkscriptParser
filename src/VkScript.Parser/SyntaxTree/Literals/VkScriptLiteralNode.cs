using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Interfaces;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Базовый класс для нод литералов
	/// </summary>
	public abstract class VkScriptLiteralNode<T> : VkScriptSyntaxNode, IVkScriptLiteralNode
	{
	#region Fields

		/// <summary>
		/// Значение литерала
		/// </summary>
		protected T Value { get; set; }

		/// <summary>
		/// Основной тип
		/// </summary>
		public Type LiteralType => typeof(T);

	#endregion

	#region Constant checkers

		public override bool IsConstant => true;

		public override object ConstantValue => Value;

	#endregion
	}
}
