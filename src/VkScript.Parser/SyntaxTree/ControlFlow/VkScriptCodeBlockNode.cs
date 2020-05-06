using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Enums;
using VkScript.Parser.Compiler;

namespace VkScript.Parser.SyntaxTree.ControlFlow
{
	public class VkScriptCodeBlockNode : VkScriptSyntaxNode, IEnumerable<VkScriptSyntaxNode>
	{
	#region Constructor

		public VkScriptCodeBlockNode(ScopeKind scopeKind = ScopeKind.Unclosured)
		{
			Statements = new List<VkScriptSyntaxNode>();
			Scope = new Scope(scopeKind);
		}

	#endregion

	#region Fields

		/// <summary>
		/// The scope frame corresponding to current code block.
		/// </summary>
		public Scope Scope { get; private set; }

		/// <summary>
		/// The statements to execute.
		/// </summary>
		public List<VkScriptSyntaxNode> Statements { get; set; }

	#endregion

		public IEnumerator<VkScriptSyntaxNode> GetEnumerator()
		{
			return Statements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
