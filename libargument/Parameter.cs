using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace libargument
{
	internal struct Parameter
	{
		public List<string> Abbreviations;
		public object DefaultValue;
		public bool IsIEnumerable;
		public bool IsOptional;
		public string Key;
		public List<Token> Token;
		public Type Type;

		public Parameter(ParameterInfo parameter)
		{
			Key = parameter.GetKey();
			IsIEnumerable = parameter.ParameterType == typeof(IEnumerable);
			Type = parameter.GetParameterType();
			Abbreviations = parameter.GetAbbreviations().ToList();
			IsOptional = parameter.IsOptional;
			DefaultValue = parameter.DefaultValue;
			Token = new List<Token>();
		}

		public bool IsKnown(string key)
		{
			return Key.Equals(key, StringComparison.OrdinalIgnoreCase) | Abbreviations.Contains(key, OrdinalIgnoreCaseEqualityComparer.Singleton);
		}
	}
}
