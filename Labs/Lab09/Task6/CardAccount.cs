using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public class CardAccount : Account, IGrowing, IHaveFreeAccess
	{
		double interestRate;

		public CardAccount(string owner, double balance, double interestRate)
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
			return "Карточный счёт:\n\tВладелец:\t" + Owner + "\n\tБаланс:\t\t" + Balanse + "\n\tСтавка:\t\t" + (InterestRate * 100).ToString("F2") + "%";
		}
	}
}