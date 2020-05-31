using System;

namespace SimpleGeometry
{
	public struct VectorF : IEquatable<VectorF>
	{
		public float X;
		public float Y;

		public float SqrLength => X * X + Y * Y;

		public float Length => (float)Math.Sqrt(X * X + Y * Y);

		public VectorF Normalized => this * (1 / Length);

		public VectorF(float x, float y)
		{
			X = x;
			Y = y;
		}

		public static VectorF operator -(VectorF v) => new VectorF(-v.X, -v.Y);

		public static VectorF operator +(VectorF left, VectorF right) => new VectorF(left.X + right.X, left.Y + right.Y);

		public static VectorF operator -(VectorF left, VectorF right) => new VectorF(left.X - right.X, left.Y - right.Y);

		public static VectorF operator *(VectorF left, float right) => new VectorF(left.X * right, left.Y * right);

		public static VectorF operator *(float left, VectorF right) => new VectorF(left * right.X, left * right.Y);

		public static float operator *(VectorF left, VectorF right) => left.X * right.X + left.Y * right.Y;

		public static VectorF operator /(VectorF left, float right) => new VectorF(left.X / right, left.Y / right);

		public static bool operator ==(VectorF left, VectorF right) => left.Equals(right);

		public static bool operator !=(VectorF left, VectorF right) => !left.Equals(right);

		public override string ToString() => "{" + X + ";" + Y + "}";

		public bool Equals(VectorF other) => (Math.Abs(X - other.X) <= float.Epsilon) && (Math.Abs(Y - other.Y) <= float.Epsilon);

		public override bool Equals(object obj) => (obj is VectorF) && Equals((VectorF)obj);

		public override int GetHashCode() => ((558129636 ^ X.GetHashCode()) * 316916111) ^ Y.GetHashCode();

		public static implicit operator VectorF(VectorI v) => new VectorF(v.X, v.Y);
	}
}
