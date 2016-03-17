using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public abstract class Account
	{
		protected double balance;
		private string owner;

		public Account(string owner, double balance)
		{
			this.Balanse = balance;
			this.Owner = owner;
		}

		public virtual double Balanse
		{
			get
			{
				return balance;
			}
			protected set
			{
				balance = value;
			}
		}

		public virtual string Owner
		{
			get
			{
				return owner;
			}
			protected set
			{
				owner = value;
			}
		}

		public virtual double Close()
		{
			double result = Balanse;
			Balanse = 0;
			return result;
		}
	}
}