using HomeWork2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab17.MultithreadingMenu
{
	class MultithreadFridgeMenu
	{
		const string ON = "on";
		const string OFF = "off";
		const string OPEN = "op";
		const string CLOSE = "cl";
		const string COLD = "-";
		const string HOT = "+";
		const string EXIT = "ex";

		Fridge fr;
		public string Command { get; set; }

		public MultithreadFridgeMenu(Fridge fr)
		{
			this.fr = fr;
			Command = "show";
		}

		public void Show()
		{
			string result = null;

			do
			{
				switch (Command)
				{
					case ON:
						{
							result = "Холодильник будет включен через некоторое время";
							TimerCallback tc = new TimerCallback(obj => { if (obj is Fridge) { (obj as Fridge).On(); Command = "show"; } });
							Timer t = new Timer(tc, fr, 5000, Timeout.Infinite);
						}
						break;
					case OFF:
						{
							result = "Холодильник будет выключен через некоторое время";
							TimerCallback tc = new TimerCallback(obj => { if (obj is Fridge) { (obj as Fridge).Off(); Command = "show"; } });
							Timer t = new Timer(tc, fr, 5000, Timeout.Infinite);
						}
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

				if (Command != null)
				{
					ShowState(result);
				}

				Command = null;
				Thread.Sleep(100);
			} while (Command != EXIT);
		}

		void ShowState(string result)
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
		}
	}

}
