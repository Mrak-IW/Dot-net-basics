using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9
{
	public static class Menu
	{
		const string exit = "ex";
		const string done = "do";
		const string setOwner = "o";
		const string setBalanse = "b";
		const string setInterest = "i";
		const string newAccount = "na";
		const string pickAccount = "pa";
		const string createDeposit = "de";
		const string createCard = "ca";
		const string createCurrent = "cu";
		const string increaseBalance = "up";
		const string closeAccount = "cl";
		const string withdrawMoney = "wi";
		const string putMoney = "pu";

		public static void Show()
		{
			List<Account> accounts = new List<Account>();
			string cmd = "";
			while (cmd != exit)
			{
				Console.Clear();
				Console.WriteLine("Счетов в системе: {0}\n", accounts.Count);
				Console.WriteLine("{0} - создать счёт", newAccount);
				Console.WriteLine("{0} - выбрать счёт для дальнейших действий", pickAccount);
				Console.WriteLine("{0} - выход", exit);
				Console.Write("\nВаш выбор:\t");

				cmd = Console.ReadLine();
				switch (cmd)
				{
					case newAccount:
						MenuCreateAcc(accounts);
						break;
					case pickAccount:
						MenuPickAccount(accounts);
						break;
				}
			}
		}

		private static void MenuCreateAcc(List<Account> accounts)
		{
			string cmd = "";
			Account a = null;
			while (cmd != exit)
			{
				Console.Clear();
				Console.WriteLine("Счетов в системе: {0}\n", accounts.Count);
				Console.WriteLine("{0} - создать депозитный счёт", createDeposit);
				Console.WriteLine("{0} - создать карточный счёт", createCard);
				Console.WriteLine("{0} - создать текущий счёт", createCurrent);
				Console.WriteLine("{0} - выход", exit);
				Console.Write("\nВаш выбор:\t");

				cmd = Console.ReadLine();
				switch (cmd)
				{
					case createDeposit:
						a = CreateDepositAccount();
						if (a != null)
							accounts.Add(a);
						break;
					case createCard:
						a = CreateCardAccount();
						if (a != null)
							accounts.Add(a);
						break;
					case createCurrent:
						a = CreateCurrentAccount();
						if (a != null)
							accounts.Add(a);
						break;
				}
			}
		}

		private static void MenuPickAccount(List<Account> accounts)
		{
			string cmd = "";
			int number;
			string result = null;
			while (cmd != exit)
			{
				Console.Clear();
				Console.WriteLine("Счетов в системе: {0}\n", accounts.Count);
				for (int i = 0; i < accounts.Count; i++)
				{
					Console.WriteLine("{0}. {1}", i, accounts[i]);
				}
				Console.WriteLine("<число> - выбрать счёт по номеру");
				Console.WriteLine("{0} - выход", exit);
				if (result != null)
				{
					Console.WriteLine();
					Console.WriteLine(result);
					result = null;
				}
				Console.Write("\nВаш выбор:\t");

				cmd = Console.ReadLine();
				if (int.TryParse(cmd, out number))
				{
					if (number >= 0 && number < accounts.Count)
					{
						MenuAccount(number, accounts);
					}
					else
					{
						result = "Аккаунта с таким номером не существует";
					}
				}
			}
		}

		private static void MenuAccount(int index, List<Account> accounts)
		{
			string cmd = "";
			double amount, buf;
			string result = null;
			Account acc = accounts[index];
			while (cmd != exit)
			{
				Console.Clear();
				Console.WriteLine(acc + "\n");
				if (accounts.Contains(acc))
				{
					if (acc is IGrowing)
					{
						Console.WriteLine("{0} - начислить процент", increaseBalance);
					}
					if (acc is IHaveFreeAccess)
					{
						Console.WriteLine("{0} - снять деньги", withdrawMoney);
						Console.WriteLine("{0} - положить деньги", putMoney);
					}
					Console.WriteLine("{0} - закрыть счёт", closeAccount);
				}
				Console.WriteLine("{0} - выход", exit);
				if (result != null)
				{
					Console.WriteLine();
					Console.WriteLine(result);
					result = null;
				}
				Console.Write("\nВаш выбор:\t");
				cmd = Console.ReadLine();
				if (accounts.Contains(acc))
				{
					switch (cmd)
					{
						case increaseBalance:
							if (acc is IGrowing)
							{
								(acc as IGrowing).Grow();
								result = "Процент по вкладу начислен";
							}
							break;
						case withdrawMoney:
							if (acc is IHaveFreeAccess)
							{
								Console.Write("Введите сумму:\t");
								if (double.TryParse(Console.ReadLine(), out amount))
								{
									buf = (acc as IHaveFreeAccess).Withdraw(amount);
									result = "Вы сняли " + buf + " денег";
									if (buf != amount)
									{
										result = result + "\nОперация завершилась неудачно.";
									}
								}
								else
								{
									result = "Вы ввели не число";
								}
							}
							break;
						case putMoney:
							if (acc is IHaveFreeAccess)
							{
								Console.Write("Введите сумму:\t");
								if (double.TryParse(Console.ReadLine(), out amount))
								{
									(acc as IHaveFreeAccess).Put(amount);
									result = "Вы положили " + amount + " денег";
								}
								else
								{
									result = "Вы ввели не число";
								}
							}
							break;
						case closeAccount:
							buf = acc.Balanse;
							acc.Close();
							accounts.Remove(acc);
							result = "Вы сняли " + buf + " денег и закрыли счёт";
							break;
					}
				}
			}
		}

		private static DepositAccount CreateDepositAccount()
		{
			DepositAccount a = null;

			string cmd = "";
			string owner = null;
			double? balanse = null;
			double? interestRate = null;
			double buf;

			while (cmd != exit)
			{
				bool ready = owner != null && balanse != null && interestRate != null;
				Console.Clear();
				Console.WriteLine("Создание депозитного счёта: ");
				if (owner != null)
				{
					Console.WriteLine("Владелец:\t" + owner);
				}
				if (balanse != null)
				{
					Console.WriteLine("Баланс:\t" + balanse);
				}
				if (interestRate != null)
				{
					Console.WriteLine("Процентная ставка:\t" + interestRate * 100 + "%");
				}
				Console.WriteLine("\n{0} - Задать владельца", setOwner);
				Console.WriteLine("{0} - Задать баланс", setBalanse);
				Console.WriteLine("{0} - Задать процентную ставку", setInterest);
				if (ready)
				{
					Console.WriteLine("{0} - Готово", done);
				}
				Console.WriteLine("{0} - выход", exit);
				Console.Write("\nВаш выбор:\t");

				cmd = Console.ReadLine();
				switch (cmd)
				{
					case setOwner:
						Console.Write("Введите имя:\t");
						owner = Console.ReadLine();
						break;
					case setBalanse:
						do
						{
							Console.Write("Введите баланс:\t");
						} while (!Double.TryParse(Console.ReadLine(), out buf));
						balanse = buf;
						break;
					case setInterest:
						do
						{
							Console.Write("Введите процентную ставку:\t");
						} while (!Double.TryParse(Console.ReadLine(), out buf));
						interestRate = buf / 100;
						break;
					case done:
						if (ready)
						{
							a = new DepositAccount(owner, (double)balanse, (double)interestRate);
							cmd = exit;
						}
						break;
				}
			}

			return a;
		}

		private static CardAccount CreateCardAccount()
		{
			CardAccount a = null;

			string cmd = "";
			string owner = null;
			double? balanse = null;
			double? interestRate = null;
			double buf;

			while (cmd != exit)
			{
				bool ready = owner != null && balanse != null && interestRate != null;
				Console.Clear();
				Console.WriteLine("Создание карточного счёта: ");
				if (owner != null)
				{
					Console.WriteLine("Владелец:\t" + owner);
				}
				if (balanse != null)
				{
					Console.WriteLine("Баланс:\t" + balanse);
				}
				if (interestRate != null)
				{
					Console.WriteLine("Процентная ставка:\t" + interestRate * 100 + "%");
				}
				Console.WriteLine("\n{0} - Задать владельца", setOwner);
				Console.WriteLine("{0} - Задать баланс", setBalanse);
				Console.WriteLine("{0} - Задать процентную ставку", setInterest);
				if (ready)
				{
					Console.WriteLine("{0} - Готово", done);
				}
				Console.WriteLine("{0} - выход", exit);
				Console.Write("\nВаш выбор:\t");

				cmd = Console.ReadLine();
				switch (cmd)
				{
					case setOwner:
						Console.Write("Введите имя:\t");
						owner = Console.ReadLine();
						break;
					case setBalanse:
						do
						{
							Console.Write("Введите баланс:\t");
						} while (!Double.TryParse(Console.ReadLine(), out buf));
						balanse = buf;
						break;
					case setInterest:
						do
						{
							Console.Write("Введите процентную ставку:\t");
						} while (!Double.TryParse(Console.ReadLine(), out buf));
						interestRate = buf / 100;
						break;
					case done:
						if (ready)
						{
							a = new CardAccount(owner, (double)balanse, (double)interestRate);
							cmd = exit;
						}
						break;
				}
			}

			return a;
		}

		private static CurrentAccount CreateCurrentAccount()
		{
			CurrentAccount a = null;

			string cmd = "";
			string owner = null;
			double? balanse = null;
			double buf;

			while (cmd != exit)
			{
				bool ready = owner != null && balanse != null;
				Console.Clear();
				Console.WriteLine("Создание депозитного счёта: ");
				if (owner != null)
				{
					Console.WriteLine("Владелец:\t" + owner);
				}
				if (balanse != null)
				{
					Console.WriteLine("Баланс:\t" + balanse);
				}
				Console.WriteLine("\n{0} - Задать владельца", setOwner);
				Console.WriteLine("{0} - Задать баланс", setBalanse);
				if (ready)
				{
					Console.WriteLine("{0} - Готово", done);
				}
				Console.WriteLine("{0} - выход", exit);
				Console.Write("\nВаш выбор:\t");

				cmd = Console.ReadLine();
				switch (cmd)
				{
					case setOwner:
						Console.Write("Введите имя:\t");
						owner = Console.ReadLine();
						break;
					case setBalanse:
						do
						{
							Console.Write("Введите баланс:\t");
						} while (!Double.TryParse(Console.ReadLine(), out buf));
						balanse = buf;
						break;
					case done:
						if (ready)
						{
							a = new CurrentAccount(owner, (double)balanse);
							cmd = exit;
						}
						break;
				}
			}

			return a;
		}
	}
}