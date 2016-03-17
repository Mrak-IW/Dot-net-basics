﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public interface IOpenCloseable
	{
		bool Opened { get; set; }

		void Open();
		void Close();
	}
}