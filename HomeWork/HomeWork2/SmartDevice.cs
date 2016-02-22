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

		public SmartDevice(ISmartHouse parent)
		{
			ID = nextID++;
			Parent = parent;
		}

		public SmartDevice(uint ID, ISmartHouse parent) :this(parent)
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
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
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