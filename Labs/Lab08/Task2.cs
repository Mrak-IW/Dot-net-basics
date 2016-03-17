using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	class ConstAndReadOnly
	{
		public const double E = 2.71828;
		public readonly int id;
		public ConstAndReadOnly(int id)
		{
			this.id = id;
		}
	}
}
