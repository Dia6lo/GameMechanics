using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GameMechanics
{
	public class Board
	{
		private readonly Cell[,] cells;
		public int Height { get; }
		public int Width { get; }
		public Action<IItem, IntVector2> OnStartMoving { get; set; } 

		public Board(int width, int height)
		{
			Width = width;
			Height = height;
			cells = new Cell[width, height];
			ForEachCell((x, y) => cells[x, y] = new Cell());
		}

		public void FillInstantly(params Func<IItem>[] factories)
		{
			if (!factories.Any()) {
				throw new ArgumentException("factories");
			}
			ForEachCell(cell => cell.Item = factories.Random().Invoke());
		}

		public void Fill(params Func<IItem>[] factories)
		{
			if (!factories.Any()) {
				throw new ArgumentException("factories");
			}
			ForEachCell(pos => {
				var item = factories.Random().Invoke();
				item.Target = this[pos];
				item.State = ItemState.Moving;
				OnStartMoving(item, pos);
			});
		}

		public Cell this[IntVector2 position]
		{
			get { return cells[position.X, position.Y]; }
		}

		public void ForEachCell(Action<Cell> action)
		{
			for (var x = 0; x < Width; x++)
				for (var y = 0; y < Height; y++)
					action(cells[x, y]);
		}

		public void ForEachCell(Action<IntVector2> action)
		{
			for (var x = 0; x < Width; x++)
				for (var y = 0; y < Height; y++)
					action(new IntVector2(x, y));
		}

		public void ForEachCell(Action<int, int> action)
		{
			for (var x = 0; x < Width; x++)
				for (var y = 0; y < Height; y++)
					action(x, y);
		}
	}
}