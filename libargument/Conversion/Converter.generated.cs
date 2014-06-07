using System;

namespace libargument.Conversion
{
	/// <summary>
	/// Converts a string from and to Int16.
	/// </summary>
	public sealed class Int16Converter : ITypeConverter<Int16>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public Int16Converter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Int16.</returns>
		public bool CanRead(string value)
		{
			Int16 o;
			return Int16.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Int16 or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Int16 o;
			return Int16.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Int16 or throws an exception. See <see cref="System.Int16.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Int16 Read(string value)
		{
			return Int16.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Int16 value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Int16)
				return value.ToString();
			throw new ArgumentException("value is no Int16.");
		}
	}
	/// <summary>
	/// Converts a string from and to Int32.
	/// </summary>
	public sealed class Int32Converter : ITypeConverter<Int32>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public Int32Converter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Int32.</returns>
		public bool CanRead(string value)
		{
			Int32 o;
			return Int32.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Int32 or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Int32 o;
			return Int32.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Int32 or throws an exception. See <see cref="System.Int32.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Int32 Read(string value)
		{
			return Int32.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Int32 value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Int32)
				return value.ToString();
			throw new ArgumentException("value is no Int32.");
		}
	}
	/// <summary>
	/// Converts a string from and to Int64.
	/// </summary>
	public sealed class Int64Converter : ITypeConverter<Int64>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public Int64Converter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Int64.</returns>
		public bool CanRead(string value)
		{
			Int64 o;
			return Int64.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Int64 or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Int64 o;
			return Int64.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Int64 or throws an exception. See <see cref="System.Int64.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Int64 Read(string value)
		{
			return Int64.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Int64 value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Int64)
				return value.ToString();
			throw new ArgumentException("value is no Int64.");
		}
	}
	/// <summary>
	/// Converts a string from and to UInt16.
	/// </summary>
	public sealed class UInt16Converter : ITypeConverter<UInt16>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public UInt16Converter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to UInt16.</returns>
		public bool CanRead(string value)
		{
			UInt16 o;
			return UInt16.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to UInt16 or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			UInt16 o;
			return UInt16.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to UInt16 or throws an exception. See <see cref="System.UInt16.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UInt16 Read(string value)
		{
			return UInt16.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(UInt16 value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is UInt16)
				return value.ToString();
			throw new ArgumentException("value is no UInt16.");
		}
	}
	/// <summary>
	/// Converts a string from and to UInt32.
	/// </summary>
	public sealed class UInt32Converter : ITypeConverter<UInt32>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public UInt32Converter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to UInt32.</returns>
		public bool CanRead(string value)
		{
			UInt32 o;
			return UInt32.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to UInt32 or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			UInt32 o;
			return UInt32.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to UInt32 or throws an exception. See <see cref="System.UInt32.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UInt32 Read(string value)
		{
			return UInt32.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(UInt32 value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is UInt32)
				return value.ToString();
			throw new ArgumentException("value is no UInt32.");
		}
	}
	/// <summary>
	/// Converts a string from and to UInt64.
	/// </summary>
	public sealed class UInt64Converter : ITypeConverter<UInt64>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public UInt64Converter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to UInt64.</returns>
		public bool CanRead(string value)
		{
			UInt64 o;
			return UInt64.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to UInt64 or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			UInt64 o;
			return UInt64.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to UInt64 or throws an exception. See <see cref="System.UInt64.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UInt64 Read(string value)
		{
			return UInt64.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(UInt64 value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is UInt64)
				return value.ToString();
			throw new ArgumentException("value is no UInt64.");
		}
	}
	/// <summary>
	/// Converts a string from and to Single.
	/// </summary>
	public sealed class SingleConverter : ITypeConverter<Single>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public SingleConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Single.</returns>
		public bool CanRead(string value)
		{
			Single o;
			return Single.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Single or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Single o;
			return Single.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Single or throws an exception. See <see cref="System.Single.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Single Read(string value)
		{
			return Single.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Single value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Single)
				return value.ToString();
			throw new ArgumentException("value is no Single.");
		}
	}
	/// <summary>
	/// Converts a string from and to Double.
	/// </summary>
	public sealed class DoubleConverter : ITypeConverter<Double>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public DoubleConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Double.</returns>
		public bool CanRead(string value)
		{
			Double o;
			return Double.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Double or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Double o;
			return Double.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Double or throws an exception. See <see cref="System.Double.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Double Read(string value)
		{
			return Double.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Double value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Double)
				return value.ToString();
			throw new ArgumentException("value is no Double.");
		}
	}
	/// <summary>
	/// Converts a string from and to DateTime.
	/// </summary>
	public sealed class DateTimeConverter : ITypeConverter<DateTime>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public DateTimeConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to DateTime.</returns>
		public bool CanRead(string value)
		{
			DateTime o;
			return DateTime.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to DateTime or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			DateTime o;
			return DateTime.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to DateTime or throws an exception. See <see cref="System.DateTime.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public DateTime Read(string value)
		{
			return DateTime.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(DateTime value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is DateTime)
				return value.ToString();
			throw new ArgumentException("value is no DateTime.");
		}
	}
	/// <summary>
	/// Converts a string from and to TimeSpan.
	/// </summary>
	public sealed class TimeSpanConverter : ITypeConverter<TimeSpan>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public TimeSpanConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to TimeSpan.</returns>
		public bool CanRead(string value)
		{
			TimeSpan o;
			return TimeSpan.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to TimeSpan or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			TimeSpan o;
			return TimeSpan.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to TimeSpan or throws an exception. See <see cref="System.TimeSpan.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public TimeSpan Read(string value)
		{
			return TimeSpan.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(TimeSpan value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is TimeSpan)
				return value.ToString();
			throw new ArgumentException("value is no TimeSpan.");
		}
	}
	/// <summary>
	/// Converts a string from and to Boolean.
	/// </summary>
	public sealed class BooleanConverter : ITypeConverter<Boolean>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public BooleanConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Boolean.</returns>
		public bool CanRead(string value)
		{
			Boolean o;
			return Boolean.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Boolean or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Boolean o;
			return Boolean.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Boolean or throws an exception. See <see cref="System.Boolean.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Boolean Read(string value)
		{
			return Boolean.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Boolean value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
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
	/// <summary>
	/// Converts a string from and to Decimal.
	/// </summary>
	public sealed class DecimalConverter : ITypeConverter<Decimal>
	{
		private IController target;

		/// <summary>
		///  Default constructor providing access to an IController instance.
		/// </summary>
		/// <param name="target"></param>
		public DecimalConverter(IController target)
		{
			this.target = target;
		}

		/// <summary>
		/// Determines if a value can be read by current converter.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>If this value can be converted to Decimal.</returns>
		public bool CanRead(string value)
		{
			Decimal o;
			return Decimal.TryParse(value, out o);
		}

		/// <summary>
		/// Tries to convert specified value to Decimal or returns null in case of failure.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Decimal o;
			return Decimal.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		/// Tries to convert specified value to Decimal or throws an exception. See <see cref="System.Decimal.Parse(System.String)" />.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Decimal Read(string value)
		{
			return Decimal.Parse(value);
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Decimal value)
		{
			return value.ToString();
		}

		/// <summary>
		/// Unused.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			if (value is Decimal)
				return value.ToString();
			throw new ArgumentException("value is no Decimal.");
		}
	}
}
