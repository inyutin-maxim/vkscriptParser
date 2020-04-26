using System.Collections.Generic;
using JetBrains.Annotations;
using VkScript.Parser.Abstractions;

namespace VkScript.Parser
{
	[UsedImplicitly]
	public class VkScriptParser
	{
		public VkScript Parse(string code)
		{
			var nodes = new List<VkScriptSyntaxNode>();

			return new VkScript(nodes);
		}
	}
}