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
			sh.AddDevice(new SmartLamp("l1", new Dimmer(100, 10, 10)));
			sh.AddDevice(new SmartLamp("l2", new Dimmer(100, 10, 15)));
			sh.AddDevice(new SmartLamp("l3", new Dimmer(200, 20, 20)));

			CommandMenu cm = new CommandMenu(sh);
			IMenu add = new MenuAdd();
			IMenu rm = new MenuRemove();
			IMenu on = new MenuOn();
			IMenu off = new MenuOff();
			IMenu br = new MenuBreak();
			IMenu bri = new MenuBrightness();
			cm.AddSubmenu(add);
			cm.AddSubmenu(rm);
			cm.AddSubmenu(on);
			cm.AddSubmenu(off);
			cm.AddSubmenu(br);
			cm.AddSubmenu(bri);

			IMenu addLamp = new MenuAddLamp();
			add.AddSubmenu(addLamp);

			IMenu brightDown = new MenuBrightnessDecrease();
			IMenu brightUp = new MenuBrightnessIncrease();
			bri.AddSubmenu(brightUp);
			bri.AddSubmenu(brightDown);

			cm.Show();
		}
	}
}
