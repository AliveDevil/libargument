using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace libargument
{
	internal struct Field
	{
		internal List<string> Abbreviations;
		internal FieldInfo Info;
		internal bool IsArray;
		internal string Key;
		internal List<Token> Token;
		internal Type Type;

		internal Field(FieldInfo parameter)
		{
			Info = parameter;
			Key = Info.GetKey();
			IsArray = Info.FieldType.IsArray;
			Type = Info.FieldType;
			Abbreviations = Info.GetAbbreviations().ToList();
			Token = new List<Token>();
		}

		internal bool IsKnown(string key)
		{
			return Key.Equals(key, StringComparison.OrdinalIgnoreCase) | Abbreviations.Contains(key, OrdinalIgnoreCaseEqualityComparer.Singleton);
		}
	}
}
