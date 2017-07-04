using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public class Circle : BasicShape
	{
		public Point Center { get; set; }
		public double Radius { get; set; }

		public Circle(Point p, double r)
		{
			Center = p.Clone() as Point;
			Radius = r;
		}

		//Finding Intersection points between circle and line
		public override List<Point> Intersect(Segment line)
		{
			//Rotate coordinate system to make the line be horizontal
			double angle = Math.Atan(line.Incline);
			Point cent = Center.Rotate(angle);
			Segment seg = line.Rotate(angle);
			double h = cent.Y - seg.P1.Y;

			//If distance between center and line greater than radius
			if (h > Radius) return new List<Point>(0);

			double d = Math.Sqrt(Radius * Radius - h * h);
			//Intersection points
			Point inter1 = new Point(cent.X - d, seg.P1.Y), inter2 = new Point(cent.X + d, seg.P1.Y);
			List<Point> result = new List<Point>();

			//Checking if our segment contains an intersection points
			if (seg.HasAPoint(inter1)) result.Add(inter1.Rotate(-angle));

			//Checking if the segment touches the circle
			if (inter1.X == inter2.X && inter1.Y == inter2.Y) return result;
			if (seg.HasAPoint(inter2)) result.Add(inter2.Rotate(-angle));

			return result;
		}

	}
}
