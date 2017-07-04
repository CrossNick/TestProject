using System;
using TestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TwoTriangles()
		{
			Triangle tr1 = new Triangle(new Point(0, 0), new Point(0, 5), new Point(5, 0));
			Triangle tr2 = new Triangle(new Point(1, 1), new Point(1, -4), new Point(-4, 1));

			var result = tr1.Intersect(tr2);

			Assert.AreEqual(result.Count, 2);
			Assert.IsTrue(result[0].Equals(new Point(0, 1)));
			Assert.IsTrue(result[1].Equals(new Point(1, 0)));
		}

		[TestMethod]
		public void NestedTriangles()
		{
			Triangle tr1 = new Triangle(new Point(0, 0), new Point(0, 5), new Point(5, 0));
			Triangle tr2 = new Triangle(new Point(1, 1), new Point(1, 3), new Point(3, 1));

			var result = tr1.Intersect(tr2);

			Assert.AreEqual(result.Count, 0);
		}
		[TestMethod]
		public void TrianglesWithCommonPoint()
		{
			Triangle tr1 = new Triangle(new Point(0, 0), new Point(0, 5), new Point(5, 0));
			Triangle tr2 = new Triangle(new Point(0, 0), new Point(-5, 0), new Point(0, -5));

			var result = tr1.Intersect(tr2);

			Assert.AreEqual(result.Count, 1);
			Assert.IsTrue(result[0].Equals(new Point(0, 0)));
		}

		[TestMethod]
		public void TwoSquares()
		{
			Square sq1 = new Square(new Point(0, 0), new Point(5, 5));
			Square sq2 = new Square(new Point(2, 2), new Point(7, 7));

			var result = sq1.Intersect(sq2);

			Assert.AreEqual(result.Count, 2);
			Assert.IsTrue(result[0].Equals(new Point(2, 5)));
			Assert.IsTrue(result[1].Equals(new Point(5, 2)));
		}

		[TestMethod]
		public void NestedSquares()
		{
			Square sq1 = new Square(new Point(0, 0), new Point(5, 5));
			Square sq2 = new Square(new Point(2, 2), new Point(3, 3));

			var result = sq1.Intersect(sq2);

			Assert.AreEqual(result.Count, 0);
		}

		[TestMethod]
		public void SquaresWithCommonSides()
		{
			Square sq1 = new Square(new Point(0, 0), new Point(5, 5));
			Square sq2 = new Square(new Point(2, 2), new Point(5, 5));

			var result = sq1.Intersect(sq2);

			Assert.AreEqual(result.Count, 3);
			Assert.IsTrue(result[0].Equals(new Point(2, 5)));
			Assert.IsTrue(result[1].Equals(new Point(5, 5)));
			Assert.IsTrue(result[2].Equals(new Point(5, 2)));

		}

		[TestMethod]
		public void TwoCircles()
		{
			Circle cr1 = new Circle(new Point(0, 2), 3);
			Circle cr2 = new Circle(new Point(0, -2), 3);

			var result = cr1.Intersect(cr2);

			Assert.AreEqual(result.Count, 2);
			Assert.IsTrue(result[0].Equals(new Point(-2.236, 0)));
			Assert.IsTrue(result[1].Equals(new Point(2.236, 0)));
		}

		[TestMethod]
		public void NestedCircles()
		{
			Circle cr1 = new Circle(new Point(0, 0), 3);
			Circle cr2 = new Circle(new Point(0, 0), 1);

			var result = cr1.Intersect(cr2);

			Assert.AreEqual(result.Count, 0);
		}

		[TestMethod]
		public void TouchingCircles()
		{
			Circle cr1 = new Circle(new Point(0, 2), 2);
			Circle cr2 = new Circle(new Point(0, -2), 2);

			var result = cr1.Intersect(cr2);

			Assert.AreEqual(result.Count, 1);
			Assert.IsTrue(result[0].Equals(new Point(0, 0)));
		}


		[TestMethod]
		public void CircleAndSquare()
		{
			Circle cr = new Circle(new Point(0, 0), 2);
			Square sq = new Square(new Point(-2, -2), new Point(2, 2));

			var result = cr.Intersect(sq);

			Assert.AreEqual(result.Count, 4);
			Assert.IsTrue(result[0].Equals(new Point(-2, 0)));
			Assert.IsTrue(result[1].Equals(new Point(0, 2)));
			Assert.IsTrue(result[2].Equals(new Point(2, 0)));
			Assert.IsTrue(result[3].Equals(new Point(0, -2)));
		}

		[TestMethod]
		public void SquareAndCircle()
		{
			Circle cr = new Circle(new Point(0, 0), 2.5);
			Square sq = new Square(new Point(-2, -2), new Point(2, 2));

			var result = cr.Intersect(sq);

			Assert.AreEqual(result.Count, 8);
			Assert.IsTrue(result[0].Equals(new Point(-2, -1.5)));
			Assert.IsTrue(result[1].Equals(new Point(-2, 1.5)));
			Assert.IsTrue(result[2].Equals(new Point(-1.5, 2)));
			Assert.IsTrue(result[3].Equals(new Point(1.5, 2)));
			Assert.IsTrue(result[4].Equals(new Point(2, -1.5)));
			Assert.IsTrue(result[5].Equals(new Point(2, 1.5)));
			Assert.IsTrue(result[6].Equals(new Point(-1.5, -2)));
			Assert.IsTrue(result[7].Equals(new Point(1.5, -2)));
		}

		[TestMethod]
		public void TriangleAndCircle()
		{
			Circle cr = new Circle(new Point(0, 0), 2.5);
			Triangle tr = new Triangle(new Point(-2, -2), new Point(2, -2), new Point(0, 2));

			var result = cr.Intersect(tr);

			Assert.AreEqual(result.Count, 4);
			Assert.IsTrue(result[0].Equals(new Point(-1.5, -2)));
			Assert.IsTrue(result[1].Equals(new Point(1.5, -2)));
			Assert.IsTrue(result[2].Equals(new Point(1.844, -1.688)));
			Assert.IsTrue(result[3].Equals(new Point(-1.844, -1.688)));
			
		}

		[TestMethod]
		public void TriangleCrossesCircle()
		{
			Circle cr = new Circle(new Point(3, 0), 2.5);
			Triangle tr = new Triangle(new Point(0, 0), new Point(0, 5), new Point(5, 0));

			var result = cr.Intersect(tr);

			Assert.AreEqual(result.Count, 2);
			Assert.IsTrue(result[0].Equals(new Point(2.543, 2.458)));
			Assert.IsTrue(result[1].Equals(new Point(0.5, 0)));
		}

		[TestMethod]
		public void SquareTouchesCircle()
		{
			Circle cr = new Circle(new Point(2, 0), 2);
			Square sq = new Square(new Point(-4, -2), new Point(0, 2));

			var result = cr.Intersect(sq);

			Assert.AreEqual(result.Count, 1);
			Assert.IsTrue(result[0].Equals(new Point(0, 0)));
		}

		[TestMethod]
		public void SquareAndTriangle()
		{
			Square sq = new Square(new Point(-1.5, -1.5), new Point(1.5, 1.5));
			Triangle tr = new Triangle(new Point(-2, -2), new Point(2, -2), new Point(0, 2));

			var result = sq.Intersect(tr);

			Assert.AreEqual(result.Count, 4);
			Assert.IsTrue(result[0].Equals(new Point(-1.5, -1)));
			Assert.IsTrue(result[1].Equals(new Point(0.25, 1.5)));
			Assert.IsTrue(result[2].Equals(new Point(-0.25, 1.5)));
			Assert.IsTrue(result[3].Equals(new Point(1.5, -1)));
		}
	}
}
