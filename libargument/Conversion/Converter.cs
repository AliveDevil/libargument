using System;

namespace libargument.Conversion
{

		public sealed class Int16Converter : ITypeConverter<Int16>
		{
			object ITypeConverter.Read(string value)
			{
				Int16 o;
				if (Int16.TryParse(value, out o))
					return o;
				return null;
			}

			public Int16 Read(string value)
			{
				return Int16.Parse(value);
			}

			public string Write(Int16 value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is Int16)
					return value.ToString();
				throw new ArgumentException("value is no Int16.");
			}
		}
		
		public sealed class Int32Converter : ITypeConverter<Int32>
		{
			object ITypeConverter.Read(string value)
			{
				Int32 o;
				if (Int32.TryParse(value, out o))
					return o;
				return null;
			}

			public Int32 Read(string value)
			{
				return Int32.Parse(value);
			}

			public string Write(Int32 value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is Int32)
					return value.ToString();
				throw new ArgumentException("value is no Int32.");
			}
		}
		
		public sealed class Int64Converter : ITypeConverter<Int64>
		{
			object ITypeConverter.Read(string value)
			{
				Int64 o;
				if (Int64.TryParse(value, out o))
					return o;
				return null;
			}

			public Int64 Read(string value)
			{
				return Int64.Parse(value);
			}

			public string Write(Int64 value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is Int64)
					return value.ToString();
				throw new ArgumentException("value is no Int64.");
			}
		}
		
		public sealed class UInt16Converter : ITypeConverter<UInt16>
		{
			object ITypeConverter.Read(string value)
			{
				UInt16 o;
				if (UInt16.TryParse(value, out o))
					return o;
				return null;
			}

			public UInt16 Read(string value)
			{
				return UInt16.Parse(value);
			}

			public string Write(UInt16 value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is UInt16)
					return value.ToString();
				throw new ArgumentException("value is no UInt16.");
			}
		}
		
		public sealed class UInt32Converter : ITypeConverter<UInt32>
		{
			object ITypeConverter.Read(string value)
			{
				UInt32 o;
				if (UInt32.TryParse(value, out o))
					return o;
				return null;
			}

			public UInt32 Read(string value)
			{
				return UInt32.Parse(value);
			}

			public string Write(UInt32 value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is UInt32)
					return value.ToString();
				throw new ArgumentException("value is no UInt32.");
			}
		}
		
		public sealed class UInt64Converter : ITypeConverter<UInt64>
		{
			object ITypeConverter.Read(string value)
			{
				UInt64 o;
				if (UInt64.TryParse(value, out o))
					return o;
				return null;
			}

			public UInt64 Read(string value)
			{
				return UInt64.Parse(value);
			}

			public string Write(UInt64 value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is UInt64)
					return value.ToString();
				throw new ArgumentException("value is no UInt64.");
			}
		}
		
		public sealed class SingleConverter : ITypeConverter<Single>
		{
			object ITypeConverter.Read(string value)
			{
				Single o;
				if (Single.TryParse(value, out o))
					return o;
				return null;
			}

			public Single Read(string value)
			{
				return Single.Parse(value);
			}

			public string Write(Single value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is Single)
					return value.ToString();
				throw new ArgumentException("value is no Single.");
			}
		}
		
		public sealed class DoubleConverter : ITypeConverter<Double>
		{
			object ITypeConverter.Read(string value)
			{
				Double o;
				if (Double.TryParse(value, out o))
					return o;
				return null;
			}

			public Double Read(string value)
			{
				return Double.Parse(value);
			}

			public string Write(Double value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is Double)
					return value.ToString();
				throw new ArgumentException("value is no Double.");
			}
		}
		
		public sealed class DateTimeConverter : ITypeConverter<DateTime>
		{
			object ITypeConverter.Read(string value)
			{
				DateTime o;
				if (DateTime.TryParse(value, out o))
					return o;
				return null;
			}

			public DateTime Read(string value)
			{
				return DateTime.Parse(value);
			}

			public string Write(DateTime value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is DateTime)
					return value.ToString();
				throw new ArgumentException("value is no DateTime.");
			}
		}
		
		public sealed class TimeSpanConverter : ITypeConverter<TimeSpan>
		{
			object ITypeConverter.Read(string value)
			{
				TimeSpan o;
				if (TimeSpan.TryParse(value, out o))
					return o;
				return null;
			}

			public TimeSpan Read(string value)
			{
				return TimeSpan.Parse(value);
			}

			public string Write(TimeSpan value)
			{
				return value.ToString();
			}

			public string Write(object value)
			{
				if (value is TimeSpan)
					return value.ToString();
				throw new ArgumentException("value is no TimeSpan.");
			}
		}
		
}
