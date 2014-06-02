using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Conversion
{
	/// <summary>
	///
	/// </summary>
	public interface ITypeConverter
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		bool CanRead(string value);

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object Read(string value);

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		string Write(object value);
	}

	/// <summary>
	/// Generic interface to <see cref="T:libargument.ITypeConverter"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ITypeConverter<T> : ITypeConverter
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		new T Read(string value);

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		string Write(T value);
	}
}
