using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Abstracts;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3.Menus.Classes
{
	public class MenuAddEployee : Menu<List<Employee>>
	{
		const int argsCount = 3;
		const string usageHelp = "<Имя> <Фамилия> <Должность>";
		const string description = "Добавление рядового сотрудника в базу";

		public MenuAddEployee(List<Employee> dataBase, string cmdName)
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

			if (args == null || args.Length != argsCount)
			{
				output = string.Format("Команда \"{0}\" должна иметь строго {1} аргумента", FullName, argsCount);
				result = EMenuOutput.InvalidParamsCount;
			}
			else
			{
				OperatedObject.Add(new Employee(args[0], args[1], args[2]));
				output = "Запись добавлена";
			}

			return result;
		}
	}
}
