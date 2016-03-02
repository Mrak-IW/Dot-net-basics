using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public interface ISmartDevice
	{
		string Name { get; }
		EPowerState State { get; set; }
		//ISmartHouse Parent { get; set; }

		void On();
		void Off();
		void Break();
	}
}