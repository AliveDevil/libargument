using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	internal abstract class Binding
	{
		internal List<string> Abbreviations;
		internal bool IsArray;
		internal bool IsOptional;
		internal string Key;
		internal List<Token> Token;
		internal Type Type;
		internal object DefaultValue;

		internal bool IsKnown(Token token)
		{
			bool known = Key.Equals(token.Key, StringComparison.OrdinalIgnoreCase)
				| Abbreviations.Contains(token.Key, OrdinalIgnoreCaseEqualityComparer.Singleton);

			if (known && !Token.Contains(token))
				Token.Add(token);

			return known;
		}
	}
}
