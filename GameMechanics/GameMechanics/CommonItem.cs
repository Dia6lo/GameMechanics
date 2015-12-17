namespace GameMechanics
{
	public class CommonItem: IItem
	{
		public ItemState State { get; set; }
		public Cell Target { get; set; }

		public void StopMoving()
		{
			State = ItemState.Idle;
		}
	}
}
