namespace VkScript.Parser
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Проверяет, содержится ли значение в списке.
		/// </summary>
		public static bool IsAnyOf<T>(this T obj, params T[] list)
		{
			for (var idx = list.Length - 1; idx >= 0; idx--)
			{
				if (list[idx].Equals(obj))
				{
					return true;
				}
			}

			return false;
		}
	}
}