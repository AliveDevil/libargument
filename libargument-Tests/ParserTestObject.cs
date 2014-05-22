﻿using libargument;
using libargument.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libargument_Tests
{
	public class ParserTestObject : Controller
	{
		[Parse]
		public void Test([Key("switch"), Abbreviation("s")] bool switchParameter) { }

		[Parse]
		public void Test2([Key("action"), Abbreviation("a")] bool action) { }
	}
}
