using libargument;
using libargument.Attributes;
using System.Linq;

namespace libargument_Tests
{
	public class ParserTestObject : Controller
	{
		[Parse]
		public int DuplicateTest([Key("duplicate")] bool duplicate) { return 1; }

		[Parse]
		public int DuplicateTest2([Key("duplicate")] bool duplicate) { return 2; }

		[Parse]
		public int IEnumerable([Key("test")] string[] test) { return test.Count(); }

		[Parse]
		public string Name([Key("name")]bool name)
		{
			return Name();
		}

		[Parse]
		public int Test([Key("switch"), Abbreviation("s")] bool switchParameter) { return 7357; }

		[Parse]
		public int Test2([Key("action"), Abbreviation("a")] bool action) { return 73572; }

		[Parse]
		public int WhitespaceTest([Key("w")] string whitespace) { return 3; }

		[Parse]
		public int WhitespaceTest2([Key("w1")] string whitespace, [Key("w2")] string w2) { return 4; }
	}
}
