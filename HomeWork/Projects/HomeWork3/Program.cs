using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Classes;

namespace HomeWrok3
{
	class Program
	{
		static void Main(string[] args)
		{
			List<IEmployee> dataBase = new List<IEmployee>();
			DBCommandMenu menu = new DBCommandMenu(dataBase);
			menu.AddSubmenu(new MenuAdd(dataBase));

			menu.Show();
		}
	}
}
