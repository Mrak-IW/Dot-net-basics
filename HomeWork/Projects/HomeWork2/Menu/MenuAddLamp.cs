using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuAddLamp : Menu
	{
		const string usageHelp = "add " + name + " <имя_лампы> [maxBrightness [minBrightness [step]]]";
		const string description = "Добавить в систему умную лампу";
		const string name = "lamp";

		public override string Name
		{
			get
			{
				return name;
			}
		}

		public override string Description
		{
			get
			{
				return description;
			}
		}

		public override string UsageHelpShort
		{
			get
			{
				return usageHelp;
			}
		}

		public override bool Call(ISmartHouse sh, out string output, params string[] args)
		{
			bool result = true;
			output = null;

			int max = 100;
			int min = 0;
			int step = 0;
			string name;

			if (args.Length <= 1 || args.Length > 5)
			{
				output = "Недостаточно аргументов для " + args[0];
				return false;
			}
			else if (sh[args[1]] != null)
			{
				output = string.Format("Устройство с именем \"{0}\" уже есть в системе", args[1]);
				return false;
			}

			name = args[1];

			if (args.Length == 1)
			{
				min = max / 10;
				step = max / 10;
			}
			else
			{
				if (args.Length > 4)
				{
					if (!int.TryParse(args[4], out step))
					{
						output = string.Format("Четвёртый аргумент \"{0}\" не является целым числом", args[4]);
						return false;
					}
				}
				if (args.Length > 3)
				{
					if (!int.TryParse(args[3], out min))
					{
						output = string.Format("Третий аргумент \"{0}\" не является целым числом", args[3]);
						return false;
					}
				}
				if (args.Length > 2)
				{
					if (!int.TryParse(args[2], out max))
					{
						output = string.Format("Второй аргумент \"{0}\" не является целым числом", args[2]);
						return false;
					}
				}

			}

			IAdjustable<int> dimmer = new Dimmer(max, min, step);

			ISmartDevice dev = new SmartLamp(name, dimmer);

			sh.AddDevice(name, dev);

			return result;
		}
	}
}