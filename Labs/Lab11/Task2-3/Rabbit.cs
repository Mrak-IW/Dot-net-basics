using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab11.Task2_3
{
	class Rabbit
	{
		public event Observe WhereAreYou;

		private int x;
		private int y;

		public void Jump()
		{
			Random rnd = new Random();
			x = rnd.Next(99);
			y = rnd.Next(99);

			if (WhereAreYou != null)
			{
				WhereAreYou(x, y);
			}
		}
	}
}
