using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace libargument
{
	internal sealed class Parameter : Binding
	{
		internal ParameterInfo Info;

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
	}
}
