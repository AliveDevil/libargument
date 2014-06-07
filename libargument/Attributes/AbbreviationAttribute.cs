using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Attributes
{
	/// <summary>
	/// Adds an abbreviation to a parameter.
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = true)]
	public sealed class AbbreviationAttribute : Attribute
	{
		/// <summary>
		/// Creates a new instance of AbbreviationAttribute and applies given abbreviation.
		/// </summary>
		/// <param name="abbreviation"></param>
		public AbbreviationAttribute(string abbreviation)
		{
			Abbreviation = abbreviation;
		}

		/// <summary>
		/// Returns current abbreviation.
		/// </summary>
		public string Abbreviation { get; private set; }
	}
}
