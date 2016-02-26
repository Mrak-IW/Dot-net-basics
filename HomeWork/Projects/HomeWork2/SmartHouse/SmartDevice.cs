using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public abstract class SmartDevice : ISmartDevice
	{
		private string name;
		private EPowerState state;
		private static uint nextID = 0;
		private ISmartHouse parent;

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

		public virtual EPowerState DeviceState
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

		public virtual ISmartHouse Parent
		{
			get
			{
				return parent;
			}

			set
			{
				parent = value;
			}
		}

		public virtual void Break()
		{
			DeviceState = EPowerState.Broken;
		}

		public virtual void Off()
		{
			if (DeviceState != EPowerState.Broken)
			{
				DeviceState = EPowerState.Off;
			}
		}

		public virtual void On()
		{
			if (DeviceState != EPowerState.Broken)
			{
				DeviceState = EPowerState.On;
			}
		}
	}
}