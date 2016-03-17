using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork4
{
	class TestClass2
	{
		[Color(ConsoleColor.Green)]
		public string GreenProp { get; set; }

		[Color(ConsoleColor.Cyan)]
		public string CyanProp { get; set; }

		public string DefaultProp { get; set; }

		public TestClass2(string blueProp, string cyanProp, string defaultProp)
		{
			GreenProp = blueProp;
			CyanProp = cyanProp;
			DefaultProp = defaultProp;
		}
	}
}
