using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public class Segment
	{
		public Point P1 { get; set; }
		public Point P2 { get; set; }
		public Segment(Point p1, Point p2)
		{
			P1 = p1.Clone() as Point;
			P2 = p2.Clone() as Point;
		}
		public double Incline
		{
			get
			{
				if (P1.X == P2.X) return double.MaxValue;
				else if (P1.Y == P2.Y) return 0;
				return (P2.Y - P1.Y) / (P2.X - P1.X);
			}
		}
		public double Length
		{
			get
			{
				return Math.Sqrt((P1.X - P2.X) * (P1.X - P2.X) + (P1.Y - P2.Y) * (P1.Y - P2.Y));
            }
		}
		//Finding intersection point between two lines. If in doesn't exists - returns null
		public Point Intersect(Segment other)
		{
			double denom = getDenominator(other);
			//Checking for lines to not being parallel
			if(denom!=0.0)
			{
				double interX = getIntersectedX(other, denom);
				double interY = getIntersectedY(other, denom);
				var result = new Point(interX, interY);
				if (HasAPoint(result) && other.HasAPoint(result))
					return result;
			}
			return null;
		}
		private double getDenominator(Segment other)
		{
			return (P1.X - P2.X) * (other.P1.Y - other.P2.Y) - (P1.Y - P2.Y) * (other.P1.X - other.P2.X);
		}
		private double getIntersectedX(Segment other, double denom)
		{
			return ((P1.X * P2.Y - P1.Y * P2.X) * (other.P1.X - other.P2.X) - (P1.X - P2.X) * (other.P1.X * other.P2.Y - other.P1.Y * other.P2.X))/denom;
		}
		private double getIntersectedY(Segment other, double denom)
		{
			return ((P1.X * P2.Y - P1.Y * P2.X) * (other.P1.Y - other.P2.Y) - (P1.Y - P2.Y) * (other.P1.X * other.P2.Y - other.P1.Y * other.P2.X)) / denom;
		}
		public bool HasAPoint(Point p)
		{
			double x1 = Math.Min(P1.X, P2.X), x2 = Math.Max(P1.X, P2.X);
			double y1 = Math.Min(P1.Y, P2.Y), y2 = Math.Max(P1.Y, P2.Y);
			return p.X >= x1 && p.X <= x2 && p.Y >= y1 && p.Y <= y2;
		}

		public Segment Rotate(double angle)
		{
			return new Segment(P1.Rotate(angle), P2.Rotate(angle));
		}

	}
}
