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
			if (node != null)
			{
				node.Accept(this);
			}
		}
	}
}
