﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Interfaces;
using HomeWork3.Menus.Classes;

using HomeWork3.FormattedOutput.Classes;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3
{
	class Program
	{
		static void Main(string[] args)
		{
			List<IEmployee> dataBase = new List<IEmployee>();
			dataBase.Add(new Employee("Угон", "Камазов", "Говнюк"));
			dataBase.Add(new Employee("Рулон", "Обоев", "Космонавт"));
			dataBase.Add(new Employee("Бидон", "Помоев", "Алкоголик со стажем"));

			DBCommandMenu menu = new DBCommandMenu(dataBase, "db>");

			IMenu<List<IEmployee>> add = new MenuAdd(dataBase, "add");
			add.AddSubmenu(new MenuAddEployee(dataBase, "emp"));

			IMenu<List<IEmployee>> select = new MenuSelect(dataBase, "sel");
			select.AddSubmenu(new MenuSelectAll(dataBase, "all"));

			IMenu<List<IEmployee>> delete = new MenuDelete(dataBase, "del");
			delete.AddSubmenu(new MenuDeleteAll(dataBase, "all"));

			menu.AddSubmenu(add);
			menu.AddSubmenu(select);
			menu.AddSubmenu(delete);

			menu.Show();
		}
	}
}