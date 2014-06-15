using System;

namespace libargument.Attributes
{
	/// <summary>
	/// Override default behavior of using parameter name as key.
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
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
		/// Returns user defined key for parameter.
		/// </summary>
		public string Key { get; private set; }
	}
}
