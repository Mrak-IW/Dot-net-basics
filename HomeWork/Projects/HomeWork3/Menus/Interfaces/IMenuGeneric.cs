using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Menus.Interfaces
{
	public interface IMenu<T>
	{
		bool Call(out string output, params string[] args);

		IMenu<T> this[string submenuName] { get; }

		T OperatedObject { get; }
		string UsageHelp { get; }
		string Description { get; }
		string UsageHelpShort { get; }
		string Name { get; }
		string FullName { get; }

		bool AddSubmenu(IMenu<T> submenu);
		bool ContainsSubmenu(string name);

		IMenu<T> Parent { get; set; }
	}
}