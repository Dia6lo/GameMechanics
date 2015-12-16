using System;

namespace GameMechanics
{
	public struct IntVector2 : IEquatable<IntVector2>
	{
		public int X;
		public int Y;

		/// <summary>
		///     Returns a vector with components 0, 0.
		/// </summary>
		public static readonly IntVector2 Zero = new IntVector2(0, 0);

		/// <summary>
		///     Returns a vector with components 1, 1.
		/// </summary>
		public static readonly IntVector2 One = new IntVector2(1, 1);

		/// <summary>
		///     Returns a vector with components 0, -1.
		/// </summary>
		public static readonly IntVector2 Up = new IntVector2(0, -1);

		/// <summary>
		///     Returns a vector with components 0, 1.
		/// </summary>
		public static readonly IntVector2 Down = new IntVector2(0, 1);

		/// <summary>
		///     Returns a vector with components -1, 0.
		/// </summary>
		public static readonly IntVector2 Left = new IntVector2(-1, 0);

		/// <summary>
		///     Returns a vector with components 1, 0.
		/// </summary>
		public static readonly IntVector2 Right = new IntVector2(1, 0);

		public IntVector2(int x, int y)
		{
			X = x;
			Y = y;
		}

		public bool Equals(IntVector2 other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			return obj is IntVector2 && Equals((IntVector2) obj);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public static bool operator ==(IntVector2 lhs, IntVector2 rhs)
		{
			return lhs.X == rhs.X && lhs.Y == rhs.Y;
		}

		public static bool operator !=(IntVector2 lhs, IntVector2 rhs)
		{
			return lhs.X != rhs.X || lhs.Y != rhs.Y;
		}

		public static IntVector2 operator +(IntVector2 lhs, IntVector2 rhs)
		{
			return new IntVector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}

		public static IntVector2 operator -(IntVector2 lhs, IntVector2 rhs)
		{
			return new IntVector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
		}

		public static IntVector2 operator -(IntVector2 value)
		{
			return new IntVector2(-value.X, -value.Y);
		}

		public static IntVector2 operator /(IntVector2 lhs, int rhs)
		{
			return new IntVector2(lhs.X / rhs, lhs.Y / rhs);
		}

		public static IntVector2 operator *(int lhs, IntVector2 rhs)
		{
			return new IntVector2(lhs * rhs.X, lhs * rhs.Y);
		}

		public static IntVector2 operator *(IntVector2 lhs, int rhs)
		{
			return new IntVector2(rhs * lhs.X, rhs * lhs.Y);
		}

		public override string ToString()
		{
			return string.Format("{0}, {1}", X, Y);
		}
	}
}