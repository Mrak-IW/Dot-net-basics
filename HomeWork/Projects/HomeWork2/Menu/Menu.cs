using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public abstract class Menu : IMenu
	{
		protected const string EXIT = "exit";

		IDictionary<string, IMenu> submenus = new Dictionary<string, IMenu>();

		public IDictionary<string, IMenu> Submenus
		{
			get
			{
				return submenus;
			}
		}

		public virtual string UsageHelp
		{
			get
			{
				string result = null;
				foreach (KeyValuePair<string, IMenu> item in Submenus)
				{
					result = string.Format("{0}\n{1} - {2}", result, item.Key, item.Value);
				}
				return result;
			}
		}

		public abstract string Description { get; }

		public virtual bool Call(ISmartHouse sh, out string output, params string[] args)
		{
			output = null;

			if (args == null || args.Length == 0)
			{
				//output = "Недостаточно аргументов";
				return false;
			}

			bool result = true;

			IMenu sm;
			if (!Submenus.ContainsKey(args[0]))
			{
				output = "Некорректный список аргументов";
				result = false;
			}
			else
			{
				sm = Submenus[args[0]];
				if (!sm.Call(sh, out output, Last(args, 1)))
				{
					if (output != null)
					{
						output = string.Join("\n\n", output, sm.UsageHelp);
					}
					else
					{
						output = sm.UsageHelp;
					}
					result = true;
				}
			}

			return result;
		}

		protected string[] Last(string[] array, int startIndex)
		{
			string[] result = null;

			if (array != null && array.Length > startIndex)
			{
				result = new string[array.Length - startIndex];
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = array[i + startIndex];
				}
			}

			return result;
		}

		public override string ToString()
		{
			return Description;
		}
	}
}