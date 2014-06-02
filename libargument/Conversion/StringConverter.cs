using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Conversion
{
	/// <summary>
	///
	/// </summary>
	public sealed class StringConverter : ITypeConverter<String>
	{
		private IController target;

		/// <summary>
		///
		/// </summary>
		/// <param name="target"></param>
		public StringConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CanRead(string value)
		{
			return true;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			return value;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Read(string value)
		{
			return value;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(string value)
		{
			return value;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			return value.ToString();
		}
	}
}
