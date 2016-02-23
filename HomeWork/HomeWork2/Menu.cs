using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public class Menu
	{
		const string EXIT = "ex";
		const string ADD_DEVICE = "add";
		const string REM_DEVICE = "rm";
		const string PICK_DEVICE = "pd";
		const string ON_DEVICE = "on";
		const string OFF_DEVICE = "off";
		const string BREAK_DEVICE = "br";
		const string REPARE_DEVICE = "rp";

		const string DEV_LAMP = "lp";

		const string BRIGHT_UP = "bu";
		const string BRIGHT_DOWN = "bd";
		const string GET_BRIGHTNESS = "gb";

		const string OPEN = "op";
		const string CLOSE = "cl";
		const string GET_OPEN_STATE = "os";

		const string TEMP_UP = "tu";
		const string TEMP_DOWN = "td";
		const string GET_TEMP = "gt";

		ISmartHouse sh;

		public Menu(ISmartHouse sh)
		{
			this.sh = sh;
		}

		public void Show()
		{
			string ans, idStr;
			string result = null;

			do
			{
				Console.Clear();
				Console.WriteLine("В системе {0} устройств:", sh.Count);
				for (int i = 0; i < sh.Count; i++)
				{
					Console.WriteLine(sh[i]);
				}
				Console.WriteLine();
				if (sh.Count > 0)
				{
					Console.WriteLine("{0} - Выбрать устройство", PICK_DEVICE);
				}
				Console.WriteLine("{0} - Добавить устройство", ADD_DEVICE);
				Console.WriteLine("{0} - Выход", EXIT);

				if (result != null)
				{
					Console.WriteLine("\n" + result);
				}

				Console.Write("\nВаш выбор:\t");
				ans = Console.ReadLine();
				switch (ans)
				{
					case ADD_DEVICE:
						sh.AddDevice(CreateDevice());
						break;
					case PICK_DEVICE:
						Console.Write("Введите ID устройства:\t");
						idStr = Console.ReadLine();
						result = PickDevice(idStr);
						break;
				}
			} while (ans != EXIT);
			Console.WriteLine("Завершение работы программы");
		}

		public ISmartDevice CreateDevice()
		{
			ISmartDevice result = null;
			string ans;
			bool done = false;

			do
			{
				Console.Clear();
				if (result != null)
				{
					Console.WriteLine("Вы выбрали:");
					Console.WriteLine(result);
				}
				Console.WriteLine("{0} - Умная лампа", DEV_LAMP);
				Console.WriteLine("{0} - Назад", EXIT);

				if (result != null)
				{
					Console.WriteLine("\n" + result);
				}

				Console.Write("Ваш выбор:\t");
				ans = Console.ReadLine();
				switch (ans)
				{
					case DEV_LAMP:
						result = new SmartLamp(new Dimmer(10, 100, 10));
						done = true;
						break;
					case EXIT:
						done = true;
						break;
				}
			} while (!done);

			return result;
		}

		public string PickDevice(string idStr)
		{
			string ans;
			string result = null;
			uint id;
			bool done = false;
			ISmartDevice dev;

			if (uint.TryParse(idStr, out id))
			{
				dev = sh.GetDeviceByID(id);
				if (dev != null)
				{
					do
					{
						Console.Clear();
						Console.WriteLine("В системе {0} устройств.", sh.Count);
						Console.WriteLine("Выбрано устройство:");
						Console.WriteLine(dev + "\n");

						if (dev.DeviceState != EPowerState.On)
						{
							Console.WriteLine("{0} - Включить", ON_DEVICE);
						}
						if (dev.DeviceState == EPowerState.On)
						{
							Console.WriteLine("{0} - Выключить", OFF_DEVICE);
						}

						if (dev.DeviceState == EPowerState.Broken && dev is IRepareable)
						{
							Console.WriteLine("{0} - Починить", REPARE_DEVICE);
						}

						if (dev is IBrightable)
						{
							if (dev.DeviceState == EPowerState.On)
							{
								Console.WriteLine("{0} - Сделать светлее", BRIGHT_UP);
								Console.WriteLine("{0} - Сделать темнее", BRIGHT_DOWN);
							}
							Console.WriteLine("{0} - Узнать текущую яркость", GET_BRIGHTNESS);
						}

						if (dev is IHaveThermostat)
						{
							if (dev.DeviceState == EPowerState.On)
							{
								Console.WriteLine("{0} - Сделать горячее", TEMP_UP);
								Console.WriteLine("{0} - Сделать холоднее", TEMP_DOWN);
							}
							Console.WriteLine("{0} - Узнать текущую температуру", GET_TEMP);
						}

						if (dev is IOpenCloseable)
						{
							Console.WriteLine("{0} - Сделать светлее", BRIGHT_UP);
							Console.WriteLine("{0} - Сделать темнее", BRIGHT_DOWN);
							Console.WriteLine("{0} - Узнать состояние дверцы", GET_OPEN_STATE);
						}

						Console.WriteLine("{0} - Выкинуть в окно", REM_DEVICE);
						Console.WriteLine("{0} - Пнуть ногой", BREAK_DEVICE);

						Console.WriteLine("{0} - Назад", EXIT);

						if (result != null)
						{
							Console.WriteLine("\n" + result);
						}

						Console.Write("Ваш выбор:\t");
						ans = Console.ReadLine();

						switch (ans)
						{
							case ON_DEVICE:
								if (dev.DeviceState != EPowerState.Broken)
								{
									dev.On();
									result = "Устройство включено";
								}
								else
								{
									result = "Внутри что-то хлопнуло и задымилось";
								}
								break;
							case OFF_DEVICE:
								if (dev.DeviceState != EPowerState.Broken)
								{
									dev.Off();
									result = "Устройство выключено";
								}
								else
								{
									result = "А смысл?";
								}
								break;
							case REM_DEVICE:
								dev.Parent.RemoveDevice(dev);
								result = "Устройство ID = " + dev.ID + ", набирая скорость, ухнуло вниз";
								done = true;
								break;
							case BREAK_DEVICE:
								dev.Break();
								result = "Устройство пустило дымок";
								break;
							case EXIT:
								result = null;
								done = true;
								break;
						}

						if (dev is IRepareable)
						{
							IRepareable buf = dev as IRepareable;
							if (ans == REPARE_DEVICE)
							{
								if (dev.DeviceState == EPowerState.Broken)
								{
									buf.Repare();
									result = "Вы подёргали какие-то проводки, протёрли устройство тряпочкой и оно заработало";
								}
								else
								{
									result = "Есть правило: работает - не лезь! Вы подёргали какие-то проводки, раздался хлопок и запахло горелым";
									dev.Break();
								}
							}
						}

						if (dev is IBrightable && dev.DeviceState == EPowerState.On)
						{
							IBrightable buf = dev as IBrightable;
							switch (ans)
							{
								case BRIGHT_UP:
									buf.IncreaseBrightness();
									break;
								case BRIGHT_DOWN:
									buf.DecreaseBrightness();
									break;
								case GET_BRIGHTNESS:
									result = "Текущая яркость = " + buf.Brightness+" люмен";
									break;
							}
						}

						if (dev is IOpenCloseable)
						{
							IOpenCloseable buf = dev as IOpenCloseable;
							switch (ans)
							{
								case OPEN:
									buf.Open();
									if (!buf.Opened)
									{
										result = "Не открывается.";
									}
									break;
								case CLOSE:
									buf.Close();
									if (buf.Opened)
									{
										result = "Не закрывается.";
									}
									break;
								case GET_OPEN_STATE:
									result = "Дверца " + (buf.Opened ? "открыта" : "закрыта");
									break;
							}
						}

						if (dev is IHaveThermostat)
						{
							IHaveThermostat buf = dev as IHaveThermostat;
							switch (ans)
							{
								case TEMP_UP:
									buf.IncreaseTemperature();
									break;
								case TEMP_DOWN:
									buf.DecreaseTemperature();
									break;
								case GET_TEMP:
									result = "Текущая температура = " + buf.Temperature + "C";
									break;
							}
						}
					} while (!done);
				}
				else
				{
					result = "Устройства с ID = " + id.ToString("D4") + " нет в системе";
				}
			}
			else
			{
				result = "Вы ввели некорректный ID (" + idStr + ")";
			}


			return result;
		}
	}
}