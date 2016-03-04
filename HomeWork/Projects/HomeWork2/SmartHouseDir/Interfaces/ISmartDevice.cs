using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork2.SmartHouseDir.Enums;

namespace HomeWork2.SmartHouseDir.Interfaces
{
	public interface ISmartDevice
	{
		string Name { get; }
		EPowerState State { get; set; }
		ISmartHouse Parent { get; set; }

		void On();
		void Off();
		void Break();
	}
}