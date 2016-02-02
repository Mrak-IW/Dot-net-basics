using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
{
	class LinearMovement
	{
		private double time;
		private double distance;

		public double Time
		{
			get
			{
				return time;
			}
			set
			{
				if (value < 0)
				{
					throw new ExceptionTimeBelowZero("Юзер кака. Время меньше нуля.");
				}
				else
				{
					time = value;
				}
			}
		}
		public double Distance
		{
			get
			{
				return distance;
			}
			set
			{
				if (value < 0)
				{
					throw new ExceptionTimeBelowZero("Юзер кака. Дистанция меньше нуля.");
				}
				else
				{
					distance = value;
				}
			}
		}
		public double Speed
		{
			get
			{
				return Distance / Time;
			}
		}
	}

	class ExceptionTimeBelowZero : Exception
	{
		public ExceptionTimeBelowZero(string message)
			:base(message)
		{ }
	}

	class ExceptionDistanceBelowZero : Exception
	{
		public ExceptionDistanceBelowZero(string message)
			: base(message)
		{ }
	}
}
