using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public class CurrentAccount : Account, IHaveFreeAccess
	{
		public CurrentAccount(string owner, double balance)
			: base(owner, balance)
		{
		}

		public virtual void Put(double amount)
		{
			if (amount > 0)
			{
				balance += amount;
			}
		}

		public virtual double Withdraw(double amount)
		{
			double result = 0;

			if (amount > 0 && amount <= balance)
			{
				balance -= amount;
				result = amount;
			}

			return result;
		}

		public override string ToString()
		{
			return "Текущий счёт:\n\tВладелец:\t"+Owner+"\n\tБаланс:\t"+Balanse;
		}
	}
}