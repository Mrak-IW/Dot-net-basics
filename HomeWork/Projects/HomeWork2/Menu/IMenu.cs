using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork2
{
	public interface IMenu
	{
		IDictionary<string, IMenu> Submenus { get; }

		bool Call(ISmartHouse sh, out string output, params string[] args);

		string UsageHelp { get; }

		string Description { get; }
		string UsageHelpShort { get; }
		string Name { get; }

		bool AddSubmenu(IMenu submenu);
		bool ContainsSubmenu(string name);
	}
}