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
		public ParameterInfo Info;
		public bool IsArray;
		public bool IsOptional;
		public string Key;
		public List<Token> Token;
		public Type Type;

		public Parameter(ParameterInfo parameter)
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

		public bool IsKnown(string key)
		{
			return Key.Equals(key, StringComparison.OrdinalIgnoreCase) | Abbreviations.Contains(key, OrdinalIgnoreCaseEqualityComparer.Singleton);
		}
	}
}
