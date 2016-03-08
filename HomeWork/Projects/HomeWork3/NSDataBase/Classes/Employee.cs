using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;
using HomeWork3.FormattedOutput.Interfaces;

namespace HomeWork3.NSDataBase.Classes
{
	[Serializable]
	public class Employee : IEmployee, ISymbolTableReady
	{
		static int nextID = 0;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Position { get; set; }

		public Employee()
		{
			this.ID = nextID++;
		}

		public Employee(string name, string surname, string position)
			:this()
		{
			Name = name;
			Surname = surname;
			Position = position;
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
	}
}
