using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuBrightnessSet : Menu
	{
		const string usageHelp = "<имя_устройства_1> <яркость_1>[ .. <имя_устройства_N> <яркость_N>]";
		const string description = "Задать яркость";
		const string name = "set";

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
			ISmartDevice dev;

			if (args.Length % 2 == 0)
			{
				output = string.Format("Количество аргументов {0} должно быть чётным", Name);
				result = false;
			}

			if (args.Length == 1)
			{
				output = MISSING_ARGS + args[0];
				result = false;
			}

			if (result)
			{
				for (int i = 1; i < args.Length; i += 2)
				{
					dev = sh[args[i]];
					devFound = dev != null;

					if (devFound)
					{
						if (dev is IBrightable)
						{
							(dev as IBrightable).IncreaseBrightness();
							action = "стало темнее";
						}
						else
						{
							action = "не имеет настроек яркости";
						}
					}
					else
					{
						action = DEV_NOT_FOUND;
					}

					output = string.Format("{2} Устройство {0} {1}", args[i], action, (output != null ? output + "\n" : ""));
				}
			}

			return result;
		}
	}
}
