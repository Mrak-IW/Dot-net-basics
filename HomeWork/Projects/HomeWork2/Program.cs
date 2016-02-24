using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	class Program
	{
		const string ADD_DEVICE = "add";
		const string REM_DEVICE = "rm";
		const string PICK_DEVICE = "dev";
		const string ON_DEVICE = "on";
		const string OFF_DEVICE = "off";
		const string BREAK_DEVICE = "break";
		const string REPARE_DEVICE = "repare";

		const string DEV_LAMP = "lamp";

		const string BRIGHT_UP = "lighter";
		const string BRIGHT_DOWN = "darker";
		const string GET_BRIGHTNESS = "gb";

		const string OPEN = "op";
		const string CLOSE = "cl";
		const string GET_OPEN_STATE = "os";

		const string TEMP_UP = "tu";
		const string TEMP_DOWN = "td";
		const string GET_TEMP = "gt";

		static void Main(string[] args)
		{
			ISmartHouse sh = new SmartHouse();
			CommandMenu cm = new CommandMenu(sh);
			IMenu add = new MenuAdd();
			IMenu rm = new MenuRemove();
			cm.Submenus.Add(ADD_DEVICE, add);
			cm.Submenus.Add(REM_DEVICE, rm);

			IMenu addLamp = new MenuAddLamp();
			add.Submenus.Add(DEV_LAMP, addLamp);

			cm.Show();
		}
	}
}
