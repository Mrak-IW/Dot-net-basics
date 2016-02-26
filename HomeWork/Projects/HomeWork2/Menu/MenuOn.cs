﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuOn : Menu
	{
		const string usageHelp = "<имя_устройства>";
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
			ISmartDevice dev;
			string action;

			if (args != null && args.Length > 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					dev = sh[args[i]];

					if (dev != null)
					{
						dev.On();
						action = "включено";
					}
					else
					{
						action = DEV_NOT_FOUND;
					}

					output = string.Format("{2} Устройство {0} {1}", args[i], action, (output != null ? output + "\n" : ""));
				}
			}
			else
			{
				output = "Недостаточно аргументов для " + Name;
				result = false;
			}

			return result;
		}
	}
}