using System;

namespace libargument.Attributes
{
	/// <summary>
	/// Applies to classes and methods providing short and detailed information.
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
		/// Gets detailed description.
		/// </summary>
		public string LongDescription { get; private set; }

		/// <summary>
		/// Gets short description.
		/// </summary>
		public string ShortDescription { get; private set; }
	}
}
