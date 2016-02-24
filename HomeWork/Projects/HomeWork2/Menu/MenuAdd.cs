using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class MenuAdd : Menu
	{
		const string usageHelp = "add <тип_устройства> <имя_устройства> [специфические параметры устройства]";
		const string description = "Добавление устройств в систему";

		public override string UsageHelp
		{
			get
			{
				return string.Format("-=[ {0} ]=-\n{1}\n{2}", Description, usageHelp, base.UsageHelp);
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