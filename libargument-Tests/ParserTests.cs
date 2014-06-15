using libargument;
using libargument.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace libargument_Tests
{
	[TestClass]
	public sealed class ParserTests
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
		public void MatchIEnumerableTest()
		{
			var parser = new Parser<ParserTestObject>("/collection=test1 /collection=test2");
			parser.Tokenize();
			Assert.AreEqual(2, parser.Match<int>());
		}

		[TestMethod]
		[ExpectedException(typeof(NotResolvedException))]
		public void MatchNotResolved()
		{
			var parser = new Parser<ParserTestObject>("/notfound");
			parser.Tokenize();
			parser.Match();
		}

		[TestMethod]
		[ExpectedException(typeof(ActionNotFoundException))]
		public void MatchNotFoundTest()
		{
			var parser = new Parser<ParserTestObject>("/w1=test");
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

		[TestMethod]
		public void MatchWhitespace()
		{
			var parser = new Parser<ParserTestObject>("/w=\"test whitespace\"");
			parser.Tokenize();
			Assert.AreEqual(3, parser.Match<int>());
		}
		[TestMethod]
		public void MatchWhitespace2()
		{
			var parser = new Parser<ParserTestObject>("/w1=test /w2=\"test whitespace\"");
			parser.Tokenize();
			Assert.AreEqual(4, parser.Match<int>());
		}

		[TestMethod]
		public void NamedTest()
		{
			var parser = new Parser<ParserNamedTestObject>("/name");
			parser.Tokenize();
			Assert.AreEqual("Tests", parser.Match<string>());
		}

		[TestMethod]
		public void UnnamedTest()
		{
			var parser = new Parser<ParserTestObject>("/name");
			parser.Tokenize();
			Assert.AreEqual("libargument-Tests", parser.Match<string>());
		}

		[TestMethod]
		public void OptionTest()
		{
			var parser = new Parser<ParserTestObject>("/option /test=test");
			parser.Tokenize();
			Assert.AreEqual("test", parser.Match<string>());
		}

		[TestMethod]
		public void MultipleSwitchesTest()
		{
			var parser = new Parser<ParserTestObject>("/switch1 /switch2");
			parser.Tokenize();
			Assert.AreEqual(165, parser.Match<int>());
		}
	}
}
