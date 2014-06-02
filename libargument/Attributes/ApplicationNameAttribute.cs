using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class ApplicationNameAttribute : Attribute
	{
		private readonly string name;

		public ApplicationNameAttribute(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get { return name; }
		}
	}
}
