namespace VkScript.Parser.Lexer
{
	/// <summary>
	/// Тип лексемы
	/// </summary>
	/// <remarks>
	/// Скопировано из <see href="https://github.com/impworks/lens/blob/master/Lens/Lexer/LexemType.cs"/>
	/// </remarks>
	public enum VkScriptLexemeType
	{
		/// <summary>
		/// Конец файла
		/// </summary>
		Eof,

		/// <summary>
		/// Новая строка
		/// </summary>
		NewLine,

		/// <summary>
		/// Оператор возвращения значения
		/// </summary>
		Return,

		/// <summary>
		/// Условный оператор
		/// </summary>
		If,

		/// <summary>
		/// Тело условного оператора если выражение истинно
		/// </summary>
		Then,

		/// <summary>
		/// Тело условного оператора если выражение ложно
		/// </summary>
		Else,

		/// <summary>
		/// Цикл while, бесконечный цикл с предусловием
		/// </summary>
		While,

		/// <summary>
		/// Цикл <c>do {} while(bool)</c>, бесконечный цикл с постусловием
		/// </summary>
		Do,

		/// <summary>
		/// Объявление переменной
		/// </summary>
		Var,

		/// <summary>
		/// Ключевое слово для указания значения null
		/// </summary>
		Null,

		/// <summary>
		/// Ключевое слово для указания значения true для булевой переменной
		/// </summary>
		True,

		/// <summary>
		/// Ключевое слово для указания значения false для булевой переменной
		/// </summary>
		False,

		/// <summary>
		/// Число
		/// </summary>
		Number,

		/// <summary>
		/// Строка
		/// </summary>
		String,

		/// <summary>
		/// Идентификатор
		/// </summary>
		Identifier,

		/// <summary>
		/// Регулярное выражение
		/// </summary>
		Regex,

		/// <summary>
		/// Оператор сложения/конкатенации
		/// </summary>
		Plus,

		/// <summary>
		/// Оператор вычитания
		/// </summary>
		Minus,

		/// <summary>
		/// Оператор умножения
		/// </summary>
		Multiply,

		/// <summary>
		/// Оператор деления
		/// </summary>
		Divide,

		/// <summary>
		/// Отступ
		/// </summary>
		Indent,

		/// <summary>
		/// Сдача
		/// </summary>
		Dedent,

		/// <summary>
		/// Оператор присвоения значения
		/// </summary>
		Assign,

		/// <summary>
		/// Точка с запятой
		/// </summary>
		Semicolon,

		/// <summary>
		/// Оператор не равенства
		/// </summary>
		NotEqual,

		/// <summary>
		/// Открывающая круглая скобка
		/// </summary>
		RoundOpen,

		/// <summary>
		/// Закрывающая круглая скобка
		/// </summary>
		RoundClose
	}
}