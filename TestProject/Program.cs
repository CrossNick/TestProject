using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
	class Program
	{
		static void Main(string[] args)
		{
			SelectionMenu();
            Console.ReadKey();
		}

		private static void SelectionMenu()
		{
			int selection1, selection2;
			do
			{
				Console.WriteLine("Primitives: \n1. Triangle\n2. Square\n3. Circle");
				Console.WriteLine("Please select the first primitive: ");
				selection1 = int.Parse(Console.ReadLine());
				Console.Clear();
			} while (selection1 < 1 || selection1 > 3);

			do
			{
				Console.WriteLine("Primitives: \n1. Triangle\n2. Square\n3. Circle");
				Console.WriteLine("Please select the second primitive: ");
				selection2 = int.Parse(Console.ReadLine());
				Console.Clear();
			} while (selection2 < 1 || selection2 > 3);
			OperateSelection(selection1, selection2);

		}

		private static void OperateSelection(int selection1, int selection2)
		{
			BasicShape shape1=null, shape2 = null;
			switch(selection1)
			{
				case 1:
					InitTriangle(out shape1);
                    break;
				case 2:
					InitSquare(out shape1);
                    break;
				case 3:
					InitCircle(out shape1);
					break;
			}
			switch (selection2)
			{
				case 1:
					InitTriangle(out shape2);
					break;
				case 2:
					InitSquare(out shape2);
					break;
				case 3:
					InitCircle(out shape2);
					break;
			}
			var result = shape1.Intersect(shape2);
			OperateResult(result);
        }

		private static void OperateResult(List<Point> list)
		{
			if(list.Count!=0)
			{
                Console.WriteLine("Intersection Points: ");
				foreach(Point p in list)
				{
					Console.WriteLine("X: {0} Y: {1}", p.X, p.Y);
				}
			}
			else
				Console.WriteLine("No intersection!");
		}
		private static void InitTriangle(out BasicShape shape)
		{
			Point[] points = new Point[] { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
			do
			{
				for (int i = 1; i <= 3; i++)
				{
					Console.Write("Please Input the X coordinate of Vertex {0}: ", i);
					points[i - 1].X = double.Parse(Console.ReadLine());
					Console.Write("Please Input the Y coordinate of Vertex {0}: ", i);
					points[i - 1].Y = double.Parse(Console.ReadLine());
				}
				Console.Clear();
			} while (points[0].Equals(points[1]) || points[0].Equals(points[2]) || points[2].Equals(points[1]));
			shape = new Triangle(points[0], points[1], points[2]);
		}
		private static void InitSquare(out BasicShape shape)
		{
			Point[] points = new Point[] { new Point(0, 0), new Point(0, 0) };
			do
			{
				for (int i = 1; i <= 2; i++)
				{
					Console.Write("Please Input the X coordinate of Vertex {0}: ", i);
					points[i - 1].X = double.Parse(Console.ReadLine());
					Console.Write("Please Input the Y coordinate of Vertex {0}: ", i);
					points[i - 1].Y = double.Parse(Console.ReadLine());
				}
				Console.Clear();
			} while (points[0].Equals(points[1]));
			shape = new Square(points[0], points[1]);
		}
		private static void InitCircle(out BasicShape shape)
		{
			Point p = new Point(0, 0);
			double r;
			Console.Write("Please Input the X coordinate of Center: ");
			p.X = double.Parse(Console.ReadLine());
			Console.Write("Please Input the Y coordinate of Center: ");
			p.Y = double.Parse(Console.ReadLine());
			do
			{
				Console.Write("Please Input the Radius: ");
				r = double.Parse(Console.ReadLine());
				Console.Clear();
			} while (r <= 0);
			shape = new Circle(p, r);
		}
	}
}
