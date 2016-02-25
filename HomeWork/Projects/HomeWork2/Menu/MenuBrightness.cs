using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuBrightness : Menu
	{
		const string usageHelp = "<действие> <имя_устройства> [специфические параметры действия]\n\nДоступные действия:";
		const string description = "Управление яркостью свечения";
		const string name = "bri";

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
	}
}