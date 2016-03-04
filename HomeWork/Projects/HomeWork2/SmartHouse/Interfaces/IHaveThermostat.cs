using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public interface IHaveThermostat
	{
		int Temperature { get; set; }
		int TempMax { get; }
		int TempMin { get; }

		void IncreaseTemperature();
		void DecreaseTemperature();
	}
}