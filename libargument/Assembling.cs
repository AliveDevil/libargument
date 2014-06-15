using libargument.Conversion;
using System;
using System.Collections;

namespace libargument
{
	internal static class Assembling
	{
		internal static object ResolveCollection(ITypeConverter converter, Binding binding)
		{
			if (binding.Token.Count == 0 && binding.IsOptional)
				return binding.DefaultValue;

			var list = new ArrayList();

			foreach (var item in binding.Token)
			{
				if (item.IsDefined && item.HasValue && converter.CanRead(item.Value))
					list.Add(Convert.ChangeType(converter.Read(item.Value), binding.Type));
			}

			var type = binding.Type.MakeArrayType();
			var array = Activator.CreateInstance(type, new object[] { list.Count });

			for (int i = 0; i < list.Count; i++)
			{
				type.GetMethod("Set").Invoke(array, new object[] { i, list[i] });
			}

			return array;
		}

		internal static object ResolveValue(ITypeConverter converter, Binding binding)
		{
			if (binding.Token.Count == 0)
				throw new Exception();
			if (binding.Token.Count > 1)
				throw new Exception();
			if (!binding.Token[0].IsDefined)
				if (binding.IsOptional)
					return binding.DefaultValue;
				else
					throw new Exception();

			return converter.Read(binding.Token[0].Value);
		}
	}
}
