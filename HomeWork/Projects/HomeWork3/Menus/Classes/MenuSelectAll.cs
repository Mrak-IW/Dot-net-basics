using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Abstracts;
using HomeWork3.FormattedOutput.Classes;

namespace HomeWork3.Menus.Classes
{
	class MenuSelectAll : Menu<List<IEmployee>>
	{
		const string usageHelp = "< без параметров >";
		const string description = "Просмотреть всю базу целиком";

		public MenuSelectAll(List<IEmployee> dataBase, string cmdName)
			: base(dataBase, cmdName)
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

		public override EMenuOutput Call(out string output, params string[] args)
		{
			EMenuOutput result = EMenuOutput.Success;
			output = null;

			if (args == null || args.Length == 0)
			{
				SymbolTable st = new SymbolTable("ID", "Имя", "Фамилия", "Должность");
				List<IEmployee> lst = new List<IEmployee>();
				output = st.CreateTable(OperatedObject);
			}
			else
			{
				result = EMenuOutput.InvalidParamsCount;
				output = string.Format("Команда {0} не принимает параметров", FullName);
			}

			return result;
		}
	}
}
