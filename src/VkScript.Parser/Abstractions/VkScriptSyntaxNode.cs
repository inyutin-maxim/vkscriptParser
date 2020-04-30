using System;
using System.Diagnostics;
using JetBrains.Annotations;
using VkScript.Parser.Exceptions;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Abstractions
{
	public abstract class VkScriptSyntaxNode : LocationEntity
	{
	#region Fields

		/// <summary>
		/// Тип кэшированного выражения.
		/// </summary>
		protected Type CachedExpressionType;

	#endregion


	#region Constant checkers

		/// <summary>
		/// Проверяет, является ли текущий узел константой.
		/// </summary>
		public virtual bool IsConstant => false;

		/// <summary>
		/// Возвращает постоянное значение, соответствующее текущему узлу.
		/// </summary>
		public virtual dynamic ConstantValue => throw new InvalidOperationException("Not a constant!");

	#endregion

	#region Helpers

		/// <summary>
		/// Сообщает об ошибке компилятору.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <param name="args">Необязательные аргументы ошибки.</param>
		[ContractAnnotation("=> halt")]
		[DebuggerStepThrough]
		protected void Error(string message, params object[] args)
		{
			Error(this, message, args);
		}

		/// <summary>
		/// Сообщает об ошибке компилятору.
		/// </summary>
		/// <param name="entity">Местоположение объекта, с которым связана ошибка.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <param name="args">Необязательные аргументы ошибки.</param>
		[ContractAnnotation("=> halt")]
		[DebuggerStepThrough]
		protected void Error(LocationEntity entity, string message, params object[] args)
		{
			var msg = string.Format(message, args);

			throw new VkScriptCompilerException(msg, entity);
		}

	#endregion
	}
}