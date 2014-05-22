using System;
using libargument.Conversion;

namespace libargument
{
	public abstract partial class Controller
	{
		private void registerDefaultConverter(IController target)
		{
			RegisterTypeConverter<Int16>(new Int16Converter(target));
			RegisterTypeConverter<Int32>(new Int32Converter(target));
			RegisterTypeConverter<Int64>(new Int64Converter(target));
			RegisterTypeConverter<UInt16>(new UInt16Converter(target));
			RegisterTypeConverter<UInt32>(new UInt32Converter(target));
			RegisterTypeConverter<UInt64>(new UInt64Converter(target));
			RegisterTypeConverter<Single>(new SingleConverter(target));
			RegisterTypeConverter<Double>(new DoubleConverter(target));
			RegisterTypeConverter<DateTime>(new DateTimeConverter(target));
			RegisterTypeConverter<TimeSpan>(new TimeSpanConverter(target));
			RegisterTypeConverter<Boolean>(new BooleanConverter(target));

		}
	}
}
