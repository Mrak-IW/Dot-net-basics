using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
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
						Human[] harr = new Human[3];
						harr[0] = new Ukrainian();
						harr[1] = new Russian();
						harr[2] = new American();
						for (int i = 0; i < harr.Length; i++)
						{
							harr[i].SayHello();
						}
					}
					break;

				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int[] arr = new int[10];
						int i1, i2;

						for (int i = 0; i < arr.Length; i++)
						{
							arr[i] = rnd.Next(20);
						}
						Console.WriteLine("Массив:\t[{0}]", ConvertToString(arr));
						Console.Write("Ввести первый индекс:\t");
						i1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Ввести второй индекс:\t");
						i2 = Convert.ToInt32(Console.ReadLine());

						try
						{
							Console.WriteLine("arr[{0}] + arr[{1}] = {2}", i1, i2, arr[i1] + arr[i2]);
						}
						catch (Exception e)
						{
							Console.WriteLine("Сумма элементов arr[{0}] + arr[{1}] не может быть вычислена, потому что:\n{2}", i1, i2, e.Message);
						}
					}
					break;

				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						LinearMovement lm = new LinearMovement();
						try
						{
							lm.Distance = 10;
							lm.Time = -1;
							Console.WriteLine("Время прохождения = {0}\nДистанция = {1}\nСкорость = {2}", lm.Time, lm.Distance, lm.Speed);
						}
						catch (ExceptionDistanceBelowZero e)
						{
							Console.WriteLine(e.Message);
						}
						catch (ExceptionTimeBelowZero e)
						{
							Console.WriteLine(e.Message);
						}
						catch (Exception e)
						{
							Console.WriteLine("Отловлено неизвестное исключение:" + e.Message);
						}
					}
					break;

				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Animal[] arrAnimal = new Animal[6];
						arrAnimal[0] = new Dog { Name = "Шарик" };
						arrAnimal[1] = new Cat { Name = "Кусака" };
						arrAnimal[2] = new Cat { Name = "Ленивец" };
						arrAnimal[3] = new Dog { Name = "Джек" };
						arrAnimal[4] = new Cat { Name = "Черныш" };
						arrAnimal[5] = new Dog { Name = "Арчи" };
						foreach (Animal a in arrAnimal)
						{
							// Ваш код
							a.Bite();
							if (a is Cat)
							{
								Console.Write("через as: ");
								(a as Cat).Purr();
								Console.Write("через cast: ");
								((Cat)a).Purr();
							}
							Console.Write("через жопу: ");
							try
							{
								((Cat)a).Purr();
							}
							catch (Exception)
							{
								Console.WriteLine("EXCEPTION - " + a.Name + " не кошка и не мурчит");
							}
						}

					}
					break;
			}
		}

		static string ConvertToString(int[] arr)
		{
			string res = "";
			for (int i = 0; i < arr.Length; i++)
			{
				res = res + arr[i] + " ";
			}
			res = res.Substring(0, res.Length - 1);
			return res;
		}
	}
}
