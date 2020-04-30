using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace VkScript.Parser.Compiler
{
	/// <summary>
	/// Класс, представляющий информацию о локальной переменной.
	/// </summary>
	public class Local
	{
	#region Methods

		/// <summary>
		/// Создайте копию информации об имени и привяжите ее к расстоянию.
		/// </summary>
		public Local GetClosuredCopy(int distance)
		{
			return new Local(this, distance);
		}

	#endregion

	#region Debug

		public override string ToString()
		{
			var entities = new List<string>();

			if (IsClosured)
			{
				entities.Add("closured");
			}

			if (IsRefArgument)
			{
				entities.Add("ref");
			}

			if (IsImmutable)
			{
				entities.Add("immutable");
			}

			if (IsConstant)
			{
				entities.Add("const");
			}

			if (ArgumentId != null)
			{
				entities.Add($"arg({ArgumentId})");
			}

			return $"{Name}:{Type.Name} ({string.Join(", ", entities)})";
		}

	#endregion

	#region Constructors

		/// <summary>
		/// Создает новый экземпляр локальной переменной.
		/// </summary>
		public Local(string name, Type type, bool isConst = false, bool isRefArg = false)
		{
			Name = name;
			Type = type;
			IsImmutable = isConst;
			IsRefArgument = isRefArg;
		}

		/// <summary>
		/// Копировать конструктор для закрытых версий локальных.
		/// </summary>
		private Local(Local other, int dist = 0)
		{
			Name = other.Name;
			Type = other.Type;
			IsImmutable = other.IsImmutable;
			IsRefArgument = other.IsRefArgument;

			IsClosured = other.IsClosured;
			ClosureFieldName = other.ClosureFieldName;

			IsConstant = other.IsConstant;
			ConstantValue = other.ConstantValue;

			LocalBuilder = other.LocalBuilder;
			ArgumentId = other.ArgumentId;

			ClosureDistance = dist;
		}

	#endregion

	#region Fields

		/// <summary>
		/// Имя переменной.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Тип переменной.
		/// </summary>
		public readonly Type Type;

		/// <summary>
		/// Флаг показывающий что переменная только для чтения
		/// </summary>
		public readonly bool IsImmutable;

		/// <summary>
		/// Представляет ли переменная аргумент функции, который передается с помощью ref?
		/// </summary>
		public readonly bool IsRefArgument;

		/// <summary>
		/// Идентификатор аргумента, если это имя представляет единицу.
		/// </summary>
		public int? ArgumentId;

		/// <summary>
		/// На имя ссылаются во вложенных областях?
		/// </summary>
		public bool IsClosured;

		/// <summary>
		/// Расстояние между текущей областью и областью, которой принадлежит эта переменная.
		/// </summary>
		public int? ClosureDistance;

		/// <summary>
		/// Название поля в закрытом классе.
		/// </summary>
		public string ClosureFieldName;

		/// <summary>
		/// Идентификатор локального застройщика.
		/// </summary>
		public LocalBuilder LocalBuilder;

		/// <summary>
		/// Проверяет, представляет ли текущее локальное имя константу.
		/// Также должен быть неизменным!
		/// </summary>
		public bool IsConstant;

		/// <summary>
		/// Значение константы времени компиляции для текущего локального имени.
		/// </summary>
		public dynamic ConstantValue;

	#endregion
	}
}