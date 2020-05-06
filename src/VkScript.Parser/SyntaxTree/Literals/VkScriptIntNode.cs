using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions.Interfaces;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает целочисленный литерал тип int
	/// </summary>
	public class VkScriptIntNode : VkScriptLiteralNode<int>
	{
	#region Constructor

		public VkScriptIntNode(int value = 0)
		{
			Value = value;
		}

	#endregion
	}
}
