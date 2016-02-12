using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
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
						ISwitchable[] dev = new ISwitchable[2];
						dev[0] = new TvSet();
						dev[1] = new Fridge();
						for (int i = 0; i < dev.Length; i++)
						{
							Console.WriteLine(dev[i].ToString());
							dev[i].TurnOn();
							Console.WriteLine(dev[i].ToString());
						}
					}
					break;
				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						AnotherNamespace.NS obj = new AnotherNamespace.NS();
						Console.WriteLine(obj);
					}
					break;
				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int i;
						Task3 obj = new Task3();
						for (i = 0; i < 3; i++)
						{
							obj[i] = i;
						}
						for (i = -1; i < 4; i++)
						{
							Console.WriteLine("obj[{0}] = {1}", i, obj[i]);
						}
					}
					break;
				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Console.WriteLine(CheckChildrenCount("Кто-то", null));
						Console.WriteLine(CheckChildrenCount("Нулевой", 0));
						Console.WriteLine(CheckChildrenCount("Вася", 3));
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						var anon = new { P1 = 2, Name = "имя", Unknown = new { fuck = "you"} };
						Console.WriteLine("anon = \t\t{0}\t({1})", anon, anon.GetType());
						Console.WriteLine("anon.P1 = \t{0}\t({1})", anon.P1, anon.P1.GetType());
						Console.WriteLine("anon.Name = \t{0}\t({1})", anon.Name, anon.Name.GetType());
						Console.WriteLine("anon.Unknown = \t{0}\t({1})", anon.Unknown, anon.Unknown.GetType());
						Console.WriteLine("anon.Unknown.fuck = \t{0}\t({1})", anon.Unknown.fuck, anon.Unknown.fuck.GetType());
					}
					break;
			}
		}

		static string CheckChildrenCount(string name, int? count)
		{
			return name + " имеет " + (count == null ? "неизвестное количество" : count.ToString()) + " детей";
		}
	}
}
