using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
	class Program
	{
		static void Main(string[] args)
		{
			ISmartHouse sh = new SmartHouse();
			ISmartDevice l1 = new SmartLamp("lamp1", new Dimmer(100, 10, 10));

			CommandMenu cm = new CommandMenu(sh);
			IMenu add = new MenuAdd();
			IMenu rm = new MenuRemove();
			IMenu on = new MenuOn();
			IMenu br = new MenuBreak();
			IMenu bri = new MenuBrightness();
			cm.AddSubmenu(add);
			cm.AddSubmenu(rm);
			cm.AddSubmenu(on);
			cm.AddSubmenu(br);
			cm.AddSubmenu(bri);

			IMenu addLamp = new MenuAddLamp();
			add.AddSubmenu(addLamp);

			cm.Show();
		}
	}
}
