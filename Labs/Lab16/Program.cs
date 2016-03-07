using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Lab16
{
	[AuthorName("Mrak")]
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();

			Console.Write("Введите номер задания:\t");
			string taskNum = Console.ReadLine();
			switch (taskNum)
			{
				default:
					Console.WriteLine("Задание с таким номером не реализовано");
					break;

				case "1":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Assembly a = Assembly.LoadFrom("ReflectionTask.dll");
						Console.WriteLine("Имя сборки: {0}", a.FullName);

						Type[] types = a.GetTypes();
						foreach (Type t in types)
						{
							Console.WriteLine(DescribeType(t));
						}

						Type type = a.GetType("ReflectionTask.Square");
						MethodInfo method = type.GetMethod("set_Side");
						object instance = Activator.CreateInstance(type, 10);	//Похоже, конструктор с параметрвми не работает. UPD: теперь работает
						method.Invoke(instance, new object[] { 20 });

						//Получение одного из перегруженных методов (без параметров)
						method = type.GetMethod("GetArea", Type.EmptyTypes);
						int surface = (int)method.Invoke(instance, null);
						Console.WriteLine("GetArea() = {0}", surface);

						//Получение одного из перегруженных методов (с параметрами)
						method = type.GetMethod("GetArea", new Type[] { Type.GetType("System.Int32") });
						surface = (int)method.Invoke(instance, new object[] { 5 });
						Console.WriteLine("GetArea(5) = {0}", surface);

						FieldInfo field = type.GetField("figeType");
						Console.WriteLine("figeType = {0}", field.GetValue(instance));
					}
					break;
				case "2":
					Console.WriteLine("Задание {0}:", taskNum);
					{
						Type t = Type.GetType("Lab16.Program");
						object[] attrs = t.GetCustomAttributes(false);
						foreach (AuthorNameAttribute a in attrs)
						{
							Console.WriteLine("Автор кода: {0}", a.Name);
						}
					}
					break;
			}
		}

		static string DescribeType(Type type)
		{
			string result;
			string[] buf;
			string mods = "";
			string parents = "";

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

			parents = DescribeParents(type);


			result = string.Format("{0}{1}.{2}{3}\n{4}", mods, type.Namespace, type.Name, parents, "{\n");

			buf = DescribeFields(type.GetFields());
			result = result + "\t//Поля\n";
			foreach (string f in buf)
			{
				result = string.Format("{0}\t{1}\n", result, f);
			}

			buf = DescribeConstructors(type.GetConstructors());
			result = result + "\t//Конструкторы\n";
			foreach (string f in buf)
			{
				result = string.Format("{0}\t{1}\n", result, f);
			}

			buf = DescribeProperties(type.GetProperties());
			result = result + "\t//Свойства\n";
			foreach (string f in buf)
			{
				result = string.Format("{0}\t{1}\n", result, f);
			}

			buf = DescribeMethods(type.GetMethods());
			result = result + "\t//Методы\n";
			foreach (string f in buf)
			{
				result = string.Format("{0}\t{1}\n", result, f);
			}

			return result + "}";
		}

		static string[] DescribeFields(FieldInfo[] fi)
		{
			string[] result = null;
			string mods;
			FieldInfo f;
			result = new string[fi.Count()];

			for (int i = 0; i < fi.Count(); i++)
			{
				f = fi[i];
				mods = "";

				if (f.IsPublic)
				{
					mods = mods + "public ";
				}

				if (f.IsPrivate)
				{
					mods = mods + "private ";
				}

				if (f.IsFamily)
				{
					mods = mods + "protected ";
				}

				if (f.IsLiteral)
				{
					mods = mods + "const ";
				}
				else if (f.IsStatic)
				{
					mods = mods + "static ";
				}

				if (f.IsInitOnly)
				{
					mods = mods + "readonly ";
				}

				result[i] = string.Format("{0} {1};", f.FieldType, f.Name);
				result[i] = mods + result[i];
			}

			return result;
		}

		static string[] DescribeProperties(PropertyInfo[] pi)
		{
			string[] result = null;
			string mods;
			PropertyInfo p;
			result = new string[pi.Count()];

			for (int i = 0; i < pi.Count(); i++)
			{
				p = pi[i];
				mods = "";
				if (p.CanRead)
				{
					mods = mods + "get; ";
				}
				if (p.CanWrite)
				{
					mods = mods + "set; ";
				}

				result[i] = string.Format("{0} {1} {2} {3}{4}", p.PropertyType, p.Name, "{", mods, "}");
			}

			return result;
		}

		static string[] DescribeMethods(MethodInfo[] methods)
		{
			string[] result = null;
			string mods;
			MethodInfo m;
			result = new string[methods.Count()];

			for (int i = 0; i < methods.Count(); i++)
			{
				m = methods[i];
				mods = "";

				if (m.IsPublic)
				{
					mods = mods + "public ";
				}

				if (m.IsPrivate)
				{
					mods = mods + "private ";
				}

				if (m.IsFamily)
				{
					mods = mods + "protected ";
				}

				if (m.IsStatic)
				{
					mods = mods + "static ";
				}

				if (m.IsAbstract)
				{
					mods = mods + "abstract ";
				}

				if (m.IsVirtual)
				{
					mods = mods + "virtual ";
				}

				result[i] = string.Format("{0}{1} {2}( {3} );", mods, m.ReturnType, m.Name, DescribeParams(m.GetParameters()));
			}

			return result;
		}

		static string DescribeParams(ParameterInfo[] par)
		{
			string result = "";

			ParameterInfo p;

			if (par != null && par.Length > 0)
			{
				p = par[0];
				result = string.Format("{0} {1}", p.ParameterType, p.Name);
				for (int i = 1; i < par.Length; i++)
				{
					p = par[i];
					result = string.Format("{0}, {1} {2}", result, p.ParameterType, p.Name);
				}

			}
			return result;
		}

		static string[] DescribeConstructors(ConstructorInfo[] constructors)
		{
			string[] result = null;
			string mods;
			ConstructorInfo c;
			result = new string[constructors.Count()];

			for (int i = 0; i < constructors.Count(); i++)
			{
				c = constructors[i];
				mods = "";

				if (c.IsPublic)
				{
					mods = mods + "public ";
				}

				if (c.IsPrivate)
				{
					mods = mods + "private ";
				}

				if (c.IsFamily)
				{
					mods = mods + "protected ";
				}

				if (c.IsStatic)
				{
					mods = mods + "static ";
				}

				if (c.IsAbstract)
				{
					mods = mods + "abstract ";
				}

				if (c.IsVirtual)
				{
					mods = mods + "virtual ";
				}

				result[i] = string.Format("{0}{1} ({2});", mods, c.ReflectedType.Name, DescribeParams(c.GetParameters()));
			}

			return result;
		}

		static string DescribeParents(Type type)
		{
			string result = "";
			Type[] ifaces = type.GetInterfaces();

			if (type.IsClass)
			{
				result = string.Format(" : {0}", type.BaseType);
			}
			else
			{
				if (ifaces.Length > 0)
				{
					result = " : ";
				}
			}

			if (ifaces.Length > 0)
			{
				result = string.Format("{0}, {1}", result, ifaces[0].Name);
			}

			for (int i = 1; i < ifaces.Length; i++)
			{
				result = string.Format("{0}, {1}", result, ifaces[i].Name);
			}

			return result;
		}
	}
}
