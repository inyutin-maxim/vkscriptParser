using JetBrains.Annotations;
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
		[UsedImplicitly]
		public VkScriptSyntaxNode Parent { get; }

		/// <summary>
		/// Тип
		/// </summary>
		[UsedImplicitly]
		public VkScriptSyntaxNodeTypes Type { get; }

		/// <summary>
		/// Местоположение в коде
		/// </summary>
		[UsedImplicitly]
		public TextSpan TextSpan { get; }

		/// <summary>
		/// Значение
		/// </summary>
		[UsedImplicitly]
		public string Value { get; }

		public abstract void Accept(VkScriptSyntaxVisitor visitor);
	}
}