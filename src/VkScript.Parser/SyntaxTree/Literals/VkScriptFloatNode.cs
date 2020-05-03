using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions.Interfaces;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает литерал с плавающей запятой тип float
	/// </summary>
	public class VkScriptFloatNode : VkScriptLiteralNode<float>
	{
	#region Constructor

		public VkScriptFloatNode(float value = 0)
		{
			Value = value;
		}

	#endregion
	}
}
