using HomeWork2;
using System;
using System.IO;

namespace Lab14
{
	class FridgeFile : Fridge
	{
		string fileName;

		public FridgeFile(string name, int temp, int tempMax, int tempMin, string fileName)
			: base(name, temp, tempMax, tempMin)
		{
			this.fileName = fileName;
		}

		public override bool Opened
		{
			get
			{
				string field = ReadField("Opened");
				bool result;
				if (field == null)
				{
					throw new MissingFieldException("В файле не найдено поля Opened");
				}
				if (!bool.TryParse(field, out result))
				{
					throw new InvalidDataException("Поле Opened из файла невозможно преобразовать в bool");
				}

				return result;
			}

			set
			{
				ReplaceField<bool>("Opened", value);
			}
		}

		public override EPowerState DeviceState
		{
			get
			{
				return base.DeviceState;
			}
			set
			{
				base.DeviceState = value;
			}
		}


		public override int Temperature
		{
			get
			{
				return int.Parse(ReadField("Temp"));
			}

			set
			{
				if (value >= TempMin && value <= TempMax)
				{
					ReplaceField<int>("Temp", value);
				}
			}
		}

		public string ReadField(string fieldName)
		{
			using (StreamReader sr = new StreamReader(fileName))
			{
				string str;
				string[] split = null;
				bool result = true;

				sr.BaseStream.Seek(0, SeekOrigin.Begin);

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
				} while (split[0] != fieldName);

				if (split == null || split.Length < 2)
				{
					result = false;
				}

				return result ? split[1] : null;
			}
		}

		public bool ReplaceField<T>(string fieldName, T fieldValue)
		{
			string fieldVal = fieldValue.ToString();
			string[] lines;
			string[] line;
			string fileContent;
			int i;

			using (StreamReader sr = new StreamReader(fileName))
			{
				sr.BaseStream.Seek(0, SeekOrigin.Begin);

				fileContent = sr.ReadToEnd();
				lines = fileContent.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

				for (i = 0; i < lines.Length; i++)
				{
					line = lines[i].Split(new char[] { ' ', '=', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (line[0] == fieldName)
					{
						break;
					}
				}

				if (i < lines.Length)
				{
					lines[i] = string.Format("{0} = {1}", fieldName, fieldValue.ToString());
				}
			}

			using (FileStream fs = new FileStream(fileName, FileMode.Truncate))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					foreach (string s in lines)
					{
						sw.WriteLine(s);
					}
				}
			}

			return false;
		}
	}
}
