using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class Fridge : SmartDevice, IHaveThermostat, IOpenCloseable, IRepareable
	{
		int temperature;
		public virtual int TempMin { get; protected set; }
		public virtual int TempMax { get; protected set; }

		public Fridge(string name, int temp, int tempMax, int tempMin)
			: base(name)
		{
			if (tempMax > 10)
			{
				throw new ArgumentOutOfRangeException(string.Format("dimmer.Max = {0}C", tempMax), "Зачем нужен холодильник, который будет греть?");
			}
			if (tempMin < -273)
			{
				throw new ArgumentOutOfRangeException(string.Format("dimmer.Min = {0}C", tempMin), "За нарушение законов физики, программа приговорена к ексепшену");
			}

			this.TempMax = tempMax;
			this.TempMin = tempMin;
			this.Temperature = temp;
		}

		public virtual bool Opened { get; set; }

		public virtual int Temperature
		{
			get
			{
				return temperature;
			}

			set
			{
				if (value >= TempMin && value <= TempMax)
				{
					temperature = value;
				}
			}
		}

		public virtual void Close()
		{
			Opened = false;
		}

		public virtual void DecreaseTemperature()
		{
			Temperature--;
		}

		public virtual void IncreaseTemperature()
		{
			Temperature++;
		}

		public virtual void Open()
		{
			Opened = true;
		}

		public virtual bool Repare()
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
			string res = Name + ":\t";
			switch (DeviceState)
			{
				case EPowerState.On:
					string progress = new string('*', 10 * (TempMax - Temperature) / (TempMax - TempMin));
					progress = string.Format("[{2}|{0}{1}|{3}]", progress, new string(' ', 10 - progress.Length), TempMin, TempMax);

					res = string.Format("{0}жужжит {1} {2}C", res, progress, Temperature);
					break;
				case EPowerState.Off:
					res = res + "не жужжит";
					break;
				case EPowerState.Broken:
					res = res + "дымит";
					break;
			}

			res = res + (Opened ? " : открыт" : " : закрыт");

			return res;
		}
	}
}