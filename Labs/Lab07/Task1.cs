using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
{
	abstract class Human
	{
		public abstract void SayHello();
	}

	class Ukrainian:Human
	{
		public override void SayHello()
		{
			Console.WriteLine("Здоровенькi були!");
		}
	}

	class American : Human
	{
		public override void SayHello()
		{
			Console.WriteLine("Hi, guys!");
		}
	}

	class Russian : Human
	{
		public override void SayHello()
		{
			Console.WriteLine("Привет, чуваки!");
		}
	}
}