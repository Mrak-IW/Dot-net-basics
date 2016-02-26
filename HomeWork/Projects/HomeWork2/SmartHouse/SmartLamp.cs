﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class SmartLamp : SmartDevice, IBrightable
	{
		IAdjustable<int> dimmer;

		public SmartLamp(string name, IAdjustable<int> dimmer) : base(name)
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
				return State == EPowerState.On ? dimmer.CurrentLevel : 0;
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
			string res = Name + ":\t";
			switch (State)
			{
				case EPowerState.On:
					string progress = new string('+', 10 * Brightness / BrightnessMax);
					progress = string.Format("[{2}|{0}{1}|{3}]", progress, new string(' ', 10 - progress.Length), dimmer.Min, dimmer.Max);

					res = string.Format("{0}включена {1} {2}лм", res, progress, Brightness);
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