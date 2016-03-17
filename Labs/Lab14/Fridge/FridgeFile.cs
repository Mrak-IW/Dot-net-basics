using HomeWork2;
using System;
using System.IO;

namespace Lab14
{
	class FridgeFile : ISmartDevice, IOpenCloseable, IHaveThermostat
	{
		string fileName;

		public FridgeFile(string name, int temp, int tempMax, int tempMin, string fileName)
		{
			this.fileName = fileName;
			FileInfo fi = new FileInfo(fileName);

			if (ReadField("Name") == null)
			{
				Name = name;
			}
			if (ReadField("TempMax") == null)
			{
				TempMax = tempMax;
			}
			if (ReadField("TempMin") == null)
			{
				TempMin = tempMin;
			}
			if (ReadField("Temp") == null)
			{
				Temperature = temp;
			}
			if (ReadField("State") == null)
			{
				DeviceState = EPowerState.Off;
			}
			if (ReadField("Opened") == null)
			{
				Opened = false;
			}
		}

		public bool Opened
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
				WriteField<bool>("Opened", value);
			}
		}

		public EPowerState DeviceState
		{
			get
			{
				int result;
				if (!int.TryParse(ReadField("State"), out result))
				{
					throw new NullReferenceException("Не удалось прочитать поле State из файла " + fileName);
				}
				return (EPowerState)result;
			}
			set
			{
				WriteField<int>("State", (int)value);
			}
		}

		public int TempMin
		{
			get
			{
				int result;
				if (!int.TryParse(ReadField("TempMin"), out result))
				{
					throw new NullReferenceException("Не удалось прочитать поле TempMin из файла " + fileName);
				}
				return result;
			}
			protected set
			{
				if (value < -273)
				{
					throw new ArgumentOutOfRangeException("За нарушение законов физики - исключение");
				}
				if (value > TempMax)
				{
					throw new ArgumentOutOfRangeException("Минимум больше максимума быть не должен");
				}
				WriteField("TempMin", value);
			}
		}

		public int TempMax
		{
			get
			{
				int result;
				if (!int.TryParse(ReadField("TempMax"), out result))
				{
					throw new NullReferenceException("Не удалось прочитать поле TempMax из файла " + fileName);
				}
				return result;
			}
			set
			{
				if (value < -273)
				{
					throw new ArgumentOutOfRangeException("За нарушение законов физики - исключение");
				}
				if (value > 10)
				{
					throw new ArgumentOutOfRangeException("Холодильник, который греет - бесполезен");
				}
				WriteField("TempMax", value);
			}
		}

		public int Temperature
		{
			get
			{
				return int.Parse(ReadField("Temp"));
			}

			set
			{
				if (value >= TempMin && value <= TempMax)
				{
					WriteField<int>("Temp", value);
				}
			}
		}

		public string Name
		{
			get
			{
				return ReadField("Name");
			}
			protected set
			{
				WriteField<string>("Name", value);
			}
		}

		public void On()
		{
			if (DeviceState != EPowerState.Broken)
			{
				DeviceState = EPowerState.On;
			}
		}

		public void Off()
		{
			if (DeviceState != EPowerState.Broken)
			{
				DeviceState = EPowerState.Off;
			}
		}

		public void Break()
		{
			DeviceState = EPowerState.Broken;
		}

		public void IncreaseTemperature()
		{
			Temperature++;
		}

		public void DecreaseTemperature()
		{
			Temperature--;
		}

		public void Open()
		{
			Opened = true;
		}

		public void Close()
		{
			Opened = false;
		}

		public string ReadField(string fieldName)
		{
			FileInfo fi = new FileInfo(fileName);

			if (fi.Exists)
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
			else
			{
				return null;
			}
		}

		public bool WriteField<T>(string fieldName, T fieldValue)
		{
			string fieldVal = fieldValue.ToString();
			string[] lines;
			string[] line;
			string fileContent;
			string newLine = null;
			int i;

			FileInfo fi = new FileInfo(fileName);

			if (fi.Exists)
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					sr.BaseStream.Seek(0, SeekOrigin.Begin);
					fileContent = sr.ReadToEnd();
				}
			}
			else
			{
				fileContent = "";
			}

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
			else
			{
				newLine = string.Format("{0} = {1}", fieldName, fieldValue.ToString());
			}

			using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					foreach (string s in lines)
					{
						sw.WriteLine(s);
					}
					if (newLine != null)
					{
						sw.WriteLine(newLine);
					}
				}
			}

			return false;
		}

		public override string ToString()
		{
			string res = Name + ":\t";
			switch (DeviceState)
			{
				case EPowerState.On:
					string progress = new string('*', 10 * (TempMax - Temperature) / (TempMax - TempMin));
					progress = string.Format("[{2}|{0}{1}|{3}]", progress, new string(' ', 10 - progress.Length), TempMin, TempMax);

					res = string.Format("{0}жужжит {1} {2}C", res, progress, Temperature);
					break;
				case EPowerState.Off:
					res = res + "не жужжит";
					break;
				case EPowerState.Broken:
					res = res + "дымит";
					break;
			}

			res = res + (Opened ? " : открыт" : " : закрыт");

			return res;
		}
	}
}
