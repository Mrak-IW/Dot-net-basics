using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSDataBase.Interfaces;

namespace HomeWrok3.NSDataBase.Classes
{
	[Serializable]
	class Employee : IEmployee
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Position { get; set; }
	}
}
