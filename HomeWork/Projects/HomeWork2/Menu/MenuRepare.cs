﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuRepare : Menu
	{
		const string usageHelp = "<имя_устройства_1> [ .. <имя_устройства_N>]";
		const string description = "Починить устройство";
		const string name = "repare";

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
			IRepareable devOK;
			string action;

			if (args != null && args.Length > 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					dev = sh[args[i]];

					if (dev != null)
					{
						if (dev is IRepareable)
						{
							devOK = dev as IRepareable;
							devOK.Repare();
							action = ": Вы подёргали какие-то проводки и протёрли всё тряпкой";
						}
						else
						{
							action = "проще выкинуть";
						}
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
				output = MISSING_ARGS + Name;
				result = false;
			}

			return result;
		}
	}
}