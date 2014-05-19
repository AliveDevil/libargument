using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	internal sealed class OrdinalIgnoreCaseEqualityComparer : IEqualityComparer<string>
	{
		public readonly static OrdinalIgnoreCaseEqualityComparer Singleton = new OrdinalIgnoreCaseEqualityComparer();

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
