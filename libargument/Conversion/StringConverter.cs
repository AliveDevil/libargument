using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Conversion
{
	public sealed class StringConverter : ITypeConverter<String>
	{
		private IController target;

		public StringConverter(IController target)
		{
			this.target = target;
		}

		public bool CanRead(string value)
		{
			return true;
		}

		object ITypeConverter.Read(string value)
		{
			return value;
		}

		public string Read(string value)
		{
			return value;
		}

		public string Write(string value)
		{
			return value;
		}

		public string Write(object value)
		{
			return value.ToString();
		}
	}
}
