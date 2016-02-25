using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class Fridge : SmartDevice, IHaveThermostat, IOpenCloseable, IRepareable
	{
		private IAdjustable<int> dimmer;

		public Fridge(string name, IAdjustable<int> dimmer)
			: base(name)
		{
			if (dimmer.Max > 10)
			{
				throw new ArgumentOutOfRangeException(string.Format("dimmer.Max = {0}C", dimmer.Max), "Зачем нужен холодильник, который будет греть?");
			}
			if (dimmer.Min < -273)
			{
				throw new ArgumentOutOfRangeException(string.Format("dimmer.Min = {0}C", dimmer.Max), "За нарушение законов физики, программа приговорена к ексепшену");
			}
			this.dimmer = dimmer;
		}

		public bool Opened { get; set; }

		public int Temperature
		{
			get
			{
				return dimmer.CurrentLevel;
			}

			set
			{
				dimmer.CurrentLevel = value;
			}
		}

		public void Close()
		{
			Opened = false;
		}

		public void DecreaseTemperature()
		{
			dimmer.Decrease();
		}

		public void IncreaseTemperature()
		{
			dimmer.Increase();
		}

		public void Open()
		{
			Opened = true;
		}

		public bool Repare()
		{
			bool result = false;
			if (DeviceState == EPowerState.Broken)
			{
				DeviceState = EPowerState.Off;
				result = true;
			}
			return result;
		}

		public override string ToString()
		{
			string progress = new string('*', 10 * (dimmer.Max - Temperature) / (dimmer.Max - dimmer.Min));
			progress = "[" + progress + new string(' ', 10 - progress.Length) + "]";

			string res = Name + ":\t";
			switch (DeviceState)
			{
				case EPowerState.On:
					res = res + "жужжит " + progress + " " + Temperature + " C";
					break;
				case EPowerState.Off:
					res = res + "не жужжит";
					break;
				case EPowerState.Broken:
					res = res + "дымит";
					break;
			}

			return res;
		}
	}
}