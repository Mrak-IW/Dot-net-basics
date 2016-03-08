using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Abstracts;
using HomeWork3.FormattedOutput.Classes;

namespace HomeWork3.Menus.Classes
{
	public class DBCommandMenu : CommandMenu<List<IEmployee>>
	{
		const string description = "Управление БД";
		const string usageHelp = "<команда> [аргументы команды]\n\n" + EXIT + "\tвыход";

		public DBCommandMenu(List<IEmployee> dataBase, string cmdName)
			: base(dataBase, cmdName)
		{ }

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
			Console.WriteLine("Записей в базе: {0}", OperatedObject.Count);
			//SymbolTable st = new SymbolTable("Имя", "Фамилия", "Должность");
			//Console.WriteLine(st.CreateTable(OperatedObject));
		}
	}
}
