using HomeWork2;
using System;
using System.IO;

namespace Lab14
{
	class FridgeFile : Fridge
	{
		FileStream file;

		public FridgeFile(string name, IAdjustable<int> dimmer, FileStream file) : base(name, dimmer)
		{
			this.file = file;
		}

		public override bool Opened
		{
			get
			{
				return base.Opened;
			}

			set
			{
				base.Opened = value;
			}
		}

		public string ReadField(string name)
		{
			StreamReader sr = new StreamReader(file);
			string str;
			string[] split = null;
			bool result = true;

			file.Seek(0, SeekOrigin.Begin);
			do
			{
				str = sr.ReadLine();
				if (str == null)
				{
					result = false;
					break;
				}
				str = str.Trim();
				split = str.Split(new char[] { '=', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			} while (split[0] != name);

			if (split.Length < 2)
			{
				result = false;
			}

			return result ? split[1] : null;
		}
	}
}
