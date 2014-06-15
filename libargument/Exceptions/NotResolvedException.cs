using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Exceptions
{
	[Serializable]
	public sealed class NotResolvedException : Exception
	{
		public NotResolvedException() { }
		public NotResolvedException(string message) : base(message) { }
		public NotResolvedException(string message, Exception inner) : base(message, inner) { }
	}
}
