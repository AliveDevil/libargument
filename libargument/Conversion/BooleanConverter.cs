using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Conversion
{
	/// <summary>
	///
	/// </summary>
	public class BooleanConverter : ITypeConverter<Boolean>
	{
		private IController target;

		/// <summary>
		///
		/// </summary>
		/// <param name="target"></param>
		public BooleanConverter(IController target)
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
			Boolean o;
			return Boolean.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			return Read(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Boolean Read(string value)
		{
			Boolean o;
#if NET35
			if (!Boolean.TryParse(value, out o) || string.IsNullOrEmpty(value.Trim()))
#else
			if (!Boolean.TryParse(value, out o) || string.IsNullOrWhiteSpace(value))
#endif
				o = true;
			return o;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Boolean value)
		{
			return value.ToString();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Boolean)
				return value.ToString();
			throw new ArgumentException("value is no Boolean.");
		}
	}
}
