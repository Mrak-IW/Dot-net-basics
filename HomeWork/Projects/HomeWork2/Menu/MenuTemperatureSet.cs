﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuTemperatureSet : Menu
	{
		const string usageHelp = "<имя_устройства_1> <яркость_1>[ .. <имя_устройства_N> <яркость_N>]\n\nЕсли заданная температура недоступна для устройства, команда будет проигнорирована.";
		const string description = "Задать температуру числом";
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
			int value;
			string action;
			ISmartDevice dev;
			IHaveThermostat devOK;

			output = null;

			if (args == null || args.Length % 2 != 0)
			{
				output = string.Format("Количество аргументов {0} должно быть чётным и больше нуля", Name);
				result = false;
			}

			if (result)
			{
				for (int i = 0; i < args.Length; i += 2)
				{
					if (int.TryParse(args[i + 1], out value))
					{
						dev = sh[args[i]];
						if (dev != null)
						{
							if (dev is IHaveThermostat)
							{
								devOK = dev as IHaveThermostat;
								devOK.Temperature = value;
								action = string.Format("- температура установлена в {1}", dev.Name, devOK.Temperature);
							}
							else
							{
								action = "не имеет настроек температуры";
							}
						}
						else
						{
							action = DEV_NOT_FOUND;
						}
						output = string.Format("{2} Устройство {0} {1}", args[i], action, (output != null ? output + "\n" : ""));
					}
					else
					{
						output = string.Format("{2} Аргумент \"{1}\" не является целым числом", i + 1, args[i + 1], (output != null ? output + "\n" : ""));
					}
				}
			}

			return result;
		}
	}
}