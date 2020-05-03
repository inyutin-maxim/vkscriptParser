using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions.Interfaces;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает литерал с плавающей запятой тип float
	/// </summary>
	public class VkScriptStringNode : VkScriptLiteralNode<string>
	{
	#region Constructor

		public VkScriptStringNode(string value = null)
		{
			Value = value;
		}

	#endregion
	}
}
