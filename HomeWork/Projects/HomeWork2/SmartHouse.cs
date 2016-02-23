using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class SmartHouse : ISmartHouse
	{
		private List<ISmartDevice> devices;

		public SmartHouse()
		{
			devices = new List<ISmartDevice>();
		}

		public virtual int Count
		{
			get
			{
				return devices.Count;
			}
		}

		public virtual ISmartDevice this[int i]
		{
			get
			{
				return devices[i];
			}
		}

		public virtual void AddDevice(ISmartDevice device)
		{
			if (device != null)
			{
				devices.Add(device);
				device.Parent = this;
			}
		}

		public virtual ISmartDevice GetDeviceByID(uint ID)
		{
			ISmartDevice result = null;
			foreach (ISmartDevice dev in devices)
			{
				if (dev.ID == ID)
				{
					result = dev;
					break;
				}
			}
			return result;
		}

		public virtual void RemoveDevice(ISmartDevice device)
		{
			devices.Remove(device);
		}

		public virtual void RemoveDevice(uint ID)
		{
			RemoveDevice(GetDeviceByID(ID));
		}

		public void TurnDeviceOff(uint ID)
		{
			GetDeviceByID(ID).Off();
		}

		public void TurnDeviceOn(uint ID)
		{
			GetDeviceByID(ID).On();
		}
	}
}