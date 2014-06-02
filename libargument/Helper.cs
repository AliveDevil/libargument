using libargument.Attributes;
using System;
using System.Collections;
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
		public static string ApplicationName(IController controller)
		{
			var applicationNames = controller.GetType().UnderlyingSystemType.GetCustomAttributes(false).OfType<ApplicationNameAttribute>();
			if (applicationNames.Any())
				return applicationNames.First().Name;
			else
				return controller.GetType().UnderlyingSystemType.Name;
		}

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

		public static Type GetParameterType(this ParameterInfo parameter)
		{
			if (parameter.ParameterType.IsArray)
				return parameter.ParameterType.GetElementType();
			return parameter.ParameterType;
		}

		public static bool HasKey(this ICollection<Parameter> parameter, Token token)
		{
			bool anyKnown = false;
			foreach (var p in parameter)
			{
				if (p.IsKnown(token.Key))
				{
					anyKnown = true;
					if (!p.Token.Contains(token))
						p.Token.Add(token);
				}
			}
			return anyKnown;
		}

		public static bool IsParse(this MethodInfo method)
		{
			return method.GetCustomAttributes(false).OfType<ParseAttribute>().Any();
		}
	}
}
