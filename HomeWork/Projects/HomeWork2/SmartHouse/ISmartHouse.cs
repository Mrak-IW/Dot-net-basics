using System.Collections.Generic;

namespace HomeWork2
{
	public interface ISmartHouse
	{
		ISmartDevice this[string name] { get; }
		ISmartDevice this[int index] { get; }

		int Count { get; }

		bool AddDevice(ISmartDevice device);
		void RemoveDevice(string name);
		void TurnDeviceOff(string name);
		void TurnDeviceOn(string name);
	}
}