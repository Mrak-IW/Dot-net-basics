﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuRemove : Menu
	{
		const string usageHelp = name + " <имя_устройства> [<имя_устройства_2> .. [<имя_устройства_N>]]";
		const string description = "Выкинуть в окно";
		const string name = "rm";

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

			if (args.Length > 1)
			{
				for (int i = 1; i < args.Length; i++)
				{
					string action = sh[args[i]] != null ? "выброшено в окно" : "не найдено";
					sh.RemoveDevice(args[i]);

					output = string.Format(" Устройство {0} {1}", args[i], action);
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