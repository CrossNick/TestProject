using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public abstract class BasicShape
	{
		public abstract List<Point> Intersect(Segment other);
        public List<Point> Intersect(BasicShape other)
		{
			List<Point> res = new List<Point>();
			if (this is SidedShape)
			{
				foreach (var side in (this as SidedShape).GetSides())
				{
					var inters = other.Intersect(side);
					foreach (var ints in inters)
					{
						if (!res.Contains(ints)) res.Add(ints);
					}
					//res.AddRange(inters);
				}
			}
			else if (other is SidedShape)
			{
				foreach (var side in (other as SidedShape).GetSides())
				{
					var inters = Intersect(side);
					res.AddRange(inters);
				}
			}
			else
			{
				List<Point> result = new List<Point>();
				other = other as Circle;
				//Checking for similar circles
				if ((this as Circle).Center.Equals(other as Circle) && (this as Circle).Radius == (other as Circle).Radius)
					return result;

				double dist = (new Segment((this as Circle).Center, (other as Circle).Center)).Length;
				//If the circles does not intersect
				if (dist > ((this as Circle).Radius + (other as Circle).Radius) || dist < Math.Abs((this as Circle).Radius - (other as Circle).Radius))
					return result;

				double a = ((this as Circle).Radius * (this as Circle).Radius - (other as Circle).Radius * (other as Circle).Radius + dist * dist) / (2 * dist);
				double h = Math.Sqrt((this as Circle).Radius * (this as Circle).Radius - a * a);
				Point tmp = new Point(Math.Round((this as Circle).Center.X + a * ((other as Circle).Center.X - (this as Circle).Center.X) / dist, 3),
					Math.Round((this as Circle).Center.Y + a * ((other as Circle).Center.Y - (this as Circle).Center.Y) / dist,3));
				//If the circles touch
				if (dist == (this as Circle).Radius + (other as Circle).Radius)
				{
					result.Add(tmp);
					return result;
				}

				Point inter1 = new Point(Math.Round(tmp.X + h * ((other as Circle).Center.Y - (this as Circle).Center.Y) / dist,3),
					Math.Round(tmp.Y - h * ((other as Circle).Center.X - (this as Circle).Center.X) / dist));
				Point inter2 = new Point(Math.Round(tmp.X - h * ((other as Circle).Center.Y - (this as Circle).Center.Y) / dist,3),
					Math.Round(tmp.Y + h * ((other as Circle).Center.X - (this as Circle).Center.X) / dist,3));

				
				result.Add(inter1);
				result.Add(inter2);
				return result;
			}//Case when we have two circles
			return res;
		}
	}
}
