using System;
using System.Collections.Generic;
using System.Text;

namespace VkScript.Parser.SyntaxTree.Literals
{
	/// <summary>
	/// Нода описывает десятичное число с плавающей запятой
	/// </summary>
	public class VkScriptDecimalNode : VkScriptLiteralNode<decimal>
	{
	#region Constructor

		public VkScriptDecimalNode(decimal value = 0)
		{
			Value = value;
		}
	#endregion
	}
}
