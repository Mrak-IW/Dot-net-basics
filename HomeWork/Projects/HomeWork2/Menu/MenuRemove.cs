using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuRemove : Menu
	{
		const string usageHelp = "rm <имя_устройства> [<имя_устройства_2> .. [<имя_устройства_N>]]";
		const string description = "Удаление устройства из систем";

		public override string UsageHelp
		{
			get
			{
				return string.Format("-=[ {0} ]=-\n{1}\n{2}", Description, usageHelp, base.UsageHelp);
			}
		}

		public override string Description
		{
			get
			{
				return description;
			}
		}

		public override bool Call(ISmartHouse sh, out string output, params string[] args)
		{
			bool result = true;
			output = null;

			if (args != null && args.Length > 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					string action = sh[args[i]] != null ? "выброшено в окно" : "не найдено";
					string delimeter = output == null ? "" : "\n";
					sh.RemoveDevice(args[i]);

					output = string.Format("{0}{3} Устройство {1} {2}", output, args[i], action, delimeter);
				}
			}
			else
			{
				output = "Недостаточно аргументов для rm";
				result = false;
			}

			return result;
		}
	}
}
