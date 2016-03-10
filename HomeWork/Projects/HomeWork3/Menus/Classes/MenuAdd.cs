using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menus.Abstracts;
using NSDataBase.Interfaces;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3.Menus.Classes
{
	public class MenuAdd : Menu<List<Employee>>
	{
		const string usageHelp = "<тип_сущности> [специфические параметры сущности]\n\nТипы сущностей:";
		const string description = "Добавление сущностей в базу";

		public MenuAdd(List<Employee> dataBase, string cmdName)
			:base(dataBase, cmdName)
		{ }

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