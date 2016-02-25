using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuOn : Menu
	{
		const string usageHelp = name + " <имя_устройства>";
		const string description = "Включить устройство";
		const string name = "on";

		public override string Name
		{
			get
			{
				return name;
			}
		}

		public override string UsageHelpShort
		{
			get
			{
				return usageHelp;
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
			bool devFound;
			string action;

			if (args.Length > 1)
			{
				for (int i = 1; i < args.Length; i++)
				{
					devFound = sh[args[i]] != null;

					action = devFound ? "включено" : "не найдено";

					if (devFound)
					{
						sh.TurnDeviceOn(args[i]);
					}

					output = string.Format("Устройство {0} {1}", args[i], action);
				}
			}
			else
			{
				output = "Недостаточно аргументов для " + args[0];
				result = false;
			}

			return result;
		}
	}
}