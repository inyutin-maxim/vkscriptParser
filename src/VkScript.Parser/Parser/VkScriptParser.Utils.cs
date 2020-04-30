using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using VkScript.Parser.Exceptions;
using VkScript.Parser.Lexer;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Parser
{
	public partial class VkScriptParser
	{
		/// <summary>
		/// Выдает ошибку, связанную с текущей лексемой.
		/// </summary>
		[ContractAnnotation(" => halt")]
		[DebuggerStepThrough]
		private void Error(string msg, params object[] args)
		{
			throw new VkScriptCompilerException(string.Format(msg, args),
				_lexemes[_lexemeId]);
		}

		/// <summary>
		/// Проверяет, соответствует ли шаблон в текущем местоположении указанному.
		/// </summary>
		[DebuggerStepThrough]
		private bool Peek(params VkScriptLexemeType[] types)
		{
			return Peek(0, types);
		}

		/// <summary>
		/// Проверяет, соответствует ли шаблон со смещением заданному.
		/// </summary>
		[DebuggerStepThrough]
		private bool Peek(int offset, params VkScriptLexemeType[] types)
		{
			foreach (var curr in types)
			{
				var id = Math.Min(_lexemeId + offset, _lexemes.Length - 1);
				var lex = _lexemes[id];

				if (lex.Type != curr)
				{
					return false;
				}

				offset++;
			}

			return true;
		}

		/// <summary>
		/// Проверяет, имеет ли текущая лексема любой из заданных типов.
		/// </summary>
		[UsedImplicitly]
		private bool PeekAny(params VkScriptLexemeType[] types)
		{
			var id = Math.Min(_lexemeId, _lexemes.Length - 1);
			var lex = _lexemes[id];

			return lex.Type.IsAnyOf(types);
		}

		/// <summary>
		/// Возвращает текущую лексему, если она данного типа, или выдает ошибку.
		/// </summary>
		[DebuggerStepThrough]
		[UsedImplicitly]
		private VkScriptLexeme Ensure(VkScriptLexemeType type, string msg, params object[] args)
		{
			var lex = _lexemes[_lexemeId];

			if (lex.Type != type)
			{
				Error(msg, args);
			}

			Skip();

			return lex;
		}

		/// <summary>
		/// Проверяет, имеет ли текущая лексема заданный тип, и переходит к следующей.
		/// </summary>
		[DebuggerStepThrough]
		private bool Check(VkScriptLexemeType lexeme)
		{
			var lex = _lexemes[_lexemeId];

			if (lex.Type != lexeme)
			{
				return false;
			}

			Skip();

			return true;
		}

		/// <summary>
		/// Получает значение текущего идентификатора и пропускает его.
		/// </summary>
		[DebuggerStepThrough]
		[UsedImplicitly]
		private string GetValue()
		{
			var value = _lexemes[_lexemeId].Value;
			Skip();

			return value;
		}

		/// <summary>
		/// Игнорирует следующие лексемы.
		/// </summary>
		[DebuggerStepThrough]
		private void Skip(int count = 1)
		{
			_lexemeId = Math.Min(_lexemeId + count, _lexemes.Length - 1);
		}

		/// <summary>
		/// Проверяет, есть ли новая строка или блок закончился.
		/// </summary>
		private bool IsStatementSeparator()
		{
			return Check(VkScriptLexemeType.NewLine)
					|| _lexemes[_lexemeId - 1].Type == VkScriptLexemeType.Dedent;
		}

		/// <summary>
		/// Attempts to parse a node.
		/// If the node does not match, the parser state is silently reset to original.
		/// </summary>
		[DebuggerStepThrough]
		[UsedImplicitly]
		private T Attempt<T>(Func<T> getter)
			where T : LocationEntity
		{
			var backup = _lexemeId;
			var result = Bind(getter);

			if (result == null)
			{
				_lexemeId = backup;
			}

			return result;
		}

		/// <summary>
		/// Attempts to parse a list of values.
		/// </summary>
		[DebuggerStepThrough]
		[UsedImplicitly]
		private List<T> Attempt<T>(Func<List<T>> getter)
		{
			var backup = _lexemeId;
			var result = getter();

			if (result == null || result.Count == 0)
			{
				_lexemeId = backup;
			}

			return result;
		}

		/// <summary>
		/// Attempts to parse a node.
		/// If the node does not match, an error is thrown.
		/// </summary>
		[DebuggerStepThrough]
		[UsedImplicitly]
		private T Ensure<T>(Func<T> getter, string msg, params object[] args)
			where T : LocationEntity
		{
			var result = Bind(getter);

			if (result == null)
			{
				Error(msg, args);
			}

			return result;
		}

		/// <summary>
		/// Sets StartLocation and EndLocation to a node if it requires.
		/// </summary>
		[DebuggerStepThrough]
		private T Bind<T>(Func<T> getter)
			where T : LocationEntity
		{
			var startId = _lexemeId;
			var start = _lexemes[_lexemeId];

			var result = getter();

			if (result == null)
			{
				return null;
			}

			result.StartLocation = start.StartLocation;

			var endId = _lexemeId;

			if (endId > startId && endId > 0)
			{
				result.EndLocation = _lexemes[_lexemeId - 1].EndLocation;
			}

			return result;
		}
	}
}