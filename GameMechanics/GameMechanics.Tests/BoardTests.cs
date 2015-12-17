using System;
using Moq;
using NUnit.Framework;

namespace GameMechanics.Tests
{
	[TestFixture]
	public class BoardTests
	{
		private const int Width = 10;
		private const int Height = 10;

		[Test]
		public void BoardTest()
		{
			var board = new Board(Width, Height);
			Assert.That(board.Width, Is.EqualTo(Width));
			Assert.That(board.Height, Is.EqualTo(Height));
			board.ForEachCell((Cell c) => Assert.That(c, Is.Not.Null));
		}

		[Test]
		public void FillTest()
		{
			var board = new Board(Width, Height);
			Func<IItem> factory1 = () => new Item1();
			Func<IItem> factory2 = () => new Item2();
			board.FillInstantly(factory1, factory2);
			board.ForEachCell(c => Assert.That(c.Item, Is.TypeOf<Item1>().Or.TypeOf<Item2>()));
		}

		[Test]
		public void FillNoFactoriesTest()
		{
			var board = new Board(Width, Height);
			Assert.Throws<ArgumentException>(() => board.Fill());
		}

		private class Item1: CommonItem { }
		private class Item2 : CommonItem { }
	}
}