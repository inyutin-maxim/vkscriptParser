using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Enums;

namespace VkScript.Parser.SyntaxTree.ControlFlow
{
	public class WhileNode : VkScriptSyntaxNode
	{
	#region Constructor

		public WhileNode()
		{
			Body = new VkScriptCodeBlockNode(ScopeKind.Loop);
		}

	#endregion

	#region Fields

		/// <summary>
		/// Состояние цикла
		/// </summary>
		public VkScriptSyntaxNode Condition { get; set; }

		/// <summary>
		/// Операторы внутри цикла
		/// </summary>
		public VkScriptCodeBlockNode Body { get; }

	#endregion
	}
}
