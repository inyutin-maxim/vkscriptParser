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
		/// The condition.
		/// </summary>
		public VkScriptSyntaxNode Condition { get; set; }

		/// <summary>
		/// The block of code to be executed if the condition is true.
		/// </summary>
		public VkScriptCodeBlockNode TrueAction { get; set; }

		/// <summary>
		/// The block of code to be executed if the condition is false.
		/// </summary>
		public VkScriptCodeBlockNode FalseAction { get; set; }

	#endregion
	}
}
