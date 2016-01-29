using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
	class TvSet
	{
		uint channel = 0;
		
		public void NextChannel()
		{
			this.channel++;
		}

		public void PreviousChannel()
		{
			if (this.channel > 0)
			{
				this.channel--;
			}
		}

		public void SetChannel(uint channel)
		{
			this.channel = channel;
		}

		public override string ToString()
		{
			return "Телевизирь [" + this.channel + "]";
		}
	}
}
