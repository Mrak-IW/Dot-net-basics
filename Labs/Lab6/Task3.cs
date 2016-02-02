using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
	class Square
	{
		public int sideLength { get; set; }

		public Square(int side)
		{
			this.sideLength = side;
		}

		public virtual int Perimeter
		{
			get
			{
				return this.sideLength * 4;
			}
		}

		public override string ToString()
		{
			return "Квадрат со стороной " + this.sideLength + " и периметром " + this.Perimeter;
		}
	}

	class Qube : Square
	{
		public Qube(int side)
			: base(side)
		{ }

		public override int Perimeter
		{
			get
			{
				return sideLength * 12;
			}
		}

		public override string ToString()
		{
			return "Куб со стороной " + this.sideLength + " и периметром " + this.Perimeter;
		}
	}
}
