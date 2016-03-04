using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork2.SmartHouseDir.Abstracts;
using HomeWork2.SmartHouseDir.Interfaces;
using HomeWork2.SmartHouseDir.Enums;

namespace HomeWork2.SmartHouseDir.Classes
{
	public class Clock : SmartDevice, IHaveClock
	{
		public Clock(string name) : base(name) { }

		public virtual DateTime Time
		{
			get
			{
				return DateTime.Now;
			}
		}

		public override string ToString()
		{
			string result = null;
			switch (State)
			{
				case EPowerState.On:
					result = string.Format("{0}:\t{1}", Name, Time.ToLongTimeString());
					break;
				case EPowerState.Off:
					result = string.Format("{0}:\tчасы выключены", Name);
					break;
				case EPowerState.Broken:
					result = string.Format("{0}:\tчасы сломаны", Name);
					break;
			}
			return result;
		}
	}
}