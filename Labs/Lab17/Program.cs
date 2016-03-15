using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			string taskNum = Console.ReadLine();
			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;

				case "1":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Menu.Show();
					}
					break;
			}
		}
	}
}
