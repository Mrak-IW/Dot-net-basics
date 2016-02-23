using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public abstract class SmartDevice : ISmartDevice
	{
		private uint id;
		private EPowerState state;
		private static uint nextID = 0;
		private ISmartHouse parent;

		public SmartDevice()
		{
			ID = nextID++;
		}

		public SmartDevice(uint ID) :this()
		{
			this.ID = ID;
		}

		public virtual uint ID
		{
			get
			{
				return id;
			}
			protected set
			{
				id = value;
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
			DeviceState = EPowerState.Off;
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