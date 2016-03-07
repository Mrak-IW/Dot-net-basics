using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menus.Abstracts;
using NSDataBase.Interfaces;

namespace Menus.Classes
{
	public class MenuAdd : Menu<List<IEmployee>>
	{
		const string usageHelp = "<тип_устройства> <имя_устройства> [специфические параметры устройства]\n\nТипы устройств:";
		const string description = "Добавление устройств в систему";
		const string name = "add";

		public MenuAdd(List<IEmployee> dataBase)
			:base(dataBase)
		{ }

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