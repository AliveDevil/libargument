using System;
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
		public string Key;
		public bool Optional;
		public Token Token;
		public Type Type;

		public Parameter(ParameterInfo parameter)
		{
			Key = parameter.GetKey();
			Type = parameter.ParameterType;
			Abbreviations = parameter.GetAbbreviations().ToList();
			Optional = parameter.IsOptional;
			DefaultValue = parameter.DefaultValue;
			Token = default(Token);
		}

		public bool IsKnown(string key)
		{
			return Key.Equals(key, StringComparison.OrdinalIgnoreCase) | Abbreviations.Contains(key, OrdinalIgnoreCaseEqualityComparer.Singleton);
		}
	}
}
