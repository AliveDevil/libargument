using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	/// <summary>
	///
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public sealed class DescriptionAttribute : Attribute
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="shortDescription"></param>
		/// <param name="longDescription"></param>
		public DescriptionAttribute(string shortDescription, string longDescription)
		{
			ShortDescription = shortDescription;
			LongDescription = longDescription;
		}

		/// <summary>
		///
		/// </summary>
		public string LongDescription { get; private set; }

		/// <summary>
		///
		/// </summary>
		public string ShortDescription { get; private set; }
	}
}
