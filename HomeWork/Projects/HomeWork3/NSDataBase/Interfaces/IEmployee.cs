using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSDataBase.Interfaces
{
	public interface IEmployee
	{
		int ID { get; }
		string Name { get; set; }
		string Surname { get; set; }
		string Position { get; set; }
	}
}
