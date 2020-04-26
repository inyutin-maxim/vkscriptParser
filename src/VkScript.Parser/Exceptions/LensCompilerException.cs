using System;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Exceptions
{
	/// <summary>
	/// Общее исключение, которое произошло во время разбора.
	/// </summary>
	public class LensCompilerException : Exception
	{
	#region Constructors

		public LensCompilerException(string msg) : base(msg)
		{
		}

		public LensCompilerException(string msg, Exception inner) : base(msg, inner)
		{
		}

		public LensCompilerException(string msg, LocationEntity entity) : base(msg)
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
		public LensCompilerException BindToLocation(LocationEntity entity)
		{
			return BindToLocation(entity.StartLocation, entity.EndLocation);
		}

		/// <summary>
		/// Привязать исключение к локации.
		/// </summary>
		public LensCompilerException BindToLocation(LexemeLocation start, LexemeLocation end)
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