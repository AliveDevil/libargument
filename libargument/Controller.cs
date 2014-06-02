﻿using libargument.Attributes;
using libargument.Conversion;
using libargument.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	public abstract partial class Controller : IController
	{
		private const string header = "== {0} ==\nPowered by libargument {1}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument/\nSkip with /noheader\n";
		private readonly Dictionary<Type, ITypeConverter> typeConverter;

		public Controller()
		{
			typeConverter = new Dictionary<Type, ITypeConverter>();
			registerDefaultConverter(this);
		}

		[Parse]
		public void Help([Abbreviation("h"), Abbreviation("?")] bool help, bool noHeader = false)
		{
			if (!noHeader) PrintHeader();
		}

		public void Help()
		{
			Help(true, false);
		}

		public void PrintHeader()
		{
			Console.Write(header, Name(), GetType().Assembly.GetName().Version);
		}

		public void RegisterTypeConverter(Type type, ITypeConverter typeConverter)
		{
			if (this.typeConverter.ContainsKey(type))
				throw new DuplicateKeyException();
			this.typeConverter.Add(type, typeConverter);
		}

		public void RegisterTypeConverter<T>(ITypeConverter<T> typeConverter)
		{
			RegisterTypeConverter(typeof(T), typeConverter);
		}

		public ITypeConverter ResolveType(Type targetType)
		{
			if (typeConverter.ContainsKey(targetType))
				return typeConverter[targetType];
			throw new KeyNotFoundException();
		}

		public ITypeConverter<T> ResolveType<T>()
		{
			return (ITypeConverter<T>)ResolveType(typeof(T));
		}

		protected virtual string Name()
		{
			return this.ApplicationName();
		}
	}
}
