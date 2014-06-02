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
	public sealed class DuplicateKeyException : Exception
	{
		/// <summary>
		///
		/// </summary>
		public DuplicateKeyException()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="message"></param>
		public DuplicateKeyException(string message)
			: base(message)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>
		public DuplicateKeyException(string message, Exception inner)
			: base(message, inner)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DuplicateKeyException(
		  SerializationInfo info,
		  StreamingContext context)
			: base(info, context) { }
	}
}
