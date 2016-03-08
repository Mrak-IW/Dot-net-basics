using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Interfaces;
using HomeWork3.Menus.Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//using HomeWork3.FormattedOutput.Classes;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3
{
	class Program
	{
		const string fname = "db.bin";
		static void Main(string[] args)
		{
			List<IEmployee> dataBase;

			dataBase = Load(fname);

			//dataBase.Add(new Employee("Угон", "Камазов", "Говнюк"));
			//dataBase.Add(new Employee("Рулон", "Обоев", "Космонавт"));
			//dataBase.Add(new Employee("Бидон", "Помоев", "Ловец зелёных зайцев"));

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

			Save(fname, dataBase);
		}

		static List<IEmployee> Load(string fileName)
		{
			List<IEmployee> dataBase = null;
			FileInfo fi = new FileInfo(fileName);

			if (fi.Exists)
			{
				BinaryFormatter bf = new BinaryFormatter();
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					try
					{
						dataBase = (List<IEmployee>)bf.Deserialize(fs);
					}
					catch (Exception) { }
				}
			}

			if (dataBase == null)
			{
				dataBase = new List<IEmployee>();
			}

			return dataBase;
		}

		static void Save(string fileName, object obj)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				bf.Serialize(fs, obj);
			}
		}
	}
}
