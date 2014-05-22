using System;
using libargument.Conversion;

namespace libargument
{
	public abstract partial class Controller
	{
		private void registerDefaultConverter(IController controller)
		{
			RegisterTypeConverter<Int16>(new Int16Converter(controller));
			RegisterTypeConverter<Int32>(new Int32Converter(controller));
			RegisterTypeConverter<Int64>(new Int64Converter(controller));
			RegisterTypeConverter<UInt16>(new UInt16Converter(controller));
			RegisterTypeConverter<UInt32>(new UInt32Converter(controller));
			RegisterTypeConverter<UInt64>(new UInt64Converter(controller));
			RegisterTypeConverter<Single>(new SingleConverter(controller));
			RegisterTypeConverter<Double>(new DoubleConverter(controller));
			RegisterTypeConverter<DateTime>(new DateTimeConverter(controller));
			RegisterTypeConverter<TimeSpan>(new TimeSpanConverter(controller));
			RegisterTypeConverter<Boolean>(new BooleanConverter(controller));
			RegisterTypeConverter<String>(new StringConverter(controller));

		}
	}
}
