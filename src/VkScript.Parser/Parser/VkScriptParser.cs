using System.Collections.Generic;
using System.Collections.Immutable;
using JetBrains.Annotations;
using VkScript.Parser.Abstractions;
using VkScript.Parser.Lexer;

namespace VkScript.Parser.Parser
{
	/// <inheritdoc />
	[UsedImplicitly]
	public partial class VkScriptParser : IVkScriptParser
	{
		/// <inheritdoc />
		public IEnumerable<VkScriptSyntaxNode> Parse(IEnumerable<VkScriptLexeme> lexemes)
		{
			_lexemes = lexemes.ToImmutableArray();

			return ParseMain();
		}

		private IEnumerable<VkScriptSyntaxNode> ParseMain()
		{
			while (!Check(VkScriptLexemeType.Eof))
			{
				if (!IsStatementSeparator())
				{
					Error(Peek(VkScriptLexemeType.Assign)
						? ParserMessages.AssignLvalueExpected
						: ParserMessages.NewlineSeparatorExpected);
				}

				yield return new NullVkScriptSyntaxNode();
			}
		}

	#region Fields

		/// <summary>
		/// Сгенерированный список узлов.
		/// </summary>
		public List<VkScriptSyntaxNode> Nodes { get; private set; }

		/// <summary>
		/// Список источников лексем.
		/// </summary>
		private ImmutableArray<VkScriptLexeme> _lexemes;

		/// <summary>
		/// Текущий индекс лексемы в потоке.
		/// </summary>
		private int _lexemeId;

	#endregion

		/*/// <summary>
		/// name_def_stmt                               = var_multi_stmt | var_stmt | let_stmt
		/// </summary>
		private VkScriptSyntaxNode ParseNameDefStmt()
		{
			return Attempt(ParseVarStmt);
		}

		/// <summary>
		/// var_stmt                                    = "var" identifier "=" expr
		/// </summary>
		private VkScriptVarDeclarationNode ParseVarStmt()
		{
			if (!Check(VkScriptLexemeType.Var))
				return null;

			var node = new VkScriptVarDeclarationNode
			{
				Name = Ensure(VkScriptLexemeType.Identifier, ParserMessages.VarIdentifierExpected).Value
			};

			Ensure(VkScriptLexemeType.Assign, ParserMessages.SymbolExpected, '=');

			node.Value = Ensure(ParseExpr, ParserMessages.InitExpressionExpected);

			return node;
		}

		/// <summary>
		/// expr                                        = block_expr | line_expr
		/// </summary>
		private VkScriptVarDeclarationNode ParseExpr()
		{
			return Attempt(ParseBlockExpr)
					?? Attempt(ParseLineExpr);
		}

		/// <summary>
		/// line_expr
		/// </summary>
		/// <example>
		/// if_line | while_line | for_line | using_line | throw_stmt | new_object_line | typeop_expr | line_typecheck_expr
		/// </example>
		/// <remarks>
		/// https://github.com/impworks/lens/blob/91fd082a53ba97b0c9619a8a8a3b8d70b309622c/Lens/Parser/LensParser.cs#L1674
		/// </remarks>
		private VkScriptVarDeclarationNode ParseLineExpr()
		{
			return Attempt(ParseIfLine);
		}

		/// <summary>
		/// if_line                                     = if_header line_stmt [ "else" line_stmt ]
		/// </summary>
		private IfNode ParseIfLine()
		{
			var node = Attempt(ParseIfHeader);

			if (node == null)
				return null;

			node.TrueAction.Add(Ensure(ParseLineStmt, ParserMessages.ConditionExpressionExpected));

			if (Check(LexemType.Else))
				node.FalseAction = new CodeBlockNode { Ensure(ParseLineStmt, ParserMessages.ExpressionExpected) };

			return node;
		}*/
	}
}