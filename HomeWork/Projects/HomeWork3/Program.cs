using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using Menus.Interfaces;
using HomeWork3.Menus.Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

//using HomeWork3.FormattedOutput.Classes;
using HomeWork3.NSDataBase.Classes;

namespace HomeWork3
{
	class Program
	{
		//const string fnameBin = "db.bin";
		//const string fnameXml = "db.xml";
		const string configFileName = "settings.ini";

		static void Main(string[] args)
		{
			List<Employee> dataBase;
			string saveFileName/* = fnameBin*/;

			dataBase = Load(configFileName, out saveFileName);
			//dataBase = LoadBin(fnameBin);

			//dataBase.Add(new Employee("Угон", "Камазов", "Говнюк"));
			//dataBase.Add(new Employee("Рулон", "Обоев", "Космонавт"));
			//dataBase.Add(new Employee("Бидон", "Помоев", "Ловец зелёных зайцев"));
			Console.WriteLine("Для продолжения нажмите любую клавишу");
			Console.ReadKey();
			Console.Write("\b");

			DBCommandMenu menu = new DBCommandMenu(dataBase, "db>");

			IMenu<List<Employee>> add = new MenuAdd(dataBase, "add");
			add.AddSubmenu(new MenuAddEployee(dataBase, "emp"));

			IMenu<List<Employee>> select = new MenuSelect(dataBase, "sel");
			select.AddSubmenu(new MenuSelectAll(dataBase, "all"));

			IMenu<List<Employee>> delete = new MenuDelete(dataBase, "del");
			delete.AddSubmenu(new MenuDeleteAll(dataBase, "all"));

			menu.AddSubmenu(add);
			menu.AddSubmenu(select);
			menu.AddSubmenu(delete);

			menu.Show();

			Save(dataBase, saveFileName);
			//SaveBin(fnameBin,dataBase);
		}

		static List<Employee> Load(string configFileName, out string dbFileName)
		{
			List<Employee> dataBase = null;
			string output = null;

			dbFileName = ReadField(configFileName, "fileName");
			if (dbFileName != null)
			{
				string[] split = dbFileName.Split('.');
				if (split.Length > 1)
				{
					switch (split[split.Length - 1])
					{
						case "bin":
							dataBase = LoadBin(dbFileName);
							break;
						case "xml":
							dataBase = LoadXml(dbFileName);
							break;
						default:
							dbFileName = dbFileName.Substring(0, dbFileName.LastIndexOf('.') + 1) + "bin";
							break;
					}
				}
			}

			if (dataBase == null)
			{
				dataBase = new List<Employee>();
				output = string.Format("Загрузка из файла {0} невозможна. База данных будет создана заново.", dbFileName);
			}
			else
			{
				output = "Данные успешно загружены из файла " + dbFileName;
			}
			Console.WriteLine(output);
			Console.WriteLine();

			return dataBase;
		}

		static List<Employee> LoadBin(string fileName)
		{
			List<Employee> dataBase = null;
			FileInfo fi = new FileInfo(fileName);

			if (fi.Exists)
			{
				BinaryFormatter bf = new BinaryFormatter();
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					try
					{
						dataBase = (List<Employee>)bf.Deserialize(fs);
					}
					catch (Exception) { }
				}
			}
			//Восстановим значение статического поля Employee.nextID в логически приемлемое значение
			//Кстати, а можно сериализовать статические члены класса?
			foreach (Employee e in dataBase)
			{
				if (e.ID >= Employee.nextID)
				{
					Employee.nextID = e.ID + 1;
				}
			}
			return dataBase;
		}

		static List<Employee> LoadXml(string fileName)
		{
			List<Employee> dataBase = null;
			FileInfo fi = new FileInfo(fileName);

			if (fi.Exists)
			{
				XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					try
					{
						dataBase = (List<Employee>)xs.Deserialize(fs);
					}
					catch (Exception) { }
				}
			}

			return dataBase;
		}

		static void Save(object obj, string saveFileName)
		{
			if (saveFileName != null)
			{
				string[] split = saveFileName.Split('.');
				if (split.Length > 1)
				{
					switch (split[split.Length - 1])
					{
						case "bin":
							SaveBin(saveFileName, obj);
							break;
						case "xml":
							SaveXml(saveFileName, obj);
							break;
					}
				}
			}
		}

		static void SaveBin(string fileName, object obj)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				bf.Serialize(fs, obj);
			}
		}

		static void SaveXml(string fileName, object obj)
		{
			XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				xs.Serialize(fs, obj);
			}
		}

		static string ReadField(string fileName, string fieldName)
		{
			FileInfo fi = new FileInfo(fileName);

			if (fi.Exists)
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					string str;
					string[] split = null;
					bool result = true;

					sr.BaseStream.Seek(0, SeekOrigin.Begin);

					do
					{
						str = sr.ReadLine();
						if (str == null)
						{
							result = false;
							break;
						}
						str = str.Trim();
						split = str.Split(new char[] { '=', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					} while (split[0] != fieldName);

					if (split == null || split.Length < 2)
					{
						result = false;
					}

					return result ? split[1] : null;
				}
			}
			else
			{
				return null;
			}
		}
	}
}
