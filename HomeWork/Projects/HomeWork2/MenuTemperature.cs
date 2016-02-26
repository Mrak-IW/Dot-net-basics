using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuTemperature : Menu
	{
		const string usageHelp = "<действие> [специфические параметры действия]\n\nДоступные действия:";
		const string description = "Управление температурой, за которую отвечает устройство";
		const string name = "temp";

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