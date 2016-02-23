using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork1
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();
			bool isSorted;
			int fails = 0;
			int iterationCount = 100000;
			int arrayLength = 20;
			int maxElement = 99;

			for (int j = 0; j < iterationCount; j++)
			{
				//Тестовые наборы, на которых проявлялась ошибка при наличии строки i++; в блоке разделения массива
				//int[] arr = { 0, 1, 2, 1 };
				//int[] arr = { 2, 0, 0, 7, 2, 1, 4, 1, 2, 0, 3, 8, 0, 1, 7, 4, 8, 0, 5, 2 };
				int[] arr = new int[arrayLength];
				int[] arrBeforeSort = new int[arr.Length];
				for (int i = 0; i < arr.Length; i++)
				{
					arr[i] = rnd.Next(maxElement);
					arrBeforeSort[i] = arr[i];
				}
				
				QuickSort(arr);
				isSorted = IsSortedAscending(arr);
				if (!isSorted)
				{
					Console.WriteLine("До сортировки:\t\t{0}", ConvertToString(arrBeforeSort));
					Console.WriteLine("Сортировка[{1}]:\t{0}\n", ConvertToString(arr), isSorted);
					fails++;
				}
			}
			if (fails == 0)
			{
				Console.WriteLine("На {0} случайных массивов из {1} элементов алгоритм отработал корректно.", iterationCount, arrayLength);
			}
			else
			{
				Console.WriteLine("На {0} случайных массивов из {1} элементов алгоритм дал сбой {2} раз.", iterationCount, arrayLength, fails);
			}

		}

		static void QuickSort(int[] arr, int startIndex = 0, int endIndex = -1)
		{
			if (endIndex < 0)
			{
				endIndex = arr.Length - 1;
			}

			if (startIndex >= endIndex)
			{
				return;
			}

			int baseIndex = Split(arr, startIndex, endIndex);

			if (baseIndex - startIndex >= 1)
			{
				QuickSort(arr, startIndex, baseIndex);
			}
			if (endIndex - (baseIndex + 1) >= 1)
			{
				QuickSort(arr, baseIndex + 1, endIndex);
			}
		}

		static int Split(int[] arr, int startIndex, int endIndex)
		{
			int i, j;
			int buf;
			int baseElem = arr[(endIndex + startIndex) / 2];

			i = startIndex;
			j = endIndex;

			while (i < j)
			{
				while (arr[i] < baseElem)
				{
					i++;
				}
				while (arr[j] > baseElem)
				{
					j--;
				}
				if (i < j)
				{
					buf = arr[i];
					arr[i] = arr[j];
					arr[j] = buf;
					//i++;	//Вот интересно, почему эта строчка есть во всех найденных мной листингах, а без неё работает лучше?
					j--;
				}
			}

			return j;
		}

		static string ConvertToString(int[] arr, int startIndex = -1, int endIndex = -1, int focus1 = -1, int focus2 = -1)
		{
			string res = "";
			string tmp;
			if (startIndex < 0)
			{
				startIndex = 0;
			}
			if (endIndex < 0)
			{
				endIndex = arr.Length - 1;
			}
			for (int i = startIndex; i <= endIndex && i < arr.Length; i++)
			{
				tmp = arr[i].ToString();
				if (i == focus1)
				{
					tmp = "(" + tmp + ")";

				}
				if (i == focus2)
				{
					tmp = "<" + tmp + ">";

				}
				res = res + tmp + " ";
			}
			return res;
		}

		static bool IsSortedAscending(int[] arr)
		{
			bool result = true;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] < arr[i - 1])
				{
					result = false;
					break;
				}
			}
			return result;
		}
	}
}
