﻿using libargument;
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
			var parser = new Parser<ParserTestObject>("/test=test1 /test=test2");
			parser.Tokenize();
			Assert.AreEqual(2, parser.Match<int>());
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

		[TestMethod]
		public void MatchWhitespace()
		{
			var parser = new Parser<ParserTestObject>("/whitespace=\"test whitespace\"");
			parser.Tokenize();
			Assert.AreEqual(3, parser.Match<int>());
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
	}
}
