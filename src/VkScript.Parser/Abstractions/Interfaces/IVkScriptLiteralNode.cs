using System;
using System.Collections.Generic;
using System.Text;

namespace VkScript.Parser.Abstractions.Interfaces
{
	/// <summary>
	/// Интерфейс для выражений литералов
	/// </summary>
	internal interface IVkScriptLiteralNode
	{
		Type LiteralType { get; }
	}
}
