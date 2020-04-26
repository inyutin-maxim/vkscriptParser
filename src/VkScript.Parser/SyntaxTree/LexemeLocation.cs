namespace VkScript.Parser.SyntaxTree
{
	/// <summary>
	/// Положение каретки в тексте.
	/// </summary>
	public struct LexemeLocation
	{
	#region Fields

		/// <summary>
		/// Номер строки на основе 0 в текущем файле.
		/// </summary>
		public int Line;

		/// <summary>
		/// Позиция на основе 0 символа в текущей строке.
		/// </summary>
		public int Offset;

	#endregion

		/// <inheritdoc />
		public override string ToString()
		{
			return $"{Line}:{Offset}";
		}
	}
}