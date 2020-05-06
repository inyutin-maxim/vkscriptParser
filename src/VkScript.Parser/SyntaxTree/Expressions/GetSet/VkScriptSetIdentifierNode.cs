using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.Expressions.GetSet
{
	/// <summary>
	/// Нода, предоставляющая доступ для чтения к локальной переменной или функции.
	/// </summary>
	internal class VkScriptSetIdentifierNode : IdentifierNodeBase
	{
	#region Constructor

		public VkScriptSetIdentifierNode(string identifier = null)
		{
			Identifier = identifier;
		}

		#endregion

		#region Fields

		/// <summary>
		/// Флаг, указывающий, что присвоение константной переменной является допустимым, поскольку оно создается.
		/// </summary>
		public bool IsInitialization { get; set; }

		/// <summary>
		/// Присвоенное значение
		/// </summary>
		public VkScriptSyntaxNode Value { get; set; }

		/*/// <summary>
		/// Глобальная ссылка на свойство (если разрешено)
		/// </summary>
		private GlobalPropertyInfo _property;*/

		#endregion
	}
}
