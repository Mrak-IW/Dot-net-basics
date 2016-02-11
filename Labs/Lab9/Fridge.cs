using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public class Fridge : ElectricDevice
	{
		public override string ToString()
		{
			return "Холодильник: " + (PowerState == EDeviceState.ON ? "жужжит" : "не жужжит");
		}
	}
}