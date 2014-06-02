using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace libargument.Exceptions
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	// any english speaking people: is that name right?
	public sealed class EquivocalActionsException : Exception
	{
		/// <summary>
		///
		/// </summary>
		public EquivocalActionsException()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="message"></param>
		public EquivocalActionsException(string message)
			: base(message)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>
		public EquivocalActionsException(string message, Exception inner)
			: base(message, inner)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EquivocalActionsException(
		  SerializationInfo info,
		  StreamingContext context)
			: base(info, context) { }
	}
}
