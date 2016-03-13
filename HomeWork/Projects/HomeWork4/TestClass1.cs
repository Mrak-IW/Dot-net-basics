using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork4
{
	class TestClass1
	{
		[Color(ConsoleColor.Yellow)]
		public string YellowProp { get; set; }

		[Color(ConsoleColor.Red)]
		public string RedProp { get; set; }

		public TestClass1(string redProp, string yellowProp)
		{
			RedProp = redProp;
			YellowProp = yellowProp;
		}
	}
}
