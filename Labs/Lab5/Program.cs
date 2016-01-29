using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			int taskNum = Int32.Parse(Console.ReadLine());
			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;
				case 1:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						
					}
					break;
			}
		}
	}
}
