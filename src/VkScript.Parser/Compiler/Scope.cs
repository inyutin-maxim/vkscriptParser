using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using VkScript.Parser.Abstractions.Enums;

namespace VkScript.Parser.Compiler
{
	/// <summary>
	/// A scope slice that contains a list of local variables.
	/// </summary>
	public class Scope
	{
	#region Constructor

		public Scope(ScopeKind kind)
		{
			Locals = new Dictionary<string, Local>();
			Kind = kind;
		}

	#endregion

	#region Fields

		/// <summary>
		/// The list of names in current scope.
		/// </summary>
		public readonly Dictionary<string, Local> Locals;

		/// <summary>
		/// The scope that contains the current scope.
		/// </summary>
		public Scope OuterScope;

		/// <summary>
		/// Checks if the the scope is root for a particular method.
		/// </summary>
		public readonly ScopeKind Kind;

		/// <summary>
		/// The type entity that represents current closure.
		/// </summary>
		//public TypeEntity ClosureType { get; private set; }

		/// <summary>
		/// The local variable in which the closure is saved.
		/// </summary>
		public LocalBuilder ClosureVariable { get; private set; }

		/// <summary>
		/// Checks if the current closure type must contain a reference to parent closure to reach some of the variables.
		/// </summary>
		public bool ClosureReferencesOuter { get; private set; }

		/// <summary>
		/// The nearest scope which contains a closure.
		/// </summary>
		//public Scope ActiveClosure => FindScope(x => x.ClosureType != null);

	#endregion
	}
}
