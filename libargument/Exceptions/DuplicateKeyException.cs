﻿using System;

namespace libargument.Exceptions
{
	/// <summary>
	/// Thrown if a duplicate key has been found.
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
	}
}
