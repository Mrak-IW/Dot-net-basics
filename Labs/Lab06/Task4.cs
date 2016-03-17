using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
	class Rectangle
	{
		public Point Begin { get; set; }
		public Point End { get; set; }

		public Rectangle(Point begin, Point end)
		{
			this.Begin = begin;
			this.End = end;
		}

		public override string ToString()
		{
			return "{ " + Begin + ", " + End + " }";
		}

		public override bool Equals(object obj)
		{
			bool res = false;

			if (obj is Rectangle)
			{
				res = ((obj as Rectangle).Begin.Equals(this.Begin) && (obj as Rectangle).End.Equals(this.End)) ||
					((obj as Rectangle).Begin.Equals(this.End) && (obj as Rectangle).End.Equals(this.Begin));
			}

			return res;
		}

		public override int GetHashCode()
		{
			return Begin.GetHashCode() + End.GetHashCode();
		}
	}
}