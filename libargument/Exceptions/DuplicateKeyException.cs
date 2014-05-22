using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace libargument.Exceptions
{
	[Serializable]
	public sealed class DuplicateKeyException : Exception
	{
		public DuplicateKeyException()
		{
		}

		public DuplicateKeyException(string message)
			: base(message)
		{
		}

		public DuplicateKeyException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected DuplicateKeyException(
		  SerializationInfo info,
		  StreamingContext context)
			: base(info, context) { }
	}
}
