using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
	abstract class GeoFigure
	{
		public abstract Point Center
		{
			get;
			set;
		}

		public abstract void Draw();
	}

	class GeoCircle : GeoFigure
	{
		double radius;
		Point center;

		public GeoCircle(double x, double y, double radius)
		{
			this.center.x = x;
			this.center.y = y;
			this.radius = radius;
		}

		public override string ToString()
		{
			return "Круг (" + this.center.x + ", " + this.center.y + ") R = " + this.radius;
		}

		public override void Draw()
		{
			Console.WriteLine(this.ToString());
		}

		public override Point Center
		{
			get
			{
				return this.center;
			}
			set
			{
				this.center = value;
			}
		}
	}

	class GeoTriangle : GeoFigure
	{
		public Point[] vertex;
		public GeoTriangle(params Point[] vertex)
		{
			if (vertex == null || vertex.Length != 3)
			{
				return;
			}

			this.vertex = new Point[vertex.Length];

			for (int i = 0; i < vertex.Length; i++)
			{
				this.vertex[i] = vertex[i];
			}
		}

		public override Point Center
		{
			get
			{
				Point center = new Point();
				center.x = (vertex[0].x + vertex[1].x + vertex[2].x) / 3;
				center.y = (vertex[0].y + vertex[1].y + vertex[2].y) / 3;
				return center;
			}
			set { }
		}

		public override void Draw()
		{
			string res = "Треугольник: ";
			for (int i = 0; i < this.vertex.Length; i++)
			{
				res = res + "(" + vertex[i].x + ", " + vertex[i].y + "); ";
			}
			Console.WriteLine(res);
		}
	}
}
