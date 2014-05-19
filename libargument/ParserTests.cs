using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace libargument
{
	[TestClass]
	public sealed partial class Parser<T>
	{
		[TestMethod]
		public void TestInterpreteCharacterValueAppend()
		{
			// Tests for
			// append = !((character == '"' && !(inQuote && nextEscape)) && ((character == '\\' || character == ' ') && !nextEscape));
			// in interpreteCharacterValue()

			var test = new[]
			{
				// Character is "
				new { ExpectedAppend = false, InQuote = false, NextEscape = false, Character = '"' },
				new { ExpectedAppend = true, InQuote = false, NextEscape = true, Character = '"' },
				new { ExpectedAppend = false, InQuote = true, NextEscape = false, Character = '"' },
				new { ExpectedAppend = true, InQuote = true, NextEscape = true, Character = '"' },
				// Character is \\
				new { ExpectedAppend = false, InQuote = false, NextEscape = false, Character = '\\' },
				new { ExpectedAppend = true, InQuote = false, NextEscape = true, Character = '\\' },
				new { ExpectedAppend = false, InQuote = true, NextEscape = false, Character = '\\' },
				new { ExpectedAppend = true, InQuote = true, NextEscape = true, Character = '\\' },
				// Character is ' '
				new { ExpectedAppend = false, InQuote = false, NextEscape = false, Character = ' ' },
				new { ExpectedAppend = true, InQuote = false, NextEscape = true, Character = ' ' },
				new { ExpectedAppend = true, InQuote = true, NextEscape = false, Character = ' ' },
				new { ExpectedAppend = true, InQuote = true, NextEscape = true, Character = ' ' },
				// Character is (something else)
				new { ExpectedAppend = true, InQuote = false, NextEscape = false, Character = '\0' },
				new { ExpectedAppend = true, InQuote = false, NextEscape = true, Character = '\0' },
				new { ExpectedAppend = true, InQuote = true, NextEscape = false, Character = '\0' },
				new { ExpectedAppend = true, InQuote = true, NextEscape = true, Character = '\0' },
			};

			foreach (var item in test)
			{
				bool inQuote = item.InQuote, nextEscape = item.NextEscape, append, quit;
				interpreteCharacterValue(item.Character, '\0', ref inQuote, ref nextEscape, out append, out quit);
				Assert.AreEqual(item.ExpectedAppend, append);
			}
		}

		[TestMethod]
		public void TestInterpreteCharacterValueInQuote()
		{
			// Tests for
			//	if (character == '"' & !inQuote & lastCharacter == '\0')
			//		inQuote = true;
			// in interpreteCharacterValue()

			var test = new[]
			{
				// Character is ", and lastCharacter is empty
				new { ExpectedInQuote = true, InQuote = false, NextEscape = false, Character = '"', LastCharacter = '\0' },
				new { ExpectedInQuote = true, InQuote = false, NextEscape = true, Character = '"', LastCharacter = '\0' },
				new { ExpectedInQuote = true, InQuote = true, NextEscape = false, Character = '"', LastCharacter = '\0' },
				new { ExpectedInQuote = true, InQuote = true, NextEscape = true, Character = '"', LastCharacter = '\0' },
				// Character is ", and lastCharacter is not empty
				new { ExpectedInQuote = false, InQuote = false, NextEscape = false, Character = '"', LastCharacter = '\xff' },
				new { ExpectedInQuote = false, InQuote = false, NextEscape = true, Character = '"', LastCharacter = '\xff' },
				new { ExpectedInQuote = true, InQuote = true, NextEscape = false, Character = '"', LastCharacter = '\xff' },
				new { ExpectedInQuote = true, InQuote = true, NextEscape = true, Character = '"', LastCharacter = '\xff' },
			};

			foreach (var item in test)
			{
				bool inQuote = item.InQuote, nextEscape = item.NextEscape, append, quit;
				interpreteCharacterValue(item.Character, item.LastCharacter, ref inQuote, ref nextEscape, out append, out quit);
				Assert.AreEqual(item.ExpectedInQuote, inQuote);
			}
		}

		[TestMethod]
		public void TestInterpreteCharacterValueNextEscape()
		{
			// Tests for
			//	if (character == '\\' & !nextEscape)
			//		nextEscape = true;
			// in interpreteCharacterValue()

			var test = new[]
			{
				// Character is \
				new { ExpectedNextEscape = true, InQuote = false, NextEscape = false, Character = '\\' },
				new { ExpectedNextEscape = false, InQuote = false, NextEscape = true, Character = '\\' },
				new { ExpectedNextEscape = true, InQuote = true, NextEscape = false, Character = '\\' },
				new { ExpectedNextEscape = false, InQuote = true, NextEscape = true, Character = '\\' },
				// Character is something else
				new { ExpectedNextEscape = false, InQuote = false, NextEscape = false, Character = '\0' },
				new { ExpectedNextEscape = false, InQuote = false, NextEscape = true, Character = '\0' },
				new { ExpectedNextEscape = false, InQuote = true, NextEscape = false, Character = '\0' },
				new { ExpectedNextEscape = false, InQuote = true, NextEscape = true, Character = '\0' },
			};

			foreach (var item in test)
			{
				bool inQuote = item.InQuote, nextEscape = item.NextEscape, append, quit;
				interpreteCharacterValue(item.Character, '\0', ref inQuote, ref nextEscape, out append, out quit);
				Assert.AreEqual(item.ExpectedNextEscape, nextEscape);
			}
		}

		[TestMethod]
		public void TestInterpreteCharacterValueQuit()
		{
			// Tests for
			// quit = (character == '"' && inQuote && !nextEscape) || (character == ' ' && !(nextEscape && inQuote));
			// in interpreteCharacterValue()

			var test = new[]
			{
				// Character is "
				new { ExpectedQuit = false, InQuote = false, NextEscape = false, Character = '"' },
				new { ExpectedQuit = false, InQuote = false, NextEscape = true, Character = '"' },
				new { ExpectedQuit = true, InQuote = true, NextEscape = false, Character = '"' },
				new { ExpectedQuit = false, InQuote = true, NextEscape = true, Character = '"' },
				// Character is ' '
				new { ExpectedQuit = true, InQuote = false, NextEscape = false, Character = ' ' },
				new { ExpectedQuit = false, InQuote = false, NextEscape = true, Character = ' ' },
				new { ExpectedQuit = false, InQuote = true, NextEscape = false, Character = ' ' },
				new { ExpectedQuit = false, InQuote = true, NextEscape = true, Character = ' ' },
				// Character is (something else)
				new { ExpectedQuit = false, InQuote = false, NextEscape = false, Character = '\0' },
				new { ExpectedQuit = false, InQuote = false, NextEscape = true, Character = '\0' },
				new { ExpectedQuit = false, InQuote = true, NextEscape = false, Character = '\0' },
				new { ExpectedQuit = false, InQuote = true, NextEscape = true, Character = '\0' },
			};

			foreach (var item in test)
			{
				bool inQuote = item.InQuote, nextEscape = item.NextEscape, append, quit;
				interpreteCharacterValue(item.Character, '\0', ref inQuote, ref nextEscape, out append, out quit);
				Assert.AreEqual(item.ExpectedQuit, quit);
			}
		}

		[TestMethod]
		public void TestReadParameter()
		{
			var t = new[]
				{
					// Test if leading "/" are ignored.
					new { Test = "/switch", Expected = new Token("switch", null) },
					// Test if values are read.
					new { Test = "switch=value", Expected = new Token("switch","value") },
					// Test if values are read and leading "/" ignored.
					new { Test = "/switch=value", Expected = new Token("switch","value") },
					// Test if values with whitespace are read.
					new { Test = "switch=\"value with whitespace\"", Expected = new Token("switch","value with whitespace") },
					// Test if values with whitespace are read and "/" ignored.
					new { Test = "/switch=\"value with whitespace\"", Expected = new Token("switch","value with whitespace") },
					// Test for escaped quotes.
					new { Test = "/switch=\"value with \\\"double quote\\\"\"", Expected = new Token("switch","value with \"double quote\"") },
					// Test for escaped whitespace.
					new { Test = "/switch=value\\ with\\ escaped\\ whitespace", Expected = new Token("switch","value with escaped whitespace") },
				};
			foreach (var item in t)
			{
				using (var memory = new MemoryStream(Encoding.Default.GetBytes(item.Test)))
				using (var reader = new StreamReader(memory))
					Assert.AreEqual(item.Expected, readParameter(reader));
			}
		}
	}
}
