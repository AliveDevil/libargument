using libargument.Conversion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	internal static class Assembling
	{
		public static IEnumerable ResolveCollection(ITypeConverter converter, Parameter parameter)
		{
			if (parameter.Token.Count == 0 && parameter.IsOptional)
				return parameter.DefaultValue as IEnumerable;

			var list = new List<object>();

			foreach (var item in parameter.Token)
			{
				if (item.IsDefined && item.HasValue && converter.CanRead(item.Value))
					list.Add(converter.Read(item.Value));
			}

			return list;
		}

		public static object ResolveValue(ITypeConverter converter, Parameter parameter)
		{
			if (parameter.Token.Count == 0)
				throw new Exception();
			if (parameter.Token.Count > 1)
				throw new Exception();
			if (!parameter.Token[0].IsDefined)
				if (parameter.IsOptional)
					return parameter.DefaultValue;
				else
					throw new Exception();

			return converter.Read(parameter.Token[0].Value);
		}
	}
}
