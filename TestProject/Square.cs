using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public class Square : SidedShape
	{
		public Point A { get; set; }
		public Point C { get; set; }

		public Square(Point p1, Point p2)
		{
			A = p1.Clone() as Point;
			C = p2.Clone() as Point;
		}

		//Getting sides of Square
		public override Segment[] GetSides()
		{
			//Finding coordinates of other vertexes
			Segment diag = new Segment(A, C);
			double angle = Math.Atan(diag.Incline);
			//Rotate coordinate system to make the diagonal be horizontal
			Segment seg = diag.Rotate(angle);
			Point B = (new Point((seg.P1.X + seg.P2.X) / 2, seg.P1.Y + seg.Length / 2)).Rotate(-angle);
			Point D = (new Point((seg.P1.X + seg.P2.X) / 2, seg.P1.Y - seg.Length / 2)).Rotate(-angle);
			Segment[] segs = new Segment[4];
			segs[0] = new Segment(A, B);
			segs[1] = new Segment(B, C);
			segs[2] = new Segment(C, D);
			segs[3] = new Segment(D, A);
			return segs;
		}
	}
}
