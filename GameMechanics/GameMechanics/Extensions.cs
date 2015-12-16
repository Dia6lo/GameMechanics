using System;
using System.Collections.Generic;

namespace GameMechanics
{
	internal static class Extensions
	{
		public static T Random<T>(this IList<T> list)
		{
			return list[new Random().Next(list.Count)];
		} 
	}
}
