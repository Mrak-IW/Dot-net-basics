using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
	class Liquid
	{
		string[] chemicalComposition;
		double amount;

		public Liquid(double amount = 0, params string[] otherSubstances)
		{
			this.amount = amount;
			int correction = (otherSubstances.Length == 0 ? 1 : 0);

			chemicalComposition = new string[otherSubstances.Length + correction];

			for (int i = 0; i < chemicalComposition.Length - correction; i++)
			{
				chemicalComposition[i] = otherSubstances[i];
			}

			if (correction > 0)
			{
				chemicalComposition[0] = "Какая-то фигня";
			}
		}

		public static Liquid operator +(Liquid a, Liquid b)
		{
			int i, j, k;

			int correction = 0;

			Liquid result = new Liquid(a.amount + b.amount);

			for (i = 0; i < a.chemicalComposition.Length; i++)
			{
				for (j = 0; j < b.chemicalComposition.Length; j++)
				{
					if (a.chemicalComposition[i] == b.chemicalComposition[j])
					{
						correction++;
					}
				}
			}

			result.chemicalComposition = new string[a.chemicalComposition.Length + b.chemicalComposition.Length - correction];

			for (i = 0; i < a.chemicalComposition.Length; i++)
			{
				result.chemicalComposition[i] = a.chemicalComposition[i];
			}
			for (j = 0; j < b.chemicalComposition.Length; j++)
			{
				for (k = 0; k < a.chemicalComposition.Length; k++)
				{
					if (b.chemicalComposition[j] == a.chemicalComposition[k])
					{
						k = -1;
						break;
					}
				}
				if (k >= 0)
				{
					result.chemicalComposition[i] = b.chemicalComposition[j];
					i++;
				}
			}

			return result;
		}

		public static Liquid operator /(Liquid l, int parts)
		{
			return new Liquid(l.amount / parts, l.chemicalComposition);
		}

		public override string ToString()
		{
			string result = "Жидкость [" + this.amount + "мл]. Состав(" + this.chemicalComposition.Length + " вещества):";
			if (this.chemicalComposition.Length > 0)
			{
				foreach (string s in this.chemicalComposition)
				{
					result = result + "\n\t" + s;
				}
			}
			else
			{
				result = result + " неизвестен";
			}
			return result;
		}
	}
}
