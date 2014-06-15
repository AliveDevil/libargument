using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace libargument
{
	internal sealed class Field : Binding
	{
		internal FieldInfo Info;

		internal Field(FieldInfo parameter)
		{
			Info = parameter;
			Key = Info.GetKey();
			IsArray = Info.FieldType.IsArray;
			Type = Info.FieldType;
			Abbreviations = Info.GetAbbreviations().ToList();
			Token = new List<Token>();
		}
	}
}
