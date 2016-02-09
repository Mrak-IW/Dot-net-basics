using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
	public class Storage
	{
		public int FirstArgument { get; set; }
		public int SecondArgument { get; set; }
	}

	public static class Extensions
	{
		public static int Add(this Storage stor)
		{
			return stor.FirstArgument + stor.SecondArgument;
		}

		public static int Sub(this Storage stor)
		{
			return stor.FirstArgument - stor.SecondArgument;
		}
	}
}
