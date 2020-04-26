namespace VkScript.Parser.SyntaxTree
{
	/// <summary>
	/// Базовый класс для объектов исходного кода, которые имеют местоположение.
	/// </summary>
	public class LocationEntity
	{
		/// <summary>
		/// Начальная позиция текущего объекта.
		/// </summary>
		/// <remarks>
		/// Для сообщения об ошибках
		/// </remarks>
		public LexemeLocation StartLocation { get; set; }

		/// <summary>
		/// Конечная позиция текущей сущности.
		/// </summary>
		/// <remarks>
		/// Для сообщения об ошибках
		/// </remarks>
		public LexemeLocation EndLocation { get; set; }
	}
}