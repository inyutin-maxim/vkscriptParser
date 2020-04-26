using System.Collections.Generic;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser
{
	public class VkScript
	{
		public VkScript(List<VkScriptSyntaxNode> nodes)
		{
			Nodes = nodes;
		}

		public List<VkScriptSyntaxNode> Nodes { get; }
	}
}