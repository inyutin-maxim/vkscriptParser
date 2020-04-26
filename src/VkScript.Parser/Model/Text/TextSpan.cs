using System;
using JetBrains.Annotations;

namespace VkScript.Parser.Model.Text
{
	[UsedImplicitly]
	public class TextSpan
	{
		public TextSpan(int start, int length)
		{
			if (start < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(start));
			}

			if (start + length < start)
			{
				throw new ArgumentOutOfRangeException(nameof(length));
			}

			Start = start;
			Length = length;
		}

		/// <summary>
		/// Стартовая позиция
		/// </summary>
		public int Start { get; }

		/// <summary>
		/// Конечная позиция
		/// </summary>
		public int End => Start + Length;

		/// <summary>
		/// Длинна
		/// </summary>
		public int Length { get; }

		/// <summary>
		/// Проверяет, является ли span пустым
		/// </summary>
		public bool IsEmpty => Length == 0;

		/// <inheritdoc />
		public override string ToString()
		{
			return $"[{Start}..{End})";
		}
	}
}