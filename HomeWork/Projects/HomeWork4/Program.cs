using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork4
{
	class Program
	{
		static void Main(string[] args)
		{
			TestClass1 o1 = new TestClass1("синий", "зелёный");
			TestClass2 o2 = new TestClass2("фиолетовый", "лягушка в обмороке", "серо-буро-поцарапаный");
			ColorPrinter.ColorPrint(o1);
			ColorPrinter.ColorPrint(o2);
		}
	}
}
