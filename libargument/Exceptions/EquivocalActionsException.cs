using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace libargument.Exceptions
{
	[Serializable]
	// any english speaking people: is that name right?
	public class EquivocalActionsException : Exception
	{
		public EquivocalActionsException()
		{
		}

		public EquivocalActionsException(string message)
			: base(message)
		{
		}

		public EquivocalActionsException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected EquivocalActionsException(
		  SerializationInfo info,
		  StreamingContext context)
			: base(info, context) { }
	}
}
