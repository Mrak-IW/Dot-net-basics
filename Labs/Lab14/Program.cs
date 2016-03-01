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
			string fname = "fridge.ini";
			FileInfo fi = new FileInfo(fname);
			Console.WriteLine(fi.Exists ? "файл существует " + fi.Length + " байт" : "файл не найден");
			FridgeFile fr = new FridgeFile("tmp", -5, 0, -10, fname);
			//string param = fr.ReadField("Name");
			fr.ReplaceField<string>("Name", "test");
			Menu.Show();
		}
	}
}
