using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	class CommandMenu : Menu
	{
		

		const string description = "Меню умного дома"; 
		const string usageHelp = "\n" + EXIT + " - выход";

		ISmartHouse sh;

		public override string Description
		{
			get
			{
				return description;
			}
		}

		public override string UsageHelp
		{
			get
			{
				return string.Format("-=[ {0} ]=-\n{1}\n{2}", Description, usageHelp, base.UsageHelp);
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
					Console.WriteLine();
					Console.WriteLine(output);
				}
				Console.Write("\nsh> ");
				ans = Console.ReadLine();
				args = ans.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				if (args != null && args.Length > 0)
				{
					if (args[0] == EXIT)
					{
						break;
					}
				}

				result = Call(sh, out output, args);
				if (!result)
				{
					output = this.UsageHelp;
				}
			}

			Console.WriteLine("Завершение работы программы");
		}

		private void ShowState()
		{
			Console.Clear();
			Console.WriteLine("В системе {0} устройств:", sh.Count);
			for (int i = 0; i < sh.Count; i++)
			{
				Console.WriteLine(sh[i]);
			}
			Console.WriteLine();
		}
	}
}
