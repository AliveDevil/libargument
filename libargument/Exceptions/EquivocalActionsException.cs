using System;

namespace libargument.Exceptions
{
	/// <summary>
	/// Thrown if Parser can has multiple choices for executing a method.
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
	}
}
