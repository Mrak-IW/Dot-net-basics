using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork2;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Lab17.MultithreadingMenu;
using System.Threading;

namespace Lab17
{
	static class Menu
	{
		const string ON = "on";
		const string OFF = "off";
		const string OPEN = "op";
		const string CLOSE = "cl";
		const string COLD = "-";
		const string HOT = "+";
		const string EXIT = "ex";

		static public void Show()
		{
			string fname = "fridge.bin";

			Fridge fr = null;
			BinaryFormatter bf = new BinaryFormatter();
			FileInfo fi = new FileInfo(fname);
			string ans = null;
			string result = null;

			if (fi.Exists)
			{
				try
				{
					using (FileStream fs = new FileStream(fname, FileMode.Open))
					{
						fr = (Fridge)bf.Deserialize(fs);
						result = string.Format("Состояние объекта загружено из файла \"{0}\"", fname);
					}
				}
				catch (Exception)
				{
					result = string.Format("Состояние объекта не может быть загружено из файла \"{0}\",  однако файл существует", fname);
				}
			}
			if (fr == null)
			{
				fr = new Fridge("fridge", new Dimmer(0, -10, 1));
				result = string.Format("Состояние объекта задано конструктором", fname);
			}
			Console.WriteLine("{0}\nНажмите любую кнопку для продолжения", result);
			Console.ReadKey(false);

			MultithreadFridgeMenu mttMenu = new MultithreadFridgeMenu(fr);
			Thread menuThread = new Thread(mttMenu.Show);
			menuThread.Start();
			do
			{
				ans = Console.ReadLine();
				mttMenu.Command = ans;
			} while (ans != EXIT);

			try
			{
				using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate))
				{
					bf.Serialize(fs, fr);
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Сериализация провалилась");
			}
		}
	}
}
