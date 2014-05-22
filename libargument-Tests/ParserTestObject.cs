using libargument;
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
		public int DuplicateTest([Key("duplicate")] bool duplicate) { return 1; }

		[Parse]
		public int DuplicateTest2([Key("duplicate")] bool duplicate) { return 2; }

		[Parse]
		public int Test([Key("switch"), Abbreviation("s")] bool switchParameter) { return 7357; }

		[Parse]
		public int Test2([Key("action"), Abbreviation("a")] bool action) { return 73572; }
	}
}
