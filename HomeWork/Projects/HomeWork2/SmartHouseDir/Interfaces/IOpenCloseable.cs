using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2.SmartHouseDir.Interfaces
{
	public interface IOpenCloseable
	{
		bool IsOpened { get; set; }

		void Open();
		void Close();
	}
}