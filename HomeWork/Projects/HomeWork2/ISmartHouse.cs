namespace HomeWork2
{
	public interface ISmartHouse
	{
		ISmartDevice this[int i] { get; }

		int Count { get; }

		void AddDevice(ISmartDevice device);
		ISmartDevice GetDeviceByID(uint ID);
		void RemoveDevice(ISmartDevice device);
		void RemoveDevice(uint ID);
		void TurnDeviceOff(uint ID);
		void TurnDeviceOn(uint ID);
	}
}