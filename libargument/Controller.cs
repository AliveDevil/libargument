using libargument.Attributes;
using libargument.Conversion;
using libargument.Exceptions;
using System;
using System.Collections.Generic;

namespace libargument
{
	/// <summary>
	///
	/// </summary>
	public abstract partial class Controller : IController
	{
		private const string header = "== {0} ==\nPowered by libargument {1}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument/\nSkip with /noheader\n";
		private readonly Dictionary<Type, ITypeConverter> typeConverter;

		/// <summary>
		///
		/// </summary>
		public Controller()
		{
			typeConverter = new Dictionary<Type, ITypeConverter>();
			registerDefaultConverter(this);
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool SkipUnresolvedArguments
		{
			get { return false; }
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="help"></param>
		/// <param name="noHeader"></param>
		[Parse]
		public void Help([Abbreviation("h"), Abbreviation("?")] bool help, bool noHeader = false)
		{
			if (!noHeader) PrintHeader();
		}

		/// <summary>
		///
		/// </summary>
		public void Help()
		{
			Help(true, false);
		}

		/// <summary>
		///
		/// </summary>
		public void PrintHeader()
		{
			Console.Write(header, Name(), GetType().Assembly.GetName().Version);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="type"></param>
		/// <param name="typeConverter"></param>
		public void RegisterTypeConverter(Type type, ITypeConverter typeConverter)
		{
			if (this.typeConverter.ContainsKey(type))
				throw new DuplicateKeyException();
			this.typeConverter.Add(type, typeConverter);
		}

		/// <summary>
		///
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="typeConverter"></param>
		public void RegisterTypeConverter<T>(ITypeConverter<T> typeConverter)
		{
			RegisterTypeConverter(typeof(T), typeConverter);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="targetType"></param>
		/// <returns></returns>
		public ITypeConverter ResolveType(Type targetType)
		{
			if (typeConverter.ContainsKey(targetType))
				return typeConverter[targetType];
			throw new KeyNotFoundException();
		}

		/// <summary>
		///
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public ITypeConverter<T> ResolveType<T>()
		{
			return (ITypeConverter<T>)ResolveType(typeof(T));
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		protected virtual string Name()
		{
			return this.ApplicationName();
		}
	}
}
