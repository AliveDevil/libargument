﻿using System;
using System.Collections.Generic;

namespace libargument
{
	internal sealed class OrdinalIgnoreCaseEqualityComparer : IEqualityComparer<string>
	{
		internal readonly static OrdinalIgnoreCaseEqualityComparer Singleton = new OrdinalIgnoreCaseEqualityComparer();

		public bool Equals(string x, string y)
		{
			return x.Equals(y, StringComparison.OrdinalIgnoreCase);
		}

		public int GetHashCode(string obj)
		{
			return obj.ToLowerInvariant().GetHashCode();
		}
	}
}
