using System;
using libargument.Conversion;

namespace libargument
{
	public abstract partial class Controller
	{
		private void registerDefaultConverter()
		{
				RegisterTypeConverter<Int16>(new Int16Converter());
				RegisterTypeConverter<Int32>(new Int32Converter());
				RegisterTypeConverter<Int64>(new Int64Converter());
				RegisterTypeConverter<UInt16>(new UInt16Converter());
				RegisterTypeConverter<UInt32>(new UInt32Converter());
				RegisterTypeConverter<UInt64>(new UInt64Converter());
				RegisterTypeConverter<Single>(new SingleConverter());
				RegisterTypeConverter<Double>(new DoubleConverter());
				RegisterTypeConverter<DateTime>(new DateTimeConverter());
				RegisterTypeConverter<TimeSpan>(new TimeSpanConverter());
				RegisterTypeConverter<Boolean>(new BooleanConverter());

		}
	}
}
