using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public sealed class DescriptionAttribute : Attribute
	{
		private readonly string longDescription;

		private readonly string shortDescription;

		public DescriptionAttribute(string shortDescription, string longDescription)
		{
			this.shortDescription = shortDescription;
			this.longDescription = longDescription;
		}

		public string LongDescription
		{
			get { return longDescription; }
		}

		public string ShortDescription
		{
			get { return shortDescription; }
		}
	}
}
