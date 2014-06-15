using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument.Exceptions
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public sealed class NotResolvedException : Exception
	{
		/// <summary>
		/// 
		/// </summary>
		public NotResolvedException() { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public NotResolvedException(string message) : base(message) { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>
		public NotResolvedException(string message, Exception inner) : base(message, inner) { }
	}
}
