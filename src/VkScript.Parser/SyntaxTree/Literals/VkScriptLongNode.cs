using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions.Interfaces;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает long литерал
	/// </summary>
	public class VkScriptLongNode : VkScriptLiteralNode<long>
	{
	#region Constructor

		public VkScriptLongNode(long value = 0)
		{
			Value = value;
		}

	#endregion
	}
}
