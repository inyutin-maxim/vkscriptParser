using System;
using System.Collections.Generic;
using System.Text;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает булев литерал true/false
	/// </summary>
	public class VkScriptBooleanNode : VkScriptLiteralNode<bool>
	{
	#region Constructor

		public VkScriptBooleanNode(bool value = false)
		{
			Value = value;
		}
	#endregion
	}
}
