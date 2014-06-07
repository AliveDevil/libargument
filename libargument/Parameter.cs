using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace libargument
{
	internal struct Parameter
	{
		internal List<string> Abbreviations;
		internal object DefaultValue;
		internal ParameterInfo Info;
		internal bool IsArray;
		internal bool IsOptional;
		internal string Key;
		internal List<Token> Token;
		internal Type Type;

		internal Parameter(ParameterInfo parameter)
		{
			Info = parameter;
			Key = Info.GetKey();
			IsArray = Info.ParameterType.IsArray;
			Type = Info.GetParameterType();
			Abbreviations = Info.GetAbbreviations().ToList();
			IsOptional = Info.IsOptional;
			DefaultValue = Info.DefaultValue;
			Token = new List<Token>();
		}

		internal bool IsKnown(string key)
		{
			return Key.Equals(key, StringComparison.OrdinalIgnoreCase) | Abbreviations.Contains(key, OrdinalIgnoreCaseEqualityComparer.Singleton);
		}
	}
}
