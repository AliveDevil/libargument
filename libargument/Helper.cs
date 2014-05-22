using libargument.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace libargument
{
	/// <summary>
	/// Provides access to functions for better experience.
	/// </summary>
	internal static class Helper
	{
		public static IEnumerable<string> GetAbbreviations(this ParameterInfo parameter)
		{
			return parameter.GetCustomAttributes(false).OfType<AbbreviationAttribute>().Select(item => item.Abbreviation);
		}

		public static string GetKey(this ParameterInfo parameter)
		{
			var keyAttributes = parameter.GetCustomAttributes(false).OfType<KeyAttribute>();
			if (keyAttributes.Any())
				return keyAttributes.First().Key;
			return parameter.Name;
		}

		public static bool IsParse(this MethodInfo method)
		{
			return method.GetCustomAttributes(false).OfType<ParseAttribute>().Any();
		}
	}
}
