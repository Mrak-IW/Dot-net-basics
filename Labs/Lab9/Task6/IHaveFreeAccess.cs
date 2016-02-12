using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public interface IHaveFreeAccess
	{
		void Put(double amount);
		double Withdraw(double amount);
	}
}