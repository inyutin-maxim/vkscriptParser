using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser.SyntaxTree.ControlFlow
{
	public class VkScriptIfNode : VkScriptSyntaxNode
	{
	#region Constructor

		public VkScriptIfNode()
		{
			TrueAction = new VkScriptCodeBlockNode();
		}

	#endregion

	#region Fields

		/// <summary>
		/// Состояние
		/// </summary>
		public VkScriptSyntaxNode Condition { get; set; }

		/// <summary>
		/// Блок кода, который будет выполнен, если условие true.
		/// </summary>
		public VkScriptCodeBlockNode TrueAction { get; set; }

		/// <summary>
		/// Блок кода, который будет выполнен, если условие false.
		/// </summary>
		public VkScriptCodeBlockNode FalseAction { get; set; }

	#endregion
	}
}
