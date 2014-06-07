using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace libargument
{
	internal struct Method
	{
		internal string Key;
		internal MethodInfo MethodInfo;
		internal List<Parameter> Parameter;

		internal Method(MethodInfo method)
		{
			Key = method.Name;
			Parameter = method.GetParameters().Select(parameter => new Parameter(parameter)).ToList();
			MethodInfo = method;
		}
	}
}
