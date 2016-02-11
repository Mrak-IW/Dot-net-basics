using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public class TvSet : ElectricDevice
	{
		uint channel = 0;

		public void NextChannel()
		{
			if (this.PowerState == EDeviceState.ON)
			{
				this.channel++;
			}
		}

		public void PreviousChannel()
		{
			if (this.PowerState == EDeviceState.ON && this.channel > 0)
			{
				this.channel--;
			}
		}

		public void SetChannel(uint channel)
		{
			this.channel = channel;
		}

		public override string ToString()
		{
			string state = (PowerState == EDeviceState.ON ? "канал [" + this.channel + "]" : "выключен");
			return "Телевизирь: " + state;
		}
	}
}