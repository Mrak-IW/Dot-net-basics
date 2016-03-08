using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Abstracts;
using HomeWork3.FormattedOutput.Classes;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3.Menus.Classes
{
	public class MenuSelect : Menu<List<Employee>>
	{
		const string usageHelp = "<ID_записи [ ID_2 .. [ ID_N]] | селектор>\n\nДоступные селекторы:";
		const string description = "Просмотр данных из базы";

		public MenuSelect(List<Employee> dataBase, string cmdName)
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
			string buf;

			if (base.Call(out output, args) != EMenuOutput.Success)
			{
				output = null;
				if (args != null && args.Length >= 1)
				{
					int id;
					SymbolTable st = new SymbolTable("ID", "Имя", "Фамилия", "Должность");
					List<Employee> lst = new List<Employee>();

					for (int i = 0; i < args.Length; i++)
					{
						buf = null;
						if (int.TryParse(args[i], out id))
						{
							Employee item = OperatedObject.Find(x => x.ID == id);
							if (item != null)
							{
								lst.Add(item);
							}
							else
							{
								result = EMenuOutput.ParamOutOfRange;
								buf = string.Format("Запись с ключом {0} отсутствует в базе", args[i]);
							}
						}
						else
						{
							result = EMenuOutput.InvalidParamFormat;
							buf = string.Format("Невозможно преобразовать строку {0} в целое число", args[i]);
						}

						if (buf != null)
						{
							if (output != null)
							{
								output = string.Join("\n", output, buf);
							}
							else
							{
								output = buf;
							}
						}
					}

					if (result == EMenuOutput.Success)
					{
						output = st.CreateTable(lst);
					}
				}
				else
				{
					result = EMenuOutput.InvalidParamsCount;
					output = string.Format("Команда {0} должна иметь не менее одного параметра", Name);
				}
			}

			return result;
		}
	}
}
