using libargument;
using libargument.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace libargument_Tests
{
	[TestClass]
	public class ParserTests
	{
		[TestMethod]
		public void MatchAbbreviationTest()
		{
			var parser = new Parser<ParserTestObject>("/a");
			parser.Tokenize();
			Assert.AreEqual(73572, parser.Match<int>());
		}

		[TestMethod]
		[ExpectedException(typeof(EquivocalActionsException))]
		public void MatchEquivocalTest()
		{
			var parser = new Parser<ParserTestObject>("/duplicate");
			parser.Tokenize();
			parser.Match();
		}

		[TestMethod]
		[ExpectedException(typeof(ActionNotFoundException))]
		public void MatchNotFoundTest()
		{
			var parser = new Parser<ParserTestObject>("/notfound");
			parser.Tokenize();
			parser.Match();
		}

		[TestMethod]
		public void MatchTest()
		{
			var parser = new Parser<ParserTestObject>("/action");
			parser.Tokenize();
			Assert.AreEqual(73572, parser.Match<int>());
		}
	}
}
