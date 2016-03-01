using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
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
						Circle c1 = new Circle();
						Circle c2 = new Circle(0, 0, 20);
						double x = 21;
						double y = 15;
						Console.WriteLine(c1);
						Console.WriteLine("Точка ({0}, {1}) находится {2} фигуры {3}", x, y, (c2.PointIsInCircle(x,y) ? "внутри" : "снаружи"), c2);
					}
					break;

				case 2:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Point[] tri = new Point[3];
						tri[0] = new Point { x = 0, y = 0 };
						tri[1] = new Point { x = 1, y = 1 };
						tri[2] = new Point { x = 2, y = 2 };
						GeoFigure triangle = new GeoTriangle(tri);
						GeoCircle circle = new GeoCircle(0, 0, 10);
						triangle.Draw();
						circle.Draw();
					}
					break;

				case 3:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Square sq = new Square(10);
						Qube q = new Qube(10);
						Console.WriteLine(sq);
						Console.WriteLine(q);
					}
					break;

				case 4:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Point p1 = new Point { x = 1, y = 1 };
						Point p2 = new Point { x = 2, y = 2 };
						Point p3 = new Point { x = 3, y = -1 };
						Rectangle r1 = new Rectangle(p1, p2);
						Rectangle r2 = new Rectangle(p3, p2);
						Rectangle r3 = new Rectangle(p1, p2);
						Console.WriteLine("Прямоугольники:\nR1:\t{0}\t{1:X}\nR2:\t{2}\t{3:X}\nR3:\t{4}\t{5:X}", r1, r1.GetHashCode(), r2, r2.GetHashCode(), r3, r3.GetHashCode());
						Console.WriteLine("R1 == R2:\t{0}\nR1 == R3:\t{1}", r1.Equals(r2), r1.Equals(r3));
					}
					break;
				case 5:
					Console.WriteLine("Задание {0}:", taskNum);
					{
						object[] arrObj = new object[6];
						arrObj[0] = 5;
						arrObj[1] = "a";
						arrObj[2] = 's';
						arrObj[3] = 4.5;
						arrObj[4] = new object();
						arrObj[5] = (long)200;

						int a1 = (int)arrObj[0];
						string a2 = (string)arrObj[1];
						char a3 = (char)arrObj[2];
						double a4 = (double)arrObj[3];
						object a5 = arrObj[4];
						byte a6 = (byte)(long)arrObj[5];

						Console.WriteLine(a1);
						Console.WriteLine(a2);
						Console.WriteLine(a3);
						Console.WriteLine(a4);
						Console.WriteLine(a5);
						Console.WriteLine(a6);

					}
					break;
			}
		}
	}
}
