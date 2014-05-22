using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace libargument.Exceptions
{
	[Serializable]
	public class ActionNotFoundException : Exception
	{
		public ActionNotFoundException()
		{
		}

		public ActionNotFoundException(string message)
			: base(message)
		{
		}

		public ActionNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ActionNotFoundException(
		  SerializationInfo info,
		  StreamingContext context)
			: base(info, context) { }
	}
}
