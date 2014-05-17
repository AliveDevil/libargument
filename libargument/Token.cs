﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	internal struct Token
	{
		public string Key;
		public string Value;

		public Token(string key, string value)
		{
			Key = key;
			Value = value;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}", Key, Value);
		}
	}
}
