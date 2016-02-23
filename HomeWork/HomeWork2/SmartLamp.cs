using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class SmartLamp : SmartDevice, IBrightable
	{
		IAdjustable<int> dimmer;

		public SmartLamp(uint ID, IAdjustable<int> dimmer) : base(ID)
		{
			this.dimmer = dimmer;
		}

		public SmartLamp(IAdjustable<int> dimmer) : base()
		{
			this.dimmer = dimmer;
		}

		public virtual int BrightnessMax
		{
			get
			{
				return dimmer.Max;
			}
		}

		public virtual int BrightnessMin
		{
			get
			{
				return dimmer.Min;
			}
		}

		public int Brightness
		{
			get
			{
				return DeviceState == EPowerState.On ? dimmer.CurrentLevel : 0;
			}

			set
			{
				dimmer.CurrentLevel = value;
			}
		}

		public virtual void DecreaseBrightness()
		{
			dimmer.Decrease();
		}

		public virtual void IncreaseBrightness()
		{
			dimmer.Increase();
		}

		public override string ToString()
		{
			string progress = new string('*', 10 * Brightness / BrightnessMax);
			progress = "[" + progress + new string(' ', 10 - progress.Length) + "]";

			string res = "Лампа[" + ID.ToString("D4") + "]:\t";
			switch (DeviceState)
			{
				case EPowerState.On:
					res = res + "включена " + progress + " " + Brightness + " лм";
					break;
				case EPowerState.Off:
					res = res + "выключена";
					break;
				case EPowerState.Broken:
					res = res + "неисправна";
					break;
			}

			return res;
		}
	}
}