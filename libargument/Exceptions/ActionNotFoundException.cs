using System;

namespace libargument.Exceptions
{
	/// <summary>
	/// Thrown if an action has not been found in current controller instance.
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
	}
}
