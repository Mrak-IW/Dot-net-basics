using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HomeWork2;
using Lab14;

namespace Lab15
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			string taskNum = Console.ReadLine();
			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;

				case "1":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Menu.Show();
					}
					break;

				case "2":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Regex r = new Regex(@"^\D\w{1,9}$");
						string ans;

						do
						{
							Console.Write("Введите строку:\t");
							ans = Console.ReadLine();
							Console.WriteLine("{0} - {1}", ans, r.IsMatch(ans) ? "TRUE" : "не TRUE");
						} while (ans != "exit");
					}
					break;

				case "3":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Regex r = new Regex(@"^(\+\d)?\d\(\d{3}\)\d{3}-\d{2}-\d{2}$");
						string ans;

						do
						{
							Console.Write("Введите строку:\t");
							ans = Console.ReadLine();
							Console.WriteLine("{0} - {1}", ans, r.IsMatch(ans) ? "TRUE" : "не TRUE");
						} while (ans != "exit");
					}
					break;

				case "test":
					{
						string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
						Regex r = new Regex(@"\w*губ\w*");

						Console.WriteLine(s);
						MatchCollection mc = r.Matches(s);
						Console.WriteLine("\nRE: \"{0}\"", r);
						foreach (Match m in mc)
						{
							Console.WriteLine(m.Value);
						}

						r = new Regex(@"губ\w*");
						mc = r.Matches(s);
						Console.WriteLine("\nRE: \"{0}\"", r);
						foreach (Match m in mc)
						{
							Console.WriteLine(m.Value);
						}

						r = new Regex(@"(?<=\S)губ\w*");
						mc = r.Matches(s);
						Console.WriteLine("\nRE: \"{0}\"", r);
						foreach (Match m in mc)
						{
							Console.WriteLine(m.Value);
						}
					}
					break;
			}
		}
	}
}
