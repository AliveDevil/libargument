using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	/// <summary>
	/// Describes a field in a controller class as an option.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public sealed class OptionAttribute : Attribute
	{
		/// <summary>
		/// 
		/// </summary>
		public OptionAttribute()
		{
		}
	}
}
