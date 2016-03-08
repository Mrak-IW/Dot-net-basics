using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using HomeWork3.FormattedOutput.Interfaces;
using System.Runtime.Serialization;

namespace HomeWork3.NSDataBase.Classes
{
	[Serializable]
	public class Employee : IEmployee, ISymbolTableReady/*, ISerializable*/
	{
		public static int nextID = 0;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Position { get; set; }

		public Employee()
		{
			this.ID = nextID++;
		}

		public Employee(string name, string surname, string position)
			: this()
		{
			Name = name;
			Surname = surname;
			Position = position;
		}

		/// <summary>
		/// Конструктор десериализации
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public Employee(SerializationInfo info, StreamingContext context)
		{
			Employee.nextID = info.GetInt32("static.nextID");
		}

		public string[] ToStringArray()
		{
			string[] arr = new string[4];

			arr[0] = ID.ToString();
			arr[1] = Name;
			arr[2] = Surname;
			arr[3] = Position;

			return arr;
		}

		public override string ToString()
		{
			return string.Format("{0:D3}: {1} {2} - {3}", ID, Name, Surname, Position);
		}

		/// <summary>
		/// Метод, где можно принудительно сериализовать статические поля
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//Данный метод нуждается в дальнейшем изучении. Пока не работает так, как хотелось-бы
			info.AddValue("static.nextID", Employee.nextID, typeof(int));
		}
	}
}
