﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	[Serializable]
	public abstract class SmartDevice : ISmartDevice
	{
		private string name;
		private EPowerState state;
		private static uint nextID = 0;
		//private ISmartHouse parent;

		public SmartDevice(string name)
		{
			this.Name = name;
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
			protected set
			{
				name = value;
			}
		}

		public virtual EPowerState State
		{
			get
			{
				return state;
			}

			set
			{
				state = value;
			}
		}

		//public virtual ISmartHouse Parent
		//{
		//	get
		//	{
		//		return parent;
		//	}

		//	set
		//	{
		//		parent = value;
		//	}
		//}

		public virtual void Break()
		{
			State = EPowerState.Broken;
		}

		public virtual void Off()
		{
			if (State != EPowerState.Broken)
			{
				State = EPowerState.Off;
			}
		}

		public virtual void On()
		{
			if (State != EPowerState.Broken)
			{
				State = EPowerState.On;
			}
		}
	}
}