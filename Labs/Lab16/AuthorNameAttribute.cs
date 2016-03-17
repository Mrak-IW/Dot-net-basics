using System;

namespace Lab16
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class AuthorNameAttribute : System.Attribute
	{
		public string Name { get; set; }
		public AuthorNameAttribute(string name)
		{
			Name = name;
		}
	}
}
