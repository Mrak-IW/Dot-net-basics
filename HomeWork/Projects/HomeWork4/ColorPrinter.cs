using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HomeWork4
{
	struct ColorString
	{
		public ConsoleColor color;
		public string str;
	}

	static class ColorPrinter
	{
		public static void ColorPrint(object obj)
		{
			ConsoleColor defaultColor = Console.ForegroundColor;
			List<ColorString> output = DescribeObjectProperties(obj);
			foreach (var str in output)
			{
				Console.ForegroundColor = str.color;
				Console.WriteLine(str.str);
			}
			Console.ForegroundColor = defaultColor;
		}

		static List<ColorString> DescribeObjectProperties(object obj)
		{
			Type type = obj.GetType();
			List<ColorString> result = new List<ColorString>();
			List<ColorString> buf;
			string mods = "";
			ConsoleColor defaultColor = Console.ForegroundColor;

			if (type.IsNotPublic)
			{
				mods = mods + "private ";
			}
			if (type.IsPublic)
			{
				mods = mods + "public ";
			}
			if (type.IsSealed)
			{
				mods = mods + "sealed ";
			}
			if (type.IsInterface)
			{
				mods = mods + "interface ";
			}
			else
			{
				if (type.IsAbstract)
				{
					mods = mods + "abstract ";
				}
				if (type.IsClass)
				{
					mods = mods + "class ";
				}
			}
			result.Add(new ColorString { color = defaultColor, str = string.Format("{0}{1}\n{2}", mods, type.Name, "{") });
			buf = DescribeProperties(obj);
			result.Add(new ColorString { color = ConsoleColor.DarkGreen, str = "\t//Свойства" });
			result.AddRange(buf);

			result.Add(new ColorString { color = defaultColor, str = "}" });

			return result;
		}

		static List<ColorString> DescribeProperties(object obj)
		{
			PropertyInfo[] pi = obj.GetType().GetProperties();
			List<ColorString> result = new List<ColorString>();
			ConsoleColor defaultColor = Console.ForegroundColor;
			ConsoleColor color;

			foreach (PropertyInfo p in pi)
			{
				object attr = p.GetCustomAttributes(false).FirstOrDefault();
				if (attr != null && attr is ColorAttribute)
				{
					color = (attr as ColorAttribute).Color;
				}
				else
				{
					color = defaultColor;
				}
				result.Add(new ColorString { color = color, str = string.Format("\t{0} {1} = {2}", p.PropertyType, p.Name, p.GetValue(obj, null)) });
			}

			return result;
		}
	}
}
