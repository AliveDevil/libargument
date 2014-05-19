using libargument;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace libargument_Tests
{
	[TestClass]
	public class ParserTests
	{
		[TestMethod]
		public void TokenizeTest()
		{
			Parser<object> parser = new Parser<object>("/switch /switch=value");
			parser.Tokenize();
		}
	}
}
