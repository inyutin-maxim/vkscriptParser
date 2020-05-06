namespace VkScript.Parser.Compiler
{
	/// <summary>
	/// Псевдотип, представляющий отсутствие значения (void).
	/// </summary>
	public class UnitType
	{
		public override string ToString()
		{
			return "()";
		}

	#region Debug

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			return obj.GetType() == GetType();
		}

		public override int GetHashCode()
		{
			return 0;
		}

	#endregion
	}

	/// <summary>
	/// Псевдотип, представляющий null значение
	/// </summary>
	public class NullType
	{
	}
}