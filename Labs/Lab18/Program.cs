using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab18
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			string taskNum = Console.ReadLine();

			//Начальные условия
			List<Animal> animals = new List<Animal>();
			animals.Add(new Animal { Name = "Cat", LegsCount = 4 });
			animals.Add(new Animal { Name = "Duck", LegsCount = 2 });
			animals.Add(new Animal { Name = "Lion", LegsCount = 4 });
			animals.Add(new Animal { Name = "Snake", LegsCount = 0 });
			animals.Add(new Animal { Name = "Ostrich", LegsCount = 2 });
			animals.Add(new Animal { Name = "Elephant", LegsCount = 4 });

			List<Zoo> zoos = new List<Zoo>();
			zoos.Add(new Zoo { AnimalName = "Cat", ZooName = "South" });
			zoos.Add(new Zoo { AnimalName = "Snake", ZooName = "North" });

			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;

				case "1":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
						// Ваш код
						var res =
							from val in numbers
							where val % 2 == 1
							select val;
						foreach (var s in res)
						{
							Console.Write("{0} ", s);
						}
						Console.WriteLine();

						// Ваш код
						res = numbers.Where(val => val % 2 == 1);
						foreach (var s in res)
						{
							Console.Write("{0} ", s);
						}
						Console.WriteLine();
					}
					break;
				case "2":
					Console.WriteLine("Задание {0}:", taskNum);
					{

						// Ваш код для выбора двуногих животных
						var res = animals.Where(creature => creature.LegsCount == 2);
						foreach (var s in res)
						{
							Console.WriteLine("{0} имеет ног: {1}", s.Name, s.LegsCount);
						}
						Console.WriteLine();

						// Ваш код для выбора двуногих животных
						res =
							from creature in animals
							where creature.LegsCount == 2
							select creature;
						foreach (var s in res)
						{
							Console.WriteLine("{0} имеет ног: {1}", s.Name, s.LegsCount);
						}
					}
					break;

				case "3":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						// Ваш код
						var res =
							from creature in animals
							select new
							{
								ID = creature.GetHashCode(),
								Name = creature.Name
							};
						foreach (var s in res)
						{
							Console.WriteLine(s.ID + ": " + s.Name);
						}
						Console.WriteLine();

						// Ваш код
						res = animals.Select(creatue => new
						{
							ID = creatue.GetHashCode(),
							Name = creatue.Name
						});
						foreach (var s in res)
						{
							Console.WriteLine(s.ID + ": " + s.Name);
						}
					}
					break;

				case "4":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						// Ваш код
						var res =
							from creature in animals
							orderby creature.LegsCount descending
							select creature;
						foreach (var s in res)
						{
							Console.WriteLine("{0}\tног: {1}", s.Name, s.LegsCount);
						}
						Console.WriteLine();

						res = animals.OrderByDescending(cr => cr.LegsCount).ThenBy(cr => cr.Name);
						foreach (var s in res)
						{
							Console.WriteLine("{0}\tног: {1}", s.Name, s.LegsCount);
						}
					}
					break;

				case "5":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						int[] array1 = { 1, 2, 3, 1 };
						int[] array2 = { 2, 3, 4 };

						Console.WriteLine("arr1 = [{0}]", ToString(array1));
						Console.WriteLine("arr2 = [{0}]", ToString(array2));
						Console.WriteLine();

						var res = array1.Except(array2);
						Console.WriteLine("arr1 NOT arr2 = [{0}]", ToString(res));

						res = array1.Intersect(array2);
						Console.WriteLine("arr1 AND arr2 = [{0}]", ToString(res));

						res = array1.Union(array2);
						Console.WriteLine("arr1 OR arr2 = [{0}]", ToString(res));

						res = array1.Distinct();
						Console.WriteLine("arr1.Distinct() = [{0}]", ToString(res));
					}
					break;

				case "6":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						foreach (var s in animals)
						{
							Console.WriteLine("{0}\tног: {1}", s.Name, s.LegsCount);
						}
						Console.WriteLine();

						Console.WriteLine("Всего существ: {0}", animals.Count);

						int totalLegs = animals.Sum(cr => cr.LegsCount);
						Console.WriteLine("Всего ног: {0}", totalLegs);

						double avgLegs = animals.Average(cr => cr.LegsCount);
						Console.WriteLine("В среднем ног: {0}", avgLegs);

						var res = animals.Skip(1).Take(3);
						Console.WriteLine("Три животных, начиная со второго:");
						Console.WriteLine(ToString(res.Select(cr => cr.Name)));
					}
					break;

				case "7":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						var res =
							from creature in animals
							group creature by creature.LegsCount;

						Console.WriteLine();
						foreach (var item in res)
						{
							Console.WriteLine("Число ног {0}:", item.Key);
							Console.WriteLine("  " + ToString(item.Select(cr => cr.Name)).Replace(" ", "\n  "));
							Console.WriteLine();
						}
					}
					break;

				case "8":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						var res =
							from cr in animals
							join zoo in zoos
							on cr.Name equals zoo.AnimalName
							select new
							{
								Zoo = zoo.ZooName,
								Animal = cr.Name,
								LegsCount = cr.LegsCount
							};

						foreach (var item in res)
						{
							Console.WriteLine("{0}: {1} (ног - {2})", item.Zoo, item.Animal, item.LegsCount);
						}
					}
					break;
			}
		}

		static string ToString<T>(IEnumerable<T> collection)
		{
			string res = "";
			foreach (T item in collection)
			{
				res = string.Join(" ", res, item);
			}
			return res.Trim();
		}
	}
}
