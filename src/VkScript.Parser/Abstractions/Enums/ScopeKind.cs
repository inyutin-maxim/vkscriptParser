namespace VkScript.Parser.Abstractions.Enums
{
	/// <summary>
	/// A kind of type entity defined in the type manager.
	/// </summary>
	public enum ScopeKind
	{
		/// <summary>
		/// Scope has no 
		/// </summary>
		Unclosured,

		/// <summary>
		/// Scope is the root of a static user-defined function (including Main).
		/// Closure parent is not used.
		/// </summary>
		FunctionRoot,

		/// <summary>
		/// Scope is within a loop.
		/// Closure parent is loaded from a local variable.
		/// </summary>
		Loop,

		/// <summary>
		/// Scope is the root of a lambda function.
		/// Closure parent is loaded from 'this' pointer.
		/// </summary>
		LambdaRoot,

		/// <summary>
		/// Special case for match node's root scope.
		/// Makes each of the nested expression blocks explicitly return the value.
		/// </summary>
		MatchRoot
	}
}
