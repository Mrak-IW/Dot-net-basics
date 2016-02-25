using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class SmartHouse : ISmartHouse
	{
		private SortedList<string, ISmartDevice> devices;

		public SmartHouse()
		{
			devices = new SortedList<string, ISmartDevice>();
		}

		public virtual int Count
		{
			get
			{
				return devices.Count;
			}
		}

		public ISmartDevice this[int index]
		{
			get
			{
				return devices.Values[index];
			}
		}

		public virtual ISmartDevice this[string name]
		{
			get
			{
				if (devices.ContainsKey(name))
				{
					return devices[name];
				}
				else
				{
					return null;
				}
			}
		}

		public virtual bool AddDevice(ISmartDevice device)
		{
			bool result = device != null;

			if (result)
			{
				if (this[device.Name] == null)
				{
					devices.Add(device.Name, device);
					device.Parent = this;
				}
				else
				{
					result = false;
				}
			}

			return result;
		}

		public virtual void RemoveDevice(string name)
		{
			devices.Remove(name);
		}

		public void TurnDeviceOff(string name)
		{
			this[name].Off();
		}

		public void TurnDeviceOn(string name)
		{
			this[name].On();
		}
	}
}