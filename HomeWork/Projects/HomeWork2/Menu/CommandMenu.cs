using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	class CommandMenu : Menu
	{
		ISmartHouse sh;

		const string description = "Меню умного дома";
		const string usageHelp = "<команда> [аргументы команды]" + EXIT + " - выход";
		const string name = "sh>";

		public override string Name
		{
			get
			{
				return name;
			}
		}

		public override string Description
		{
			get
			{
				return description;
			}
		}

		public override string UsageHelpShort
		{
			get
			{
				return usageHelp;
			}
		}

		public CommandMenu(ISmartHouse sh)
		{
			this.sh = sh;
		}

		public void Show()
		{
			string ans;
			string output = null;
			bool result = true;
			string[] args;

			while (true)
			{
				ShowState();
				if (output != null)
				{
					Console.WriteLine(output);
				}
				Console.Write("\n{0} ", this.Name);
				ans = string.Concat(this.Name, " ", Console.ReadLine());	//Это, чтобы нулевым аргументом каждой команды было её имя
				args = ans.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				if (args != null && args.Length > 1)
				{
					if (args[1] == EXIT)
					{
						break;
					}
				}

				result = Call(sh, out output, args);
				if (!result)
				{
					if (output != null)
					{
						output = string.Join("\n\n", output, this.UsageHelp);
					}
					else
					{
						output = this.UsageHelp;
					}
				}
			}

			Console.WriteLine("Завершение работы программы");
		}

		private void ShowState()
		{
			Console.Clear();
			Console.WriteLine("Устройств в системе {0}:", sh.Count);
			for (int i = 0; i < sh.Count; i++)
			{
				Console.WriteLine(sh[i]);
			}
			Console.WriteLine();
		}
	}
}
