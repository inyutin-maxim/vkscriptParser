using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Abstractions.Interfaces;
using VkScript.Parser.Compiler;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает null литерал
	/// </summary>
	public class VkScriptNullNode : VkScriptSyntaxNode, IVkScriptLiteralNode
	{
		public Type LiteralType => typeof(NullType);

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return "(null)";
		}
	}
}
