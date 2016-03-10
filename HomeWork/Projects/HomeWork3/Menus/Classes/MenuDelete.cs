using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menus.Abstracts;
using NSDataBase.Interfaces;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3.Menus.Classes
{
	class MenuDelete : Menu<List<Employee>>
	{
		const string usageHelp = "<ID_сущности [ ID_2 .. [ ID_N]] | селектор>\n\nДоступные селекторы:";
		const string description = "Удаление сущностей из базы";

		public MenuDelete(List<Employee> dataBase, string cmdName)
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
			string buf;

			if (base.Call(out output, args) != EMenuOutput.Success)
			{
				output = null;
				if (args != null && args.Length >= 1)
				{
					int id;
					int count = 0;

					for (int i = 0; i < args.Length; i++)
					{
						buf = null;
						if (int.TryParse(args[i], out id))
						{
							Employee item = OperatedObject.Find(x => x.ID == id);
							if (item != null)
							{
								OperatedObject.Remove(item);
								++count;
								//buf = string.Format("Запись с ключом {0} удалена", id);
							}
							else
							{
								buf = string.Format("Запись с ключом {0} отсутствует в базе", id);
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

					buf = string.Format("Успешно удалено записей: {0}", count);
					if (output != null)
					{
						output = string.Join("\n", output, buf);
					}
					else
					{
						output = buf;
					}
				}
				else
				{
					result = EMenuOutput.InvalidParamsCount;
					buf = string.Format("Команда {0} должна иметь не менее одного параметра", Name);
					output = string.Join("\n", output, buf);
				}
			}

			return result;
		}
	}
}
