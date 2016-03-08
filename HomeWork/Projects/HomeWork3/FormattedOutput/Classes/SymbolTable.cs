using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork3.FormattedOutput.Interfaces;
using System.Collections;

namespace HomeWork3.FormattedOutput.Classes
{
	public class SymbolTable
	{
		public string[] Header { get; set; }

		public SymbolTable(params string[] header)
		{
			Header = header;
		}

		public string CreateTable(IList setOfEntries)
		{
			char FrameHor2 = (char)0x2550;
			char FrameHor1 = (char)0x2500;
			char FrameVer2 = (char)0x2551;
			char FrameT = (char)0x2566;
			char FrameTLower = (char)0x2569;
			char FrameTLeft = (char)0x255F;
			char FrameTRight = (char)0x2562;
			char FrameCross = (char)0x256B;
			char FrameCornerUL = (char)0x2554;
			char FrameCornerUR = (char)0x2557;
			char FrameCornerDL = (char)0x255A;
			char FrameCornerDR = (char)0x255D;

			int i;
			//for (int i = 0; i < setOfEntries.Count; i++)
			//{
			//    if (setOfEntries[i] is ISymbolTableReady)
			//    {
			//        result = string.Format("{0}\n{1}", result, setOfEntries[i]);
			//    }
			//}

			//Формирование массива на выход
			List<string[]> lst = new List<string[]>();
			if (setOfEntries != null)
			{
				foreach (ISymbolTableReady entry in setOfEntries)
				{
					lst.Add(entry.ToStringArray());
				}
			}

			//Инициализация счётчиков
			int[] width = new int[Header.Length];	//Здесь будет подсчитана ширина каждого из столбцов
			for (i = 0; i < width.Length; i++)
			{
				width[i] = Header[i].Length;
			}

			//Подсчёт ширины столбцов
			foreach (string[] str in lst)
			{
				for (i = 0; i < width.Length; i++)
				{
					if (i < str.Length)
					{
						if (width[i] < str[i].Length)
						{
							width[i] = str[i].Length;
						}
					}
					else
					{
						break;
					}
				}
			}

			//Формируем рамки
			string upperFrame = FrameCornerUL.ToString();
			string middleFrame = FrameTLeft.ToString();
			string lowerFrame = FrameCornerDL.ToString();

			for (i = 0; i < width.Length - 1; i++)
			{
				upperFrame = string.Concat(upperFrame, new string(FrameHor2, width[i] + 2), FrameT);
				middleFrame = string.Concat(middleFrame, new string(FrameHor1, width[i] + 2), FrameCross);
				lowerFrame = string.Concat(lowerFrame, new string(FrameHor2, width[i] + 2), FrameTLower);
			}
			upperFrame = string.Concat(upperFrame, new string(FrameHor2, width[i] + 2), FrameCornerUR);
			middleFrame = string.Concat(middleFrame, new string(FrameHor1, width[i] + 2), FrameTRight);
			lowerFrame = string.Concat(lowerFrame, new string(FrameHor2, width[i] + 2), FrameCornerDR);
			//Console.WriteLine(upperFrame);
			//Console.WriteLine(middleFrame);
			//Console.WriteLine(lowerFrame);

			//Набираем таблицу
			string buf;
			string result = upperFrame;

			//Шапка
			buf = FrameVer2.ToString();
			for (i = 0; i < Header.Length; i++)
			{
				buf = string.Concat(buf, " ", Header[i], new string(' ', width[i] - Header[i].Length + 1), FrameVer2);
			}
			result = string.Join("\n", result, buf, middleFrame);

			//Тело таблицы
			string add;
			for (i = 0; i < lst.Count; i++)
			{
				buf = FrameVer2.ToString();
				for (int j = 0; j < Header.Length; j++)
				{
					if (lst[i].Length > j)
					{
						add = lst[i][j];
						buf = string.Concat(buf, " ", add, new string(' ', width[j] - add.Length + 1), FrameVer2);
					}
					else
					{
						buf = string.Concat(buf, new string(' ', width[j] + 2), FrameVer2);
					}
				}
				if (i < lst.Count - 1)
				{
					result = string.Join("\n", result, buf, middleFrame);
				}
				else
				{
					result = string.Join("\n", result, buf, lowerFrame);
				}
			}

			Console.WriteLine(result);
			return result;
		}

		private void Dummy()
		{
			/*
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
			*/
		}
	}
}
