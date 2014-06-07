﻿using libargument.Attributes;
using System;
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
		internal static string ApplicationName(this IController controller)
		{
			var applicationNames = controller.GetType().UnderlyingSystemType.GetCustomAttributes(false).OfType<ApplicationNameAttribute>();
			if (applicationNames.Any())
				return applicationNames.First().Name;
			else
				return controller.GetType().UnderlyingSystemType.Assembly.GetName().Name;
		}

		internal static IEnumerable<string> GetAbbreviations(this ParameterInfo parameter)
		{
			return parameter.GetCustomAttributes(false).OfType<AbbreviationAttribute>().Select(item => item.Abbreviation);
		}

		internal static string GetKey(this ParameterInfo parameter)
		{
			var keyAttributes = parameter.GetCustomAttributes(false).OfType<KeyAttribute>();
			if (keyAttributes.Any())
				return keyAttributes.First().Key;
			return parameter.Name;
		}

		internal static Type GetParameterType(this ParameterInfo parameter)
		{
			if (parameter.ParameterType.IsArray)
				return parameter.ParameterType.GetElementType();
			return parameter.ParameterType;
		}

		internal static bool HasKey(this ICollection<Parameter> parameter, Token token)
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

		internal static bool IsParse(this MethodInfo method)
		{
			return method.GetCustomAttributes(false).OfType<ParseAttribute>().Any();
		}
	}
}
