using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork2;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab14
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

			do
			{
				Console.Clear();

				Console.WriteLine(fr);

				if (result != null)
				{
					Console.WriteLine("\n" + result);
					result = null;
				}

				Console.WriteLine("\nДействия:");
				Console.WriteLine(ON + " - включить");
				Console.WriteLine(OFF + " - выключить");
				Console.WriteLine(OPEN + " - открыть");
				Console.WriteLine(CLOSE + " - закрыть");
				Console.WriteLine(HOT + " - теплее");
				Console.WriteLine(COLD + " - холоднее");
				Console.WriteLine(EXIT + " - выход");

				Console.Write("\nВаш выбор:\t");
				ans = Console.ReadLine();
				switch (ans)
				{
					case ON:
						fr.On();
						break;
					case OFF:
						fr.Off();
						break;
					case OPEN:
						fr.Open();
						break;
					case CLOSE:
						fr.Close();
						break;
					case HOT:
						fr.IncreaseTemperature();
						break;
					case COLD:
						fr.DecreaseTemperature();
						break;
				}
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
