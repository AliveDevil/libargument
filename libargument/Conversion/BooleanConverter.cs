using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Conversion
{
	public class BooleanConverter : ITypeConverter<Boolean>
	{
		private IController target;

		public BooleanConverter(IController target)
		{
			this.target = target;
		}

		public bool CanRead(string value)
		{
			Boolean o;
			return Boolean.TryParse(value, out o);
		}

		object ITypeConverter.Read(string value)
		{
			return Read(value);
		}

		public Boolean Read(string value)
		{
			Boolean o;
			if (!Boolean.TryParse(value, out o) || string.IsNullOrWhiteSpace(value))
				o = true;
			return o;
		}

		public string Write(Boolean value)
		{
			return value.ToString();
		}

		public string Write(object value)
		{
			if (value is Boolean)
				return value.ToString();
			throw new ArgumentException("value is no Boolean.");
		}
	}
}
