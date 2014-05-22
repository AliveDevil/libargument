using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace libargument
{
	internal struct Method
	{
		public string Key;
		public MethodInfo MethodInfo;
		public List<Parameter> Parameter;

		public Method(MethodInfo method)
		{
			Key = method.Name;
			Parameter = method.GetParameters().Select(parameter => new Parameter(parameter)).ToList();
			MethodInfo = method;
		}
	}
}
