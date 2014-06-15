using libargument;
using libargument.Attributes;
using System.Linq;

namespace libargument_Tests
{
	public class ParserTestObject : Controller
	{
		[Option]
		[Key("test")]
		[Abbreviation("t")]
		public string Test;

		[Parse]
		public int DuplicateTest([Key("duplicate")] Switch duplicate)
		{
			return 1;
		}

		[Parse]
		public int DuplicateTest2([Key("duplicate")] Switch duplicate)
		{
			return 2;
		}

		[Parse]
		public int IEnumerable([Key("collection")] string[] test)
		{
			return test.Count();
		}

		[Parse]
		public string Name([Key("name")]Switch name)
		{
			return Name();
		}

		[Parse]
		public int SwitchTest([Key("switch"), Abbreviation("s")] Switch switchParameter)
		{
			return 7357;
		}

		[Parse]
		public int ActionTest([Key("action"), Abbreviation("a")] Switch action)
		{
			return 73572;
		}

		[Parse]
		public int WhitespaceTest([Key("w")] string whitespace)
		{
			return 3;
		}

		[Parse]
		public int WhitespaceTest2([Key("w1")] string whitespace, [Key("w2")] string w2)
		{
			return 4;
		}

		[Parse]
		public string OptionTest([Key("option")] Switch option)
		{
			return Test;
		}
	}
}
