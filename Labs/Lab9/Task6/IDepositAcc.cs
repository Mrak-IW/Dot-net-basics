using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public interface IGrowing
	{
		double InterestRate { get; set; }
		void Grow();
	}
}