using System;
using System.Collections.Generic;
using System.Text;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Lexer;

namespace VkScript.Parser.SyntaxTree.Expressions.GetSet
{
	/// <summary>
	/// Shorthand assignment together with an arithmetic or logic operator.
	/// </summary>
	internal class ShortAssignmentNode : VkScriptSyntaxNode
	{
	#region Constructor

		public ShortAssignmentNode(VkScriptLexemeType opType, VkScriptSyntaxNode expr)
		{
			_operatorType = opType;
			_assignmentOperator = OperatorLookups[opType];
			Expression = expr;
		}

	#endregion

	#region Fields

		/// <summary>
		/// Type of shorthand operator.
		/// </summary>
		private readonly VkScriptLexemeType _operatorType;

		/// <summary>
		/// The kind of operator to use short assignment for.
		/// </summary>
		private readonly Func<VkScriptSyntaxNode, VkScriptSyntaxNode, VkScriptSyntaxNode> _assignmentOperator;

		/// <summary>
		/// Assignment expression to expand.
		/// </summary>
		public VkScriptSyntaxNode Expression;

		/// <summary>
		/// Карта лексем соответствующая конструкторам нод
		/// </summary>
		private static readonly Dictionary<VkScriptLexemeType, Func<VkScriptSyntaxNode, VkScriptSyntaxNode, VkScriptSyntaxNode>> OperatorLookups = new Dictionary<VkScriptLexemeType, Func<VkScriptSyntaxNode, VkScriptSyntaxNode, VkScriptSyntaxNode>>
		{
			{VkScriptLexemeType.And, Expr.And},
			{VkScriptLexemeType.Or, Expr.Or},
			{VkScriptLexemeType.ExcludingOr, Expr.ExcludingOr},
			{VkScriptLexemeType.LeftShift, Expr.LeftShift},
			{VkScriptLexemeType.RightShift, Expr.RightShift},
			{VkScriptLexemeType.Plus, Expr.Add},
			{VkScriptLexemeType.Minus, Expr.Sub},
			{VkScriptLexemeType.Divide, Expr.Div},
			{VkScriptLexemeType.Multiply, Expr.Mult},
			{VkScriptLexemeType.Modulus, Expr.Mod}
		};

	#endregion
	}
}
