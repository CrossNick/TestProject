using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public class Point : ICloneable, IEquatable<Point>
	{
		public double X { get; set; }
		public double Y { get; set; }
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}
		public object Clone()
		{
			return new Point(X, Y);
		}
		public Point Rotate(double angle)
		{
			double newX = Math.Round(X * Math.Cos(angle) + Y * Math.Sin(angle),3);
			double newY = Math.Round(-1*X * Math.Sin(angle) + Y * Math.Cos(angle),3);
			return new Point(newX, newY);
		}
		public bool Equals(Point other)
		{
			return X == other.X && Y == other.Y;
		}
	}
}
