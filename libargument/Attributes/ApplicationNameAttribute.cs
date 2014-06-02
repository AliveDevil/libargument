using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	/// <summary>
	///
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class ApplicationNameAttribute : Attribute
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public ApplicationNameAttribute(string name)
		{
			Name = name;
		}

		/// <summary>
		///
		/// </summary>
		public string Name { get; private set; }
	}
}
