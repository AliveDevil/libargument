namespace libargument
{
	internal struct Token
	{
		internal string Key;
		internal string Value;

		internal Token(string key, string value)
		{
			Key = key;
			Value = value;
		}

		internal bool HasValue { get { return Value != null; } }

		internal bool IsDefined { get { return Key != null; } }

		internal bool IsSwitch { get { return Value == null; } }

		public override string ToString()
		{
			return string.Format("{0}: {1}", Key, Value);
		}
	}
}
