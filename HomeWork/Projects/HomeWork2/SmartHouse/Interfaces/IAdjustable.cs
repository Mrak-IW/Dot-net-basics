using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public interface IAdjustable<T>
	{
		T CurrentLevel { get; set; }
		T Max { get; }
		T Min { get; }
		int Step { get; }

		void Increase();
		void Decrease();
	}
}