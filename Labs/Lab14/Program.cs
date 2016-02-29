using HomeWork2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab14
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine();
			using (FileStream file = new FileStream("fridge.ini", FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				FridgeFile fr = new FridgeFile("tmp", new Dimmer(0, -5, 1), file);
				string param = fr.ReadField("test");
			}
			Menu.Show();
		}
	}
}
