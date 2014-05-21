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
		private const string header = "Help powered by libargument {0}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument/\nSkip with /noheader\n";
		private readonly Dictionary<Type, ITypeConverter> typeConverter;

		public Controller()
		{
			typeConverter = new Dictionary<Type, ITypeConverter>();
			registerDefaultConverter();
		}

		[Parse]
		public void Help([Abbreviation("h"), Abbreviation("?")] bool help, bool noLogo = false)
		{
			if (!noLogo) PrintHeader();
		}

		public void Help()
		{
			Help(true, false);
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

		private void PrintHeader()
		{
			Console.Write(header, GetType().Assembly.GetName().Version);
		}
	}
}
