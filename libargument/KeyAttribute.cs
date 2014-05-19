using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
	public sealed class KeyAttribute : Attribute
	{
		public KeyAttribute(string key)
		{
			Key = key;
		}

		public string Key { get; private set; }
	}
}
