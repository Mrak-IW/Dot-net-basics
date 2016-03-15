using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			string taskNum = Console.ReadLine();
			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;

				case "1":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Menu.Show();
					}
					break;
				case "2":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int[] firstArr = new int[100000000];
						int[] secondArr = new int[100000000];
						Random ran = new Random(); // Объект для генерации случайных чисел
						for (int i = 0; i < firstArr.Length; i++) // Заполнение массива случайными значениями в диапазоне от 1 до 100
						{
							firstArr[i] = ran.Next(1, 100);
							secondArr[i] = ran.Next(1, 100);
						}
						long firstArrSum = 0; // Сумма первого массива
						long secondArrSum = 0; // Сумма второго массива
						Stopwatch sw = new Stopwatch(); // Объект для подсчета времени выполнения подсчета
						sw.Start();
						foreach (int item in firstArr) // Подсчет суммы элементов первого массива
						{
							firstArrSum += item;
						}
						foreach (int item in secondArr) // Подсчет суммы элементов второго массива
						{
							secondArrSum += item;
						}
						sw.Stop();
						Console.WriteLine("Сумма элементов первого массива: " + firstArrSum);
						Console.WriteLine("Сумма элементов второго массива: " + secondArrSum);
						Console.WriteLine("Время выполнения подсчета: " + sw.ElapsedMilliseconds + " миллисекунд");

						firstArrSum = 0; // Сумма первого массива
						secondArrSum = 0; // Сумма второго массива

						
						Task<long> t1 = new Task<long>(() =>
						{
							long sum = 0;
							foreach (int item in firstArr) // Подсчет суммы элементов первого массива
							{
								sum += item;
							}
							return sum;
						});

						Task<long> t2 = new Task<long>(() =>
						{
							long sum = 0;
							foreach (int item in secondArr) // Подсчет суммы элементов второго массива
							{
								sum += item;
							}
							return sum;
						});

						sw.Reset();
						sw.Start();

						t1.Start();
						t2.Start();
						t1.Wait();
						t2.Wait();

						sw.Stop();

						firstArrSum = t1.Result;
						secondArrSum = t2.Result;

						Console.WriteLine("Сумма элементов первого массива: " + firstArrSum);
						Console.WriteLine("Сумма элементов второго массива: " + secondArrSum);
						Console.WriteLine("Время выполнения подсчета: " + sw.ElapsedMilliseconds + " миллисекунд");
					}
					break;
			}
		}
	}
}
