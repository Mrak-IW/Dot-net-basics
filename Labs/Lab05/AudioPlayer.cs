using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
	class AudioPlayer
	{
		int volume = 0;
		public int Volume
		{
			get
			{
				return this.volume;
			}
			set
			{
				if (value >= 0)
				{
					if (value <= 100)
					{
						this.volume = value;
					}
					else
					{
						this.volume = 100;
					}
				}
				else
				{
					this.volume = 0;
				}
			}
		}

		public override string ToString()
		{
			string res = "[";
			for (int i = 0; i <= 100; i += 10)
			{
				res = res + (i <= volume ? "|" : " ");
			}
			res = res + "] " + this.volume;
			return res;
		}
	}
}
