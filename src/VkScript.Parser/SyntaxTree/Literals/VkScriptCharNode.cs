using System;
using System.Collections.Generic;
using System.Text;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает символ в юникоде
	/// </summary>
	public class VkScriptCharNode : VkScriptLiteralNode<char>
	{
	#region Constructor

		public VkScriptCharNode(char value)
		{
			Value = value;
		}
	#endregion
	}
}
