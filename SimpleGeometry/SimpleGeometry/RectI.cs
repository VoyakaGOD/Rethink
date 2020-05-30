using System;

namespace SimpleGeometry
{
	public struct RectI : IEquatable<RectI>
	{
		public int Left;
		public int Top;
		public int Width;
		public int Height;

		public VectorI Position => new VectorI(Left, Top);

		public VectorI Size => new VectorI(Width, Height);

		public VectorI Center => new VectorI(Left + Width / 2, Top + Height / 2);

		public VectorI Min => new VectorI(MinX, MinY);

		public VectorI Max => new VectorI(MaxX, MaxY);

		public int MaxX => Math.Max(Left, Left + Width);

		public int MinX => Math.Min(Left, Left + Width);

		public int MaxY => Math.Max(Top, Top + Height);

		public int MinY => Math.Min(Top, Top + Height);

		public RectI(int left, int top, int width, int height)
		{
			Left = left;
			Top = top;
			Width = width;
			Height = height;
		}

		public RectI(VectorI position, VectorI size) : this(position.X, position.Y, size.X, size.Y) { }

		public bool Contains(int x, int y) => (x >= MinX) && (x <= MaxX) && (y >= MinY) && (y <= MaxY);

		public bool Contains(VectorI point) => Contains(point.X, point.Y);

		public bool IsIntersects(RectI other) => (MaxX >= other.MinX) && (other.MaxX >= MinX) && (MaxY >= other.MinY) && (other.MaxY >= MinY);

		public bool IsIntersects(RectI rect, out RectI overlap)
		{
			int maxX = Math.Min(MaxX, rect.MaxX);
			int minX = Math.Max(MinX, rect.MinX);
			int maxY = Math.Min(MaxY, rect.MaxY);
			int minY = Math.Max(MinY, rect.MinY);
			overlap = new RectI(minX, minY, maxX - minX, maxY - minY);
			return (overlap.Width >= 0) && (overlap.Height >= 0);
		}

		public override string ToString() => "(" + Left + ";" + Top + ") " + Width + "x" + Height;

		public bool Equals(RectI other) => (Max == other.Max) && (Min == other.Min);

		public override bool Equals(object obj) => (obj is RectI) && Equals((RectI)obj);

		public override int GetHashCode() => ((558129636 ^ Min.GetHashCode()) * 316916111) ^ Max.GetHashCode();

		public static bool operator ==(RectI left, RectI right) => left.Equals(right);

		public static bool operator !=(RectI left, RectI right) => !left.Equals(right);

		public static implicit operator RectI(RectF rect) => new RectI((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height);
	}
}
