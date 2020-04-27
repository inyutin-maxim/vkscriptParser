using System;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Exceptions
{
	/// <summary>
	/// Общее исключение, которое произошло во время разбора.
	/// </summary>
	public class VkScriptCompilerException : Exception
	{
	#region Constructors

		public VkScriptCompilerException(string msg) : base(msg)
		{
		}

		public VkScriptCompilerException(string msg, Exception inner) : base(msg, inner)
		{
		}

		public VkScriptCompilerException(string msg, LocationEntity entity) : base(msg)
		{
			BindToLocation(entity);
		}

	#endregion

	#region Fields

		/// <summary>
		/// Начало ошибочного сегмента.
		/// </summary>
		public LexemeLocation? StartLocation { get; private set; }

		/// <summary>
		/// Конец ошибочного сегмента.
		/// </summary>
		public LexemeLocation? EndLocation { get; private set; }

		/// <summary>
		/// Полное сообщение с ошибочными позициями.
		/// </summary>
		public string FullMessage
		{
			get
			{
				if (StartLocation == null && EndLocation == null)
				{
					return Message;
				}

				return EndLocation == null
					? string.Format(Message + "\n" + CompilerMessages.Location, StartLocation.Value)
					: string.Format(Message + "\n" + CompilerMessages.LocationSpan, StartLocation.Value, EndLocation.Value);
			}
		}

	#endregion

	#region Methods

		/// <summary>
		/// Привязать исключение к локации.
		/// </summary>
		public VkScriptCompilerException BindToLocation(LocationEntity entity)
		{
			return BindToLocation(entity.StartLocation, entity.EndLocation);
		}

		/// <summary>
		/// Привязать исключение к локации.
		/// </summary>
		public VkScriptCompilerException BindToLocation(LexemeLocation start, LexemeLocation end)
		{
			if (start.Line != 0 || start.Offset != 0)
			{
				StartLocation = start;
			}

			if (end.Line != 0 || end.Offset != 0)
			{
				EndLocation = end;
			}

			return this;
		}

	#endregion
	}
}