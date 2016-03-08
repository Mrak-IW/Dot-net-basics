using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menus.Abstracts;
using NSDataBase.Interfaces;
using HomeWork3.FormattedOutput.Classes;

namespace HomeWork3.Menus.Classes
{
	class MenuDeleteAll : Menu<List<IEmployee>>
	{
		const string usageHelp = "< без параметров >";
		const string description = "Очистить всю базу целиком";

		public MenuDeleteAll(List<IEmployee> dataBase, string cmdName)
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
				output = string.Format("Успешно удалено записей: {0}", OperatedObject.Count);
				OperatedObject.Clear();
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
