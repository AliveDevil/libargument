using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Conversion
{
	public interface ITypeConverter
	{
		bool CanRead(string value);

		object Read(string value);

		string Write(object value);
	}

	public interface ITypeConverter<T> : ITypeConverter
	{
		new T Read(string value);

		string Write(T value);
	}
}
