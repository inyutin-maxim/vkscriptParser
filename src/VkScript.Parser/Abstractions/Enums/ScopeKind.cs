namespace VkScript.Parser.Abstractions.Enums
{
	/// <summary>
	/// Сущность определенная в менеджере типов
	/// </summary>
	public enum ScopeKind
	{
		/// <summary>
		/// Нет области видимости
		/// </summary>
		Unclosured,

		/// <summary>
		/// Область вилимости является корнем статической функции
		/// </summary>
		FunctionRoot,

		/// <summary>
		/// Область видимости находится в цикле
		/// </summary>
		Loop,

		/// <summary>
		/// Область видимости - корень лямбда выражения
		/// </summary>
		LambdaRoot,

		/// <summary>
		/// Особый случай для соответствия нод корневой области видимости
		/// Заставляет каждый из вложенных блоков выражений явно возвращать значение.
		/// </summary>
		MatchRoot
	}
}
