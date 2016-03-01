namespace Lab9
{
	public class Fridge : ElectricDevice
	{
		public override string ToString()
		{
			return "Холодильник: " + (PowerState == EDeviceState.ON ? "жужжит" : "не жужжит");
		}
	}
}