﻿using libargument.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	/// <summary>
	///
	/// </summary>
	public interface IController
	{
		/// <summary>
		///
		/// </summary>
		void Help();

		/// <summary>
		///
		/// </summary>
		void PrintHeader();

		/// <summary>
		///
		/// </summary>
		/// <param name="type"></param>
		/// <param name="typeConverter"></param>
		void RegisterTypeConverter(Type type, ITypeConverter typeConverter);

		/// <summary>
		///
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="typeConverter"></param>
		void RegisterTypeConverter<T>(ITypeConverter<T> typeConverter);

		/// <summary>
		///
		/// </summary>
		/// <param name="targetType"></param>
		/// <returns></returns>
		ITypeConverter ResolveType(Type targetType);

		/// <summary>
		///
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		ITypeConverter<T> ResolveType<T>();
	}
}
