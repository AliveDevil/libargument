using System;

namespace libargument.Attributes
{
	/// <summary>
	/// Overrides usage of Assembly.GetName().Name for Header.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class ApplicationNameAttribute : Attribute
	{
		/// <summary>
		/// Creates a new instance of ApplicationNameAttribute applying given name as ApplicationName.
		/// </summary>
		/// <param name="name">Some name for </param>
		public ApplicationNameAttribute(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Returns given ApplicationName,
		/// </summary>
		public string Name { get; private set; }
	}
}
