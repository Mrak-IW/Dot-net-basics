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
			string result = "";
			for (int i = 0; i < setOfEntries.Count; i++)
			{
				if (setOfEntries[i] is ISymbolTableReady)
				{
					result = string.Format("{0}\n{1}", result, setOfEntries[i]);
				}
			}
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
