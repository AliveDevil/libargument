using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Exceptions
{
	[Serializable]
	public class DuplicateKeyException : Exception
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
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}
