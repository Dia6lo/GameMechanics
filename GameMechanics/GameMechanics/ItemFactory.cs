namespace GameMechanics
{
	public static class ItemFactory
	{
		public static IItem Create<T>() where T : IItem, new()
		{
			return new T();
		}
	}
}
