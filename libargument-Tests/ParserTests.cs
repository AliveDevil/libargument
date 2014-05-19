using libargument;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace libargument_Tests
{
	[TestClass]
	public class ParserTests
	{
		[TestMethod]
		public void MatchTest()
		{
			var parser = new Parser<ParserTestObject>("/switch");
			parser.Tokenize();
			parser.Match();
		}

		[TestMethod]
		public void TokenizeTest()
		{
			var parser = new Parser<object>("/switch /switch=value");
			parser.Tokenize();
		}
	}
}
