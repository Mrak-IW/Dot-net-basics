using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
	class Circle
	{
		double radius;
		double x;
		double y;

		public Circle()
		{
			this.x = 0;
			this.y = 0;
			this.radius = 0;
		}

		public Circle(double x, double y, double radius)
		{
			this.x = x;
			this.y = y;
			this.radius = radius;
		}

		public double Length()
		{
			return Math.PI * this.radius * 2;
		}

		public static double Length(double radius)
		{
			return Math.PI * radius * 2;
		}

		public Circle GetCircle()
		{
			return new Circle(this.x, this.y, this.radius);
		}

		public Circle GetCircle(double x, double y, double radius)
		{
			return new Circle(x, y, radius);
		}

		public bool PointIsInCircle(double x, double y)
		{
			return (x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= this.radius * this.radius;
		}

		public override string ToString()
		{
			return "Круг (" + x + ", " + y + ") R = " + this.radius;
		}
	}
}
