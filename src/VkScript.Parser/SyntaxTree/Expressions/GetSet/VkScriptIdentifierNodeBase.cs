using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Compiler;

namespace VkScript.Parser.SyntaxTree.Expressions.GetSet
{
	internal abstract class IdentifierNodeBase : VkScriptSyntaxNode
	{
	#region Fields

		/// <summary>
		/// Имя идентификатора
		/// </summary>
		public string Identifier { get; set; }

		/// <summary>
		/// Ссылка на локальную переменную
		/// </summary>
		public Local Local { get; set; }

	#endregion
	}
}
