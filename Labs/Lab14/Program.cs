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
			Menu.Show();
		}
	}
}
