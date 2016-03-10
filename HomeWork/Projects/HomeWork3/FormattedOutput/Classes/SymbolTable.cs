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
	}
}
