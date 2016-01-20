using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
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
						int[] arr = new int[3];
						int pos = 0, neg = 0;

						//Заполняем массив
						for (int i = 0; i < arr.Length; i++)
						{
							arr[i] = rnd.Next(-128, 127);
						}

						for (int i = 0; i < arr.Length; i++)
						{
							if (arr[i] >= 0)
							{
								pos++;
							}
							else
							{
								neg++;
							}
						}

						Console.WriteLine("Массив:\t{0}", intArrayToString(arr));
						Console.WriteLine("Положительных:\t{0}\nОтрицательных:\t{1}", pos, neg);
					}
					break;

				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int a, b;
						a = rnd.Next(255);
						b = rnd.Next(255);
						Console.WriteLine("Даны числа {0} и {1}. max = {2}", a, b, (a > b ? a : b));
					}
					break;

				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						double a, b, c;
						a = rnd.NextDouble() * 100;
						b = rnd.NextDouble() * 100;
						c = rnd.NextDouble() * 100;

						Console.WriteLine("Даны числа: а = {0:F2}; b = {1:F2}; c = {2:F2};", a, b, c);

						if ((a > b) && (b > c) || (a < b) && (b < c))
						{
							a *= 2;
							b *= 2;
							c *= 2;
						}
						else
						{
							a = -a;
							b = -b;
							c = -c;
						}

						Console.WriteLine("Результат: а = {0:F2}; b = {1:F2}; c = {2:F2};", a, b, c);
					}
					break;

				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int day = rnd.Next(1, 7);
						string dayName = "безысходник";
						switch (day)
						{
							case 1:
								dayName = "понедельник";
								break;
							case 2:
								dayName = "вторник";
								break;
							case 3:
								dayName = "среда";
								break;
							case 4:
								dayName = "четверг";
								break;
							case 5:
								dayName = "пятница";
								break;
							case 6:
								dayName = "суббота";
								break;
							case 7:
								dayName = "воскресенье";
								break;

						}
						Console.WriteLine("День недели №{0} - это {1}", day, dayName);

					}
					break;

				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int N = rnd.Next(4, 10);
						int[] arr = new int[N];
						for (int i = 0; i < arr.Length; i++)
						{
							arr[i] = i * 2 + 1;
						}

						Console.WriteLine("Массив из {0} элементов:\n{1}", N, intArrayToString(arr));

					}
					break;

				case 6:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int N = rnd.Next(4, 10);
						int[] arr = new int[N];
						for (int i = 0; i < arr.Length; i++)
						{
							arr[i] = rnd.Next(255);
						}

						Console.WriteLine("Массив:\n{0}", intArrayToString(arr));

						for (int i = arr.Length - 1; i >= 0; i--)
						{
							Console.Write(arr[i] + " ");
						}
					}
					break;
				case 7:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int[,] arr = new int[5, 5];

						for (int i = 0; i < arr.GetLength(0); i++)
						{
							for (int j = 0; j < arr.GetLength(1); j++)
							{
								arr[i, j] = rnd.Next(255);
							}
						}

						Console.WriteLine("Массив 5х5:\n{0}", int2DArrayToString(arr));

						Console.WriteLine("Элементы из нечётных столбцов:");
						for (int i = 0; i < arr.GetLength(0); i++)
						{
							for (int j = 0; j < arr.GetLength(1); j += 2)
							{
								Console.Write(arr[i, j] + "\t");
							}
							Console.WriteLine();
						}
					}
					break;
				case 8:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int a, b, sum;
						a = rnd.Next(5);
						b = rnd.Next(6, 10);

						Console.WriteLine("a = {0}\nb = {1}", a, b);

						sum = 0;
						for (int i = a; i <= b; i++)
						{
							sum += i * i;
						}

						Console.WriteLine("Сумма квадратов всех целых числе от {0} до {1} включительно = {2}", a, b, sum);
					}
					break;
				case 9:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int N = rnd.Next(5, 10);
						double sum = 0;

						for (int i = 1; i <= N; i++)
						{
							sum += (double)1 / i;
						}
						Console.WriteLine("Число = {0}\nСумма = {1}", N, sum);
					}
					break;
				case 10:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int a, b, sum;
						a = rnd.Next(5);
						b = rnd.Next(6, 10);
					}
					break;
				case 11:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
				case 12:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
				case 13:
					Console.WriteLine("Задание {0}:", taskNum);
					{

					}
					break;
			}
		}

		static string intArrayToString(int[] arr)
		{
			string res = "";
			for (int i = 0; i < arr.Length; i++)
			{
				res = res + arr[i] + " ";
			}
			return res;
		}

		static string int2DArrayToString(int[,] arr)
		{
			string res = "";
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					res = res + arr[i, j] + "\t";
				}
				res = res + "\n";
			}
			return res;
		}
	}
}
