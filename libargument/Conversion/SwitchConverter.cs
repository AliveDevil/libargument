namespace libargument.Conversion
{
	/// <summary>
	///
	/// </summary>
	public sealed class SwitchConverter : ITypeConverter<Switch>
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CanRead(string value)
		{
			return true;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		object ITypeConverter.Read(string value)
		{
			return new Switch();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public Switch Read(string value)
		{
			return new Switch();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(Switch value)
		{
			return "";
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public string Write(object value)
		{
			return "";
		}
	}
}
