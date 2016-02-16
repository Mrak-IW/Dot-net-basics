using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab11.Task1
{
	class TPong
	{
		PingPong ping;
		public void RegisterDelegate(PingPong dlg)
		{
			this.ping = dlg;
		}

		public void Pong()
		{
			Console.WriteLine("Pong");
			if (ping != null)
			{
				System.Threading.Thread.Sleep(2000);
				ping();
			}
		}
	}
}
