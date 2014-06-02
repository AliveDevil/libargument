using System;

namespace libargument.Conversion
{
	/// <summary>
	///
	/// </summary>
	public sealed partial class Int16Converter : ITypeConverter<Int16>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public Int16Converter(IController target)
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
			Int16 o;
			return Int16.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Int16 o;
			return Int16.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Int16 Read(string value)
		{
			return Int16.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Int16 value)
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
			if (value is Int16)
				return value.ToString();
			throw new ArgumentException("value is no Int16.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class Int32Converter : ITypeConverter<Int32>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public Int32Converter(IController target)
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
			Int32 o;
			return Int32.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Int32 o;
			return Int32.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Int32 Read(string value)
		{
			return Int32.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Int32 value)
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
			if (value is Int32)
				return value.ToString();
			throw new ArgumentException("value is no Int32.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class Int64Converter : ITypeConverter<Int64>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public Int64Converter(IController target)
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
			Int64 o;
			return Int64.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Int64 o;
			return Int64.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Int64 Read(string value)
		{
			return Int64.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Int64 value)
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
			if (value is Int64)
				return value.ToString();
			throw new ArgumentException("value is no Int64.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class UInt16Converter : ITypeConverter<UInt16>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public UInt16Converter(IController target)
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
			UInt16 o;
			return UInt16.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			UInt16 o;
			return UInt16.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UInt16 Read(string value)
		{
			return UInt16.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(UInt16 value)
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
			if (value is UInt16)
				return value.ToString();
			throw new ArgumentException("value is no UInt16.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class UInt32Converter : ITypeConverter<UInt32>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public UInt32Converter(IController target)
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
			UInt32 o;
			return UInt32.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			UInt32 o;
			return UInt32.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UInt32 Read(string value)
		{
			return UInt32.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(UInt32 value)
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
			if (value is UInt32)
				return value.ToString();
			throw new ArgumentException("value is no UInt32.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class UInt64Converter : ITypeConverter<UInt64>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public UInt64Converter(IController target)
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
			UInt64 o;
			return UInt64.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			UInt64 o;
			return UInt64.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public UInt64 Read(string value)
		{
			return UInt64.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(UInt64 value)
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
			if (value is UInt64)
				return value.ToString();
			throw new ArgumentException("value is no UInt64.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class SingleConverter : ITypeConverter<Single>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public SingleConverter(IController target)
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
			Single o;
			return Single.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Single o;
			return Single.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Single Read(string value)
		{
			return Single.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Single value)
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
			if (value is Single)
				return value.ToString();
			throw new ArgumentException("value is no Single.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class DoubleConverter : ITypeConverter<Double>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public DoubleConverter(IController target)
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
			Double o;
			return Double.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Double o;
			return Double.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Double Read(string value)
		{
			return Double.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Double value)
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
			if (value is Double)
				return value.ToString();
			throw new ArgumentException("value is no Double.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class DateTimeConverter : ITypeConverter<DateTime>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public DateTimeConverter(IController target)
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
			DateTime o;
			return DateTime.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			DateTime o;
			return DateTime.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public DateTime Read(string value)
		{
			return DateTime.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(DateTime value)
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
			if (value is DateTime)
				return value.ToString();
			throw new ArgumentException("value is no DateTime.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class TimeSpanConverter : ITypeConverter<TimeSpan>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public TimeSpanConverter(IController target)
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
			TimeSpan o;
			return TimeSpan.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			TimeSpan o;
			return TimeSpan.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public TimeSpan Read(string value)
		{
			return TimeSpan.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(TimeSpan value)
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
			if (value is TimeSpan)
				return value.ToString();
			throw new ArgumentException("value is no TimeSpan.");
		}
	}
	/// <summary>
	///
	/// </summary>
	public sealed partial class DecimalConverter : ITypeConverter<Decimal>
	{
		private IController target;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="target"></param>
		public DecimalConverter(IController target)
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
			Decimal o;
			return Decimal.TryParse(value, out o);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			Decimal o;
			return Decimal.TryParse(value, out o) ? (Object)o : null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Decimal Read(string value)
		{
			return Decimal.Parse(value);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Decimal value)
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
			if (value is Decimal)
				return value.ToString();
			throw new ArgumentException("value is no Decimal.");
		}
	}
}
