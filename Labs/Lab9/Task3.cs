using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
	class Task3
	{
		private int a;
		private int b;
		private int c;

		public int this[int i]
		{
			get
			{
				int result;
				switch (i)
				{
					case 0:
						result = a;
						break;
					case 1:
						result = b;
						break;
					default:
						result = c;
						break;
				}
				return result;
			}
			set {
				switch (i)
				{
					case 0:
						a = value;
						break;
					case 1:
						b = value;
						break;
					default:
						c = value;
						break;
				}
			}
		}
	}
}
