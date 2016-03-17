using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork2;

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

		const string fname = "fridge.ini";

		static FridgeFile fr = new FridgeFile("fridge", -5, 0, -10, fname);

		static public void Show()
		{
			string ans = null;
			do
			{
				Console.Clear();

				Console.WriteLine(fr);

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
		}
	}
}
