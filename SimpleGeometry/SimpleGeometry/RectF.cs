using System;

namespace SimpleGeometry
{
	public struct RectF : IEquatable<RectF>
	{
		public float Left;
		public float Top;
		public float Width;
		public float Height;

		public VectorF Position => new VectorF(Left, Top);

		public VectorF Size => new VectorF(Width, Height);

		public VectorF Center => new VectorF(Left + Width / 2, Top + Height / 2);

		public VectorF Min => new VectorF(MinX, MinY);

		public VectorF Max => new VectorF(MaxX, MaxY);

		public float MaxX => Math.Max(Left, Left + Width);

		public float MinX => Math.Min(Left, Left + Width);

		public float MaxY => Math.Max(Top, Top + Height);

		public float MinY => Math.Min(Top, Top + Height);

		public RectF(float left, float top, float width, float height)
		{
			Left = left;
			Top = top;
			Width = width;
			Height = height;
		}

		public RectF(VectorF position, VectorF size) : this(position.X, position.Y, size.X, size.Y) { }

		public bool Contains(float x, float y) => (x >= MinX) && (x <= MaxX) && (y >= MinY) && (y <= MaxY);

		public bool Contains(VectorF point) => Contains(point.X, point.Y);

		public bool IsIntersects(RectF other) => (MaxX >= other.MinX) && (other.MaxX >= MinX) && (MaxY >= other.MinY) && (other.MaxY >= MinY);

		public bool IsIntersects(RectF rect, out RectF overlap)
		{
			float maxX = Math.Min(MaxX, rect.MaxX);
			float minX = Math.Max(MinX, rect.MinX);
			float maxY = Math.Min(MaxY, rect.MaxY);
			float minY = Math.Max(MinY, rect.MinY);
			overlap = new RectF(minX, minY, maxX - minX, maxY - minY);
			return (overlap.Width >= 0) && (overlap.Height >= 0);
		}

		public override string ToString() => "(" + Left + ";" + Top + ") " + Width + "x" + Height;

		public bool Equals(RectF other) => (Max == other.Max) && (Min == other.Min);

		public override bool Equals(object obj) => (obj is RectF) && Equals((RectF)obj);

		public override int GetHashCode() => ((558129636 ^ Min.GetHashCode()) * 316916111) ^ Max.GetHashCode();

		public static bool operator ==(RectF left, RectF right) => left.Equals(right);

		public static bool operator !=(RectF left, RectF right) => !left.Equals(right);

		public static implicit operator RectF(RectI rect) => new RectF(rect.Left, rect.Top, rect.Width, rect.Height);
	}
}
