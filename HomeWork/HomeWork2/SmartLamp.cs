using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class SmartLamp : SmartDevice, IBrightable
	{
		IAdjustable<int> dimmer;

		public SmartLamp(uint ID, ISmartHouse parent, IAdjustable<int> dimmer) : base(ID, parent)
		{
			this.dimmer = dimmer;
		}

		public SmartLamp(SmartHouse parent, IAdjustable<int> dimmer) : base(parent)
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
				return dimmer.CurrentLevel;
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
			return base.ToString();
		}
	}
}