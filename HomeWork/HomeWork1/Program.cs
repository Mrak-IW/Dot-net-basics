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
			int[] arr = new int[20];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(9);
			}
			Console.WriteLine(ConvertToString(arr));
			QuickSort(arr);
			Console.WriteLine(ConvertToString(arr));
		}

		static void QuickSort(int[] arr, int startIndex = 0, int endIndex = -1)
		{
			if (endIndex < 0)
			{
				endIndex = (int)arr.Length - 1;
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

			for (i = startIndex, j = endIndex; ; i++, j--)
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
				}
				else return j;
			}
			
		}

		static string ConvertToString(int[] arr)
		{
			string res = "";
			for (int i = 0; i < arr.Length; i++)
			{
				res = res + arr[i] + " ";
			}
			return res;
		}
	}
}
