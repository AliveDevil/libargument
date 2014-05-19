using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = true)]
	public sealed class AbbreviationAttribute : Attribute
	{
		public AbbreviationAttribute(string abbreviation)
		{
			Abbreviation = abbreviation;
		}

		public string Abbreviation { get; private set; }
	}
}
