using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	public abstract class SidedShape : BasicShape
	{
		abstract public Segment[] GetSides();
		public override List<Point> Intersect(Segment line)
		{
			var result = new List<Point>();
			var sides = GetSides();
			foreach (var side in sides)
			{
				var inter = side.Intersect(line);
				if (inter != null) result.Add(inter);
			}
			return result;
		}
	}
}
