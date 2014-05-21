using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public sealed class ParseAttribute : Attribute
	{
		public ParseAttribute()
		{
		}
	}
}
