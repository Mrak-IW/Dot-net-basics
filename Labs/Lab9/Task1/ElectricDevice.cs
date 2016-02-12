namespace Lab9
{
	public abstract class ElectricDevice : ISwitchable
	{
		public EDeviceState PowerState { get; set; }

		public ElectricDevice()
		{
			this.PowerState = EDeviceState.OFF;
		}

		public void TurnOff()
		{
			this.PowerState = EDeviceState.OFF;
		}

		public void TurnOn()
		{
			if (this.PowerState != EDeviceState.BROKEN)
			{
				this.PowerState = EDeviceState.ON;
			}
		}
	}
}