using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab11.Task1;

namespace Lab12
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
						AnyClass a = new AnyClass("a");
						AnyClass b = new AnyClass("b");
						AnyClass c = new AnyClass("c");
						a.Dispose();
						b = null;
						c = null;
						Console.WriteLine("Жми цапу");
						Console.ReadKey();
						Console.Write("\b");
					}
					break;
				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int i = 1;
						double d = 2;
						string s = "3";
						dynamic dyn = "s";
						Console.WriteLine(MyRealType(i));
						Console.WriteLine(MyRealType(d));
						Console.WriteLine(MyRealType(s));
						if (dyn is string)
						{
							Console.WriteLine("Gotcha");
						}
					}
					break;
				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						TPing ping = new TPing();
						TPong pong = new TPong();
						ping.RegisterDelegate(pong.Pong);
						pong.RegisterDelegate(ping.Ping);
						ping.Ping();
					}
					break;
			}
		}

		static string MyRealType(dynamic par)
		{
			return par.GetType().ToString();
		}
	}
}
