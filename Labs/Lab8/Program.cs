using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
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
					Console.WriteLine("Задание с таким номером не реализовано.");
					break;
				case 1:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int a = 10;
						int b = 5;
						Console.WriteLine("{0} + {1} = {2}", a, b, Arithmetics.Add(a, b));
						Console.WriteLine("{0} - {1} = {2}", a, b, Arithmetics.Sub(a, b));
						Console.WriteLine("{0} * {1} = {2}", a, b, Arithmetics.Mul(a, b));
						Console.WriteLine("{0} / {1} = {2}", a, b, Arithmetics.Div(a, b));
					}
					break;
				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						ConstAndReadOnly cro = new ConstAndReadOnly(1);
						Console.WriteLine("cro.id = " + cro.id);
						Console.WriteLine("ConstAndReadOnly.E = " + ConstAndReadOnly.E);
						//cro.id = 2;
						//ConstAndReadOnly.E = 2;
					}
					break;
				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Liquid l1 = new Liquid(10);
						Liquid l2 = new Liquid(5, "Бензин", "Хлорка");
						Console.WriteLine(l1 + l2);
						Console.WriteLine(l1 / 5);
						Console.WriteLine((l1 + l2) / 5);
						Console.WriteLine(l1);
						Console.WriteLine(l2);
						Console.WriteLine(l2 + (l2 + l1));
					}
					break;
				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Storage s = new Storage();
						s.FirstArgument = 10;
						s.SecondArgument = 3;
						Console.WriteLine("{0} + {1} = {2}", s.FirstArgument, s.SecondArgument, s.Add());
						Console.WriteLine("{0} - {1} = {2}", s.FirstArgument, s.SecondArgument, s.Sub());
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Array<int> a = new Array<int>(1, 2, 3, 4);
						Console.WriteLine(a);

						Array<double> b = new Array<double>(1.0, 2.5, 3.6, -4);
						Console.WriteLine(b);
					}
					break;
			}
		}
	}
}
