using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	/// <summary>
	///
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
	public sealed class KeyAttribute : Attribute
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="key"></param>
		public KeyAttribute(string key)
		{
			Key = key;
		}

		/// <summary>
		///
		/// </summary>
		public string Key { get; private set; }
	}
}
