using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	/// <summary>
	/// Specify this attribute if a method should be parsed by <see cref="T:libargument.Parser`1"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public sealed class ParseAttribute : Attribute
	{
		/// <summary>
		/// Creates a new attribute for current method indicating that this should be parsed.
		/// </summary>
		public ParseAttribute()
		{
		}
	}
}
