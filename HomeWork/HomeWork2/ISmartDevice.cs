using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public interface ISmartDevice
	{
		uint ID { get; }
		EPowerState DeviceState { get; set; }
		ISmartHouse Parent { get; set; }

		void On();
		void Off();
		void Break();
	}
}