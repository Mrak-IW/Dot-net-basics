using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab18
{
	static class Extensions
	{
		public static string ConvertToString(this int[] arr)
		{
			string res = "";
			int i;
			for (i = 0; i < arr.Length - 1; i++)
			{
				res = res + arr[i] + " ";
			}
			res = res + arr[i];
			return res;
		}
	}
}
