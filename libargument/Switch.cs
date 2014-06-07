using System;

namespace libargument
{
	/// <summary>
	///
	/// </summary>
	public sealed class Switch : IEquatable<Boolean>
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="switch"></param>
		/// <returns></returns>
		public static implicit operator Boolean(Switch @switch)
		{
			return @switch != null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static Boolean operator !=(Switch left, Switch right)
		{
			return (Boolean)left != (Boolean)right;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static Boolean operator ==(Switch left, Switch right)
		{
			return (Boolean)left == (Boolean)right;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			return obj is Switch && obj != null;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(bool other)
		{
			return other;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns>Always returns -1</returns>
		public override int GetHashCode()
		{
			return -1;
		}
	}
}
