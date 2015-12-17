using System;

namespace GameMechanics
{
	public interface IItem
	{
		ItemState State { get; set; }
		Cell Target { get; set; }
		void StopMoving();
	}
}