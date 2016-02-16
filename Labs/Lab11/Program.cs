using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab11.Task1;
using Lab11.Task2_3;

namespace Lab11
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
						TPing ping = new TPing();
						TPong pong = new TPong();
						ping.RegisterDelegate(pong.Pong);
						pong.RegisterDelegate(ping.Ping);
						ping.Ping();
					}
					break;
				case 2:
				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Rabbit r = new Rabbit();
						Hunter h = new Hunter();
						r.WhereAreYou += h.LocateRabbit;
						r.WhereAreYou += delegate(int x, int y)
						{
							Console.WriteLine("Аноним: целюсь в зайца по координатам ({0}; {1})", x, y);
						};
						r.WhereAreYou += (int x, int y) => Console.WriteLine("Лямбда: Nuclerar launch detected. Approximate destination is ({0}; {1})", x, y);
						Console.WriteLine("Для прыжка нажмите любую клавишу. Для выхода - Escape.");
						while (Console.ReadKey().Key != ConsoleKey.Escape)
						{
							Console.Write("\b\n");
							r.Jump();
						}
					}
					break;
			}
		}
	}
}
