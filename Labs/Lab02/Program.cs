using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			int taskNum;
			string str;
			int x = 0, y = 0;
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			str = Console.ReadLine();
			taskNum = Int32.Parse(str);
			switch (taskNum)
			{
				case 1:
					//Task 1
					Console.WriteLine("Задание 1:");
					int x1 = 0;
					Console.WriteLine(x1);
					break;
				case 2:
					//Task 2
					Console.WriteLine("Задание 2:");
					string str1;
					Console.WriteLine("Ваше имя?");
					str1 = Console.ReadLine();
					string str2 = "Привет, " + str1;
					Console.WriteLine(str2);

					break;
				case 3:
					//Task 3
					Console.WriteLine("Задание 3:");
					var v1 = 'v';
					v1 = 'f';
					Console.WriteLine(v1);
					break;
				case 4:
					//Task 4
					Console.WriteLine("Задание 4:");
					Console.Write("Введите сторону квадрата:\t");
					str = Console.ReadLine();
					x = Convert.ToInt32(str);
					Console.WriteLine("Периметр квадрата = " + x * 4);
					break;
				case 5:
					//Task 5
					Console.WriteLine("Задание 5:");
					Console.Write("Введите X:\t");
					str = Console.ReadLine();
					x = Int32.Parse(str);
					Console.Write("Введите Y:\t");
					str = Console.ReadLine();
					y = Int32.Parse(str);
					Console.WriteLine("AVG(" + x + ", " + y + ") = " + ((x + y) / 2));
					break;
				case 6:
					//Task 6
					Console.WriteLine("Задание 6:");
					int r1 = x > y ? x : y;
					int r2 = x > y ? y : x;

					double s1, s2, s3;

					Console.WriteLine("Круги:\n\tРадиус 1 = " + r1 + "\n\tРадиус 2 = " + r2);

					s1 = Math.PI * r1 * r1;
					s2 = Math.PI * r2 * r2;
					s3 = s1 - s2;

					Console.WriteLine("\n\tПлощадь 1 = " + s1 + "\n\tПлощадь 2 = " + s2 + "\n\tПлощадь 1-2 = " + s3);
					break;
				case 7:
					Console.WriteLine("Задание 7:");
					x = 45;
					Console.WriteLine("Число:\t" + x);
					Console.WriteLine(x % 10);
					Console.WriteLine((x / 10) % 10);
					break;
				case 8:
					Console.WriteLine("Задание 8:");
					Console.Write("Ввести количество секунд:\t");
					str = Console.ReadLine();
					int seconds = Int32.Parse(str);
					int hours = seconds / 3600;
					Console.WriteLine("Часов:\t" + hours);
					break;
				case 9:
					Console.WriteLine("Задание 9:");
					int a, b, c;
					Console.WriteLine("Введите A:\t");
					str = Console.ReadLine();
					a = Int32.Parse(str);
					Console.WriteLine("Введите B:\t");
					str = Console.ReadLine();
					b = Int32.Parse(str);
					Console.WriteLine("Введите C:\t");
					str = Console.ReadLine();
					c = Int32.Parse(str);
					if (a < c)
					{
						x = a;
						a = c;
						c = x;
					}
					Console.WriteLine("Утверждение " + b + " между " + a + " и " + c + (a >= b && b >= c ? " истинно" : " ложно"));
					break;
				case 10:
					Console.WriteLine("Задание 10:");
					Console.WriteLine("Введите X:\t");
					str = Console.ReadLine();
					x = Int32.Parse(str);
					bool statement = ((x % 2) != 0) && ((x > -1000 && x <= -100) || (x < 1000 && x >= 100));
					Console.WriteLine(x + " - нечётное трёхзначное. Утверждение " + (statement ? "истинно" : "ложно"));
					break;
				case 11:
					Console.WriteLine("Задание 11:");
					x = rnd.Next();
					y = rnd.Next();
					long z = x + y;
					Console.WriteLine(x + " + " + y + " == " + z);
					break;
				case 12:
					Console.WriteLine("Задание 12:");
					long l1 = rnd.Next(255);
					long l2 = rnd.Next(255);
					byte b1 = (byte)(l1 * l2);
					Console.WriteLine("(byte)(" + l1 + " * " + l2 + ") == " + b1);
					break;
			}
			Console.ReadKey();
		}
	}
}
