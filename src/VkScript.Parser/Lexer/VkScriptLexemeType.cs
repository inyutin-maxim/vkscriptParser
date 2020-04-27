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
		/// <remarks>
		/// TODO: Разобраться и переименовать или изменить комментарий
		/// </remarks>
		Dedent,

		/// <summary>
		/// Оператор присвоения значения
		/// </summary>
		Assign,

		/// <summary>
		/// Двоеточие
		/// </summary>
		Colon,

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
		RoundClose,

		/// <summary>
		/// Открывающая квадратная скобка
		/// </summary>
		SquareOpen,

		/// <summary>
		/// Закрывающая квадратная скобка
		/// </summary>
		SquareClose,

		/// <summary>
		/// Открывающая фигурная скобка
		/// </summary>
		CurlyOpen,

		/// <summary>
		/// Закрывающая фигурная скобка
		/// </summary>
		CurlyClose,

		/// <summary>
		/// Запятая
		/// </summary>
		Comma,

		/// <summary>
		/// Оператор меньше
		/// </summary>
		Less,

		/// <summary>
		/// Оператор больше
		/// </summary>
		Greater,

		/// <summary>
		/// Оператор меньше или равно
		/// </summary>
		LessOrEqual,

		/// <summary>
		/// Оператор меньше или равно
		/// </summary>
		GreaterOrEqual,

		/// <summary>
		/// Оператор равенства
		/// </summary>
		Equal,

		/// <summary>
		/// Логическое ИЛИ
		/// </summary>
		Or,

		/// <summary>
		/// Логическое И
		/// </summary>
		And,

		/// <summary>
		/// Логическое НЕ
		/// </summary>
		Not,

		/// <summary>
		/// Побитовое И
		/// </summary>
		BitAnd,

		/// <summary>
		/// Побитовое ИЛИ
		/// </summary>
		BitOr
	}
}