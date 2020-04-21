using System;
using VkScript.Parser.Model.Text;

namespace VkScript.Parser.Abstractions
{
	public abstract class VkScriptSyntaxNode
	{
		public VkScriptSyntaxNode(VkScriptSyntaxNode parent, TextSpan textSpan)
		{
			Parent = parent;

			TextSpan = textSpan;
		}

		/// <summary>
		/// Родитель
		/// </summary>
		private VkScriptSyntaxNode Parent { get; }

		/// <summary>
		/// Тип
		/// </summary>
		private Type Type { get; }

		/// <summary>
		/// Местоположение в коде
		/// </summary>
		private TextSpan TextSpan{ get; }

		/// <summary>
		/// Значение
		/// </summary>
		private string Value { get; }

		public abstract void Accept(VkScriptSyntaxVisitor visitor);
	}
}