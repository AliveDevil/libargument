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
		public static object ResolveCollection(ITypeConverter converter, Parameter parameter)
		{
			if (parameter.Token.Count == 0 && parameter.IsOptional)
				return parameter.DefaultValue;

			var list = new ArrayList();

			foreach (var item in parameter.Token)
			{
				if (item.IsDefined && item.HasValue && converter.CanRead(item.Value))
					list.Add(Convert.ChangeType(converter.Read(item.Value), parameter.Type));
			}

			var type = parameter.Type.MakeArrayType();
			var array = Activator.CreateInstance(type, new object[] { list.Count });

			for (int i = 0; i < list.Count; i++)
			{
				type.GetMethod("Set").Invoke(array, new object[] { i, list[i] });
			}

			return array;
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
