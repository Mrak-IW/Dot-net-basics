using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7;
using System.Collections;

namespace Lab13
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			int taskNum = Int32.Parse(Console.ReadLine());
			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;
				case 1:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						string ans = null;
						do
						{
							Console.Clear();
							Console.WriteLine("al - на ArrayList");
							Console.WriteLine("lt - на List<T>");
							Console.WriteLine("ll - на LinkedList<T>");
							Console.WriteLine("di - на Dictionary<T, V>");
							Console.WriteLine("exit - выход");
							ans = Console.ReadLine();
							Console.Clear();
							switch (ans)
							{
								case "al":
									Console.WriteLine("Вариант на ArrayList:");
									{
										ArrayList arrAnimal = new ArrayList();
										arrAnimal.Add(new Dog { Name = "Шарик" });
										arrAnimal.Add(new Cat { Name = "Кусака" });
										arrAnimal.Add(new Cat { Name = "Ленивец" });
										arrAnimal.Add(new Dog { Name = "Джек" });
										arrAnimal.Add(new Cat { Name = "Черныш" });
										arrAnimal.Add(new Dog { Name = "Арчи" });
										foreach (Animal a in arrAnimal)
										{
											// Ваш код
											a.Bite();
											if (a is Cat)
											{
												Console.Write("через as: ");
												(a as Cat).Purr();
												Console.Write("через cast: ");
												((Cat)a).Purr();
											}
											Console.Write("через жопу: ");
											try
											{
												((Cat)a).Purr();
											}
											catch (Exception e)
											{
												Console.WriteLine("EXCEPTION - " + a.Name + " не кошка и не мурчит");
											}
										}
									}
									break;
								case "lt":
									Console.WriteLine("Вариант на List<T>:");
									{
										List<Animal> arrAnimal = new List<Animal>();
										arrAnimal.Add(new Dog { Name = "Шарик" });
										arrAnimal.Add(new Cat { Name = "Кусака" });
										arrAnimal.Add(new Cat { Name = "Ленивец" });
										arrAnimal.Add(new Dog { Name = "Джек" });
										arrAnimal.Add(new Cat { Name = "Черныш" });
										arrAnimal.Add(new Dog { Name = "Арчи" });
										foreach (Animal a in arrAnimal)
										{
											// Ваш код
											a.Bite();
											if (a is Cat)
											{
												Console.Write("через as: ");
												(a as Cat).Purr();
												Console.Write("через cast: ");
												((Cat)a).Purr();
											}
											Console.Write("через жопу: ");
											try
											{
												((Cat)a).Purr();
											}
											catch (Exception e)
											{
												Console.WriteLine("EXCEPTION - " + a.Name + " не кошка и не мурчит");
											}
										}
									}
									break;
								case "ll":
									Console.WriteLine("Вариант на LinkedList<T>:");
									{
										LinkedList<Animal> arrAnimal = new LinkedList<Animal>();
										arrAnimal.AddLast(new Dog { Name = "Шарик" });
										arrAnimal.AddLast(new Cat { Name = "Кусака" });
										arrAnimal.AddLast(new Cat { Name = "Ленивец" });
										arrAnimal.AddLast(new Dog { Name = "Джек" });
										arrAnimal.AddLast(new Cat { Name = "Черныш" });
										arrAnimal.AddLast(new Dog { Name = "Арчи" });
										foreach (Animal a in arrAnimal)
										{
											// Ваш код
											a.Bite();
											if (a is Cat)
											{
												Console.Write("через as: ");
												(a as Cat).Purr();
												Console.Write("через cast: ");
												((Cat)a).Purr();
											}
											Console.Write("через жопу: ");
											try
											{
												((Cat)a).Purr();
											}
											catch (Exception e)
											{
												Console.WriteLine("EXCEPTION - " + a.Name + " не кошка и не мурчит");
											}
										}
									}
									break;
								case "di":
									Console.WriteLine("Вариант на Dictionary<T, V>:");
									{
										Dictionary<string, Animal> arrAnimal = new Dictionary<string, Animal>();
										arrAnimal.Add("Шарик", new Dog { Name = "Шарик" });
										arrAnimal.Add("Кусака", new Cat { Name = "Кусака" });
										arrAnimal.Add("Ленивец", new Cat { Name = "Ленивец" });
										arrAnimal.Add("Джек", new Dog { Name = "Джек" });
										arrAnimal.Add("Черныш", new Cat { Name = "Черныш" });
										arrAnimal.Add("Арчи", new Dog { Name = "Арчи" });
										foreach (Animal a in arrAnimal.Values)
										{
											// Ваш код
											a.Bite();
											if (a is Cat)
											{
												Console.Write("через as: ");
												(a as Cat).Purr();
												Console.Write("через cast: ");
												((Cat)a).Purr();
											}
											Console.Write("через жопу: ");
											try
											{
												((Cat)a).Purr();
											}
											catch (Exception e)
											{
												Console.WriteLine("EXCEPTION - " + a.Name + " не кошка и не мурчит");
											}
										}
									}
									break;
							}
							if (ans != "exit")
							{
								Console.WriteLine("Нажмите любую клавишу для продолжения");
								Console.ReadKey();
							}
						} while (ans != "exit");
					}
					break;
				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						string someText = "Есть некий текст \"Nikolay\". Замените \"Nikolay\" в этом тексте все слова \"Nikolay\" на \"Oleg\".";
						Console.WriteLine(someText);
						Console.WriteLine(someText.Replace("Nikolay", "Oleg"));
					}
					break;
				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						string someText = "Сегодня мы с вами рассмотрели, как работать со строками в Си-шарп. Были описаны основные операторы и методы, которые используются для работы со строками";
						Console.WriteLine("|" + someText + "|");
						someText = someText.Substring(someText.IndexOf('.') + 2, someText.LastIndexOf(',') - someText.IndexOf('.') - 2);
						Console.WriteLine("|" + someText + "|");
					}
					break;
				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						string str = "Login1,LOgin2,login3,loGin4";
						Console.WriteLine(str);
						string[] strarr = str.Split(',');
						foreach (string item in strarr)
						{
							Console.WriteLine(item.ToLower());
						}
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						string ans = null;
						int count;
						int i;
						List<string> lst = new List<string>();
						List<string> lstReady = new List<string>();
						lst.Add("Исходная строка");
						lstReady.Add("Обработанная строка");

						do
						{
							Console.Clear();
							Console.WriteLine("Добавлено {0} строк:", lst.Count - 1);
							for (i = 1; i < lst.Count; i++)
							{
								Console.WriteLine(lst[i]);
							}
							Console.Write("Добвить ещё одну (end - закончить):\t");
							ans = Console.ReadLine();
							lst.Add(ans);
						} while (ans != "end");

						for (i = 1; i < lst.Count; i++)
						{
							count = lst[i].Intersect("0123456789").Count();
							lstReady.Add(string.Format("{0}numbers({2}): {1}", (count > 0 ? "" : "no "), lst[i], count));
						}

						//Находим ширину таблицы
						int width = 0;
						foreach (string s in lst)
						{
							if (s.Length > width)
							{
								width = s.Length;
							}
						}

						int widthReady = 0;
						foreach (string s in lstReady)
						{
							if (s.Length > widthReady)
							{
								widthReady = s.Length;
							}
						}

						//Печатаем таблицу
						char horFrame2 = (char)0x2550;
						char horFrame1 = (char)0x2500;
						char verFrame2 = (char)0x2551;
						char tFrame = (char)0x2566;
						char tUpFrame = (char)0x2569;
						char tRightFrame = (char)0x255F;
						char tLeftFrame = (char)0x2562;
						char crossFrame = (char)0x256B;
						char ulCorner = (char)0x2554;
						char urCorner = (char)0x2557;
						char dlCorner = (char)0x255A;
						char drCorner = (char)0x255D;

						string upperFrame = string.Concat(ulCorner, new string(horFrame2, width + 2), tFrame, new string(horFrame2, widthReady + 2), urCorner);
						string lowerFrame = string.Concat(dlCorner, new string(horFrame2, width + 2), tUpFrame, new string(horFrame2, widthReady + 2), drCorner);
						string middleFrame = string.Concat(tRightFrame, new string(horFrame1, width + 2), crossFrame, new string(horFrame1, widthReady + 2), tLeftFrame);

						Console.WriteLine(upperFrame);
						for (i = 0; i < lst.Count; i++)
						{
							ans = string.Format("{0} {1}{2} {0} {3}{4} {0}",
								verFrame2,
								lst[i],
								new string(' ', width - lst[i].Length),
								lstReady[i],
								new string(' ', widthReady - lstReady[i].Length));
							Console.WriteLine(ans);
							Console.WriteLine(i < lst.Count - 1 ? middleFrame : lowerFrame);
						}
					}
					break;
			}
		}
	}
}
