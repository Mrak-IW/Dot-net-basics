﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork2.Menus.Abstracts;
using HomeWork2.SmartHouseDir.Interfaces;

namespace HomeWork2.Menus.Classes
{
	public class MenuOpen : Menu
	{
		const string usageHelp = "<имя_устройства_1> [ .. <имя_устройства_N>]";
		const string description = "Открыть устройство";
		const string name = "open";

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
						if (dev is IOpenCloseable)
						{
							if (!(dev as IOpenCloseable).IsOpened)
							{
								action = "открылось";
								(dev as IOpenCloseable).Open();
							}
							else
							{
								action = "\"То, что открыто, открыться не может\"";
							}
						}
						else
						{
							action = "не знает, что ему нужно открыть";
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