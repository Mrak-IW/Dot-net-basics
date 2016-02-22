using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab12
{
	public class AnyClass : IDisposable
	{
		private bool isDisposed = false;
		private string name;

		public AnyClass(string name)
		{
			this.name = name;
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this); // Подавление финализации
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
					// Освобождение управляемых ресурсов
					Console.WriteLine(name + " сдох методом Dispose()");
				}
				// Освобождение неуправляемых ресурсов
				else
				{
					Console.WriteLine(name + " разуплотнён деструктором");
				}
				
				isDisposed = true;
			}
		}
		~AnyClass() { Dispose(false); }
	}
}
