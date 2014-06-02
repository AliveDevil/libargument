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
	public sealed class ActionNotFoundException : Exception
	{
		/// <summary>
		///
		/// </summary>
		public ActionNotFoundException()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="message"></param>
		public ActionNotFoundException(string message)
			: base(message)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>

		public ActionNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ActionNotFoundException(
		  SerializationInfo info,
		  StreamingContext context)
			: base(info, context) { }
	}
}
