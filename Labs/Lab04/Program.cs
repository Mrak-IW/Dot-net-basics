using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
	enum Operation
	{
		add,
		sub,
		mul,
		div
	}
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
						Hello();
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						double a, P, S;
						Console.WriteLine("Введите сторону треуглоьника");
						a = double.Parse(Console.ReadLine());
						TrianglePS(a, out P, out S);
						Console.WriteLine("Сторона треугольника:\t{0}\nПериметр:\t\t{1}\nПлощадь:\t\t{2}", a, P, S);
					}
					break;
				case 6:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int x = rnd.Next(255);
						int y = rnd.Next(255);
						Console.WriteLine("X = {0}\tY = {1}", x, y);
						Console.WriteLine("Помещаем в X min({0}, {1}), а в Y max({0}, {1})", x, y);
						MinMax(ref x, ref y);
						Console.WriteLine("X = {0}\tY = {1}", x, y);
					}
					break;
				case 7:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int[] arr = new int[rnd.Next(2, 10)];
						Console.Write("Входные параметры:\narr = {");
						for (int i = 0; i < arr.Length; i++)
						{
							arr[i] = i;
							Console.Write(i + "; ");
						}
						Console.WriteLine("\b\b}");
						Console.WriteLine("Sum(arr) = {0}", Sum(arr));
						Console.WriteLine("Sum(1, -15) = {0}", Sum(1, -15));

					}
					break;
				case 8:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int k = rnd.Next(-9999, 9999);
						Console.WriteLine("Сумма цифр числа {0} = {1}", k, DigitSum(k));
					}
					break;
				case 9:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int a = rnd.Next(1, 100);
						int b = rnd.Next(1, 100);
						Operation op = (Operation)rnd.Next(3);
						Console.WriteLine("{0}({1}, {2}) = {3}", op, a, b, DoOperation(a, b, op));
					}
					break;
				case 10:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Goods[] arr = new Goods[3];
						System.DateTime today = System.DateTime.Today;
						arr[0].name = "Козюля";
						arr[0].providerName = "Вася";
						arr[0].receievingDate = today;
						arr[0].expiringDate = today + new System.TimeSpan(20, 0, 0, 0);

						arr[1] = new Goods { name = "Шишка", providerName = "Лес", receievingDate = today, expiringDate = today + new System.TimeSpan(365, 0, 0, 0) };
						arr[2] = new Goods("Белка", "Другая белка", today, today + new System.TimeSpan(365 * 4, 0, 0, 0));
						for (int i = 0; i < arr.Length; i++)
						{
							Console.WriteLine(arr[i] + "\n");
						}
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

		static void MinMax(ref int X, ref int Y)
		{
			if (X > Y)
			{
				int buf = X;
				X = Y;
				Y = buf;
			}
		}

		static int Sum(params int[] args)
		{
			int sum = 0;
			for (int i = 0; i < args.Length; i++)
			{
				sum += args[i];
			}
			return sum;
		}

		static int DigitSum(int k)
		{
			if (k < 0)
			{
				k = -k;
			}

			if (k < 10)
			{
				return k;
			}
			else
			{
				return k % 10 + DigitSum(k / 10);
			}
		}

		static double DoOperation(double arg1, double arg2, Operation operation)
		{
			double res = 0;
			switch (operation)
			{
				case Operation.add:
					res = arg1 + arg2;
					break;
				case Operation.sub:
					res = arg1 - arg2;
					break;
				case Operation.mul:
					res = arg1 * arg2;
					break;
				case Operation.div:
					res = arg1 / arg2;
					break;
			}
			return res;
		}
	}
}
