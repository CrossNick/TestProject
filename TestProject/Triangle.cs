using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public class Triangle : SidedShape
	{
		public Point A { get; set; }
		public Point B { get; set; }
		public Point C { get; set; }

		public Triangle(Point p1, Point p2, Point p3)
		{
			A = p1.Clone() as Point;
			B = p2.Clone() as Point;
			C = p3.Clone() as Point;
		}
		//Getting Sides of triangle
		public override Segment[] GetSides()
		{
			var sides = new Segment[3];
			sides[0] = new Segment(A, B);
			sides[1] = new Segment(B, C);
			sides[2] = new Segment(C, A);
			return sides;
		}
	}
}
