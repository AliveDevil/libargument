using libargument.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	public interface IController
	{
		void Help();

		void PrintHeader();

		void RegisterTypeConverter(Type type, ITypeConverter typeConverter);

		void RegisterTypeConverter<T>(ITypeConverter<T> typeConverter);

		ITypeConverter ResolveType(Type targetType);

		ITypeConverter<T> ResolveType<T>();
	}
}
