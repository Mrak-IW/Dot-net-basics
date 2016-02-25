using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public abstract class Menu : IMenu
	{
		protected const string EXIT = "exit";
		protected const string MISSING_ARGS = "Недостаточно аргументов для команды ";
		protected const string DEV_NOT_FOUND = "не найдено";

		IDictionary<string, IMenu> submenus = new Dictionary<string, IMenu>();

		public abstract string Description { get; }
		public abstract string UsageHelpShort { get; }
		public abstract string Name { get; }

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
				string result = string.Format("-=[ {0} ]=-\n\n{1} {2}", Description, FullName, UsageHelpShort);
				foreach (KeyValuePair<string, IMenu> item in Submenus)
				{
					result = string.Format("{0}\n{1} - {2}", result, item.Key, item.Value);
				}
				return result;
			}
		}

		public string FullName
		{
			get
			{
				if (Parent != null)
				{
					return string.Join(" ", Parent.FullName, this.Name);
				}
				else
					return this.Name;
			}
		}

		public IMenu Parent { get; set; }

		public virtual bool Call(ISmartHouse sh, out string output, params string[] args)
		{
			output = null;

			if (args.Length <= 1)
			{
				output = MISSING_ARGS + args[0];
				return false;
			}

			bool result = true;

			IMenu sm;
			if (!ContainsSubmenu(args[1]))
			{
				output = string.Format("{0} не обладает вложенной командой {1}", args[0], args[1]);
				result = false;
			}
			else
			{
				sm = Submenus[args[1]];
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

		public bool AddSubmenu(IMenu submenu)
		{
			bool result = true;
			if (!ContainsSubmenu(submenu.Name))
			{
				Submenus.Add(submenu.Name, submenu);
				submenu.Parent = this;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool ContainsSubmenu(string name)
		{
			return Submenus.ContainsKey(name);
		}
	}
}