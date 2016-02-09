using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
	class Array<T>
	{
		T[] arr;
		public Array(params T[] arr)
		{
			this.arr = (T[])arr.Clone();
		}

		public override string ToString()
		{
			int i;
			string result = "[ ";
			
			for (i = 0; i < arr.Length -1; i++)
			{
				result = result + arr[i] + "; ";
			}
			result = result + arr[i] + " ]";
			return result;
		}
	}
}
