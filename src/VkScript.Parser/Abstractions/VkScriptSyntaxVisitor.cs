namespace VkScript.Parser.Abstractions
{
	/// <summary>
	///
	/// </summary>
	public abstract class VkScriptSyntaxVisitor
	{
		/// <summary>
		///
		/// </summary>
		public virtual void Visit(VkScriptSyntaxNode node)
		{
			node?.Accept(this);
		}
	}
}