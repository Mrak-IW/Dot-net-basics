using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Abstracts;

namespace Menus.Classes
{
	public class DBCommandMenu : CommandMenu<List<IEmployee>>
	{
		const string description = "Управление БД";
		const string usageHelp = "<команда> [аргументы команды]\n\n" + EXIT + "\tвыход";
		const string name = "db>";

		public DBCommandMenu(List<IEmployee> dataBase)
			: base(dataBase)
		{ }

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

		public override void ShowState()
		{
			Console.WriteLine("Записей в базе: {0}");
		}
	}
}
