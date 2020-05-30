using System;

namespace SimpleGeometry
{
	public struct VectorI : IEquatable<VectorI>
	{
		public int X;
		public int Y;

		public VectorI(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int SqrLength()
		{
			return X * X + Y * Y;
		}

		public float Length()
		{
			return (float)Math.Sqrt(X * X + Y * Y);
		}

		public VectorI Normalized()
		{
			return this * (1 / Length());
		}

		public static VectorI operator -(VectorI v) => new VectorI(-v.X, -v.Y);

		public static VectorI operator +(VectorI left, VectorI right) => new VectorI(left.X + right.X, left.Y + right.Y);

		public static VectorI operator -(VectorI left, VectorI right) => new VectorI(left.X - right.X, left.Y - right.Y);

		public static VectorI operator *(VectorI left, float right) => new VectorI((int)(left.X * right), (int)(left.Y * right));

		public static VectorI operator *(float left, VectorI right) => new VectorI((int)(left * right.X), (int)(left * right.Y));

		public static int operator *(VectorI left, VectorI right) => left.X * right.X + left.Y * right.Y;

		public static VectorI operator /(VectorI left, float right) => new VectorI((int)(left.X / right), (int)(left.Y / right));

		public static bool operator ==(VectorI left, VectorI right) => left.Equals(right);

		public static bool operator !=(VectorI left, VectorI right) => !left.Equals(right);

		public override string ToString() => "{" + X + ";" + Y + "}";

		public bool Equals(VectorI other) => (X == other.X) && (Y == other.Y);

		public override bool Equals(object obj) => (obj is VectorI) && Equals((VectorI)obj);

		public override int GetHashCode() => ((558129636 ^ X) * 316916111) ^ Y;

		public static implicit operator VectorI(VectorF v) => new VectorI((int)v.X, (int)v.Y);
	}
}
