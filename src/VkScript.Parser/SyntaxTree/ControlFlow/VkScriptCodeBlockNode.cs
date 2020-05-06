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
		/// Область видимости соответствуюзая текущему блоку кода
		/// </summary>
		public Scope Scope { get; private set; }

		/// <summary>
		/// Операторы для выполнения
		/// </summary>
		public List<VkScriptSyntaxNode> Statements { get; set; }

		#endregion

		#region IEnumerable<NodeBase> implementation

			public IEnumerator<VkScriptSyntaxNode> GetEnumerator()
			{
				return Statements.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void Add(VkScriptSyntaxNode node)
			{
				Statements.Add(node);
			}

			public void AddRange(params VkScriptSyntaxNode[] nodes)
			{
				Statements.AddRange(nodes);
			}

			public void AddRange(IEnumerable<VkScriptSyntaxNode> nodes)
			{
				Statements.AddRange(nodes);
			}

			public void Insert(VkScriptSyntaxNode node)
			{
				Statements.Insert(0, node);
			}

		#endregion
	}
}
