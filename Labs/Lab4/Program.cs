using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
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
				case 1:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Hello();
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						double a, P ,S;
						Console.WriteLine("Введите сторону треуглоьника");
						a = double.Parse(Console.ReadLine());
						TrianglePS(a, out P, out S);
						Console.WriteLine("Сторона треугольника:\t{0}\nПериметр:\t\t{1}\nПлощадь:\t\t{2}", a, P, S);
					}
					break;
				case 6:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
				case 7:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
			}
		}

		static void Hello()
		{
			string name;
			Console.WriteLine("Как тебя зовут?");
			name = Console.ReadLine();
			Console.WriteLine("Привет, {0}", name);
		}

		static void TrianglePS(double a, out double P, out double S)
		{
			P = 3 * a;
			S = a * a * Math.Sqrt(3) / 4;
		}
	}
}
