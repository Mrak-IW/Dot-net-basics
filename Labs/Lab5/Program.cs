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
						ConsoleKeyInfo c;
						TvSet tv = new TvSet();
						do
						{
							Console.Clear();
							Console.WriteLine("Задание {0}:", taskNum);
							Console.WriteLine(" q - выход\n -> - следующий канал\n <- - предыдущий канал\n s - ввести номер канала");
							Console.WriteLine(tv);
							c = Console.ReadKey();
							switch (c.Key)
							{
 								case ConsoleKey.Q :
									Console.WriteLine("\bВыход");
									break;
								case ConsoleKey.RightArrow:
									tv.NextChannel();
									break;
								case ConsoleKey.LeftArrow:
									tv.PreviousChannel();
									break;
								case ConsoleKey.S:
									Console.Write("\bВведите канал:\t");
									tv.SetChannel(Convert.ToUInt32(Console.ReadLine()));
									break;
								default:
									Console.WriteLine(c.Key);
									break;
							}
						} while (c.Key != ConsoleKey.E);
					}
					break;
				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Student s1 = new Student("Вася");
						Student s2 = new Student("Вася2", 2);
						Student s3 = new Student("Вася Раздолбаев", 4, false);
						Console.WriteLine(s1);
						Console.WriteLine(s2);
						Console.WriteLine(s3);
					}
					break;
				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						AudioPlayer pl = new AudioPlayer();
						ConsoleKeyInfo c;
						do
						{
							Console.Clear();
							Console.WriteLine("Задание {0}:", taskNum);
							Console.WriteLine(" q - выход\n up - больше громкость\n down - меньше громкость");
							Console.WriteLine(pl);
							c = Console.ReadKey();
							switch (c.Key)
							{
								case ConsoleKey.Q:
									Console.WriteLine("\bВыход");
									break;
								case ConsoleKey.RightArrow:
								case ConsoleKey.UpArrow:
									pl.Volume += 5;
									break;
								case ConsoleKey.LeftArrow:
								case ConsoleKey.DownArrow:
									pl.Volume -= 5;
									break;
							}
						} while (c.Key != ConsoleKey.E);
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
			}
		}
	}
}
