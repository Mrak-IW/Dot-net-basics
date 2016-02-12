using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public class DepositAccount : Account, IGrowing
	{
		double interestRate;

		public DepositAccount(string owner, double balance, double interestRate)
			: base(owner, balance)
		{
			this.InterestRate = interestRate;
		}

		public virtual double InterestRate
		{
			get
			{
				return interestRate;
			}

			set
			{
				interestRate = value;
			}
		}

		public virtual void Grow()
		{
			balance += balance * InterestRate;
		}

		public override string ToString()
		{
			return "Карточный счёт:\n\tВладелец:\t" + Owner + "\n\tБаланс:\t\t" + Balanse + "\n\tСтавка:\t\t" + (InterestRate * 100).ToString("F2") + "%";
		}
	}
}