using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab11.Task1
{
	public class TPing
	{
		PingPong pong;
		public void RegisterDelegate(PingPong dlg)
		{
			this.pong = dlg;
		}

		public void Ping()
		{
			Console.Write("Ping -> ");
			if (pong != null)
			{
				System.Threading.Thread.Sleep(2000);
				pong();
			}
		}
	}
}
