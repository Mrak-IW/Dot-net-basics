using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab14
{
	public interface ISmartDevice
	{
		string Name { get; }
		EPowerState DeviceState { get; set; }
		ISmartHouse Parent { get; set; }

		void On();
		void Off();
		void Break();
	}
}