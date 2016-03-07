using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
//using HomeWork2.SmartHouseDir.Interfaces;

namespace Menus.Abstracts
{
	public abstract class CommandMenu<T> : Menu<T>
	{
		/// <summary>
		/// Показать текущее состояние управляемого объекта
		/// </summary>
		public abstract void ShowState();

		public CommandMenu(T operatedObject)
			: base(operatedObject)
		{ }

		public virtual void Show()
		{
			const int cmdIndex = 0;

			string ans = null;
			string output = null;
			bool result = true;
			string[] args;
			string cmd;
			while (true)
			{
				Console.Clear();
				ShowState();
				if (ans != null)
				{
					Console.WriteLine(string.Format("\n{0} {1}\n", Name, ans));
				}
				if (output != null)
				{
					Console.WriteLine(output);
				}
				Console.Write("\n{0} ", this.Name);
				ans = Console.ReadLine();
				args = ans.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				if (args != null && args.Length > cmdIndex)
				{
					cmd = args[cmdIndex];
					if (cmd == EXIT)
					{
						break;
					}
				}

				result = Call(out output, args);
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
	}
}
