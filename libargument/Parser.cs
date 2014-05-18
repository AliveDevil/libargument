#if DEBUG

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endif

using System;
using System.IO;
using System.Text;

namespace libargument
{
	/// <summary>
	///
	/// </summary>
	/// <typeparam name="T"></typeparam>
#if DEBUG

	[TestClass]
#endif

	public sealed class Parser
	{
		private const string header = "Help powered by libargument {0}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument\nSkip with /noheader\n";

		/// <summary>
		/// Default constructor. Does nothing at all.
		/// </summary>
		public Parser()
		{
		}

		/// <summary>
		/// Prints help for current type.
		/// </summary>
		public void Help()
		{
			Console.Write("Application name. Dummy\n");
			Console.Write(header, GetType().Assembly.GetName().Version);
		}

		/// <summary>
		/// Prints help for provided switch in current type.
		/// </summary>
		/// <param name="switch">Selected switch.</param>
		public void Help(string @switch)
		{
			Console.Write("Application name. Dummy\n");
			Console.Write(header, GetType().Assembly.GetName().Version);
		}

#if DEBUG

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

#endif

		/// <summary>
		/// Reads Environment.CommandLine and prepares tokens.
		/// </summary>
		/// <returns>If creation of tokens was successful.</returns>
		public bool Tokenize()
		{
			using (var memory = new MemoryStream(Encoding.Default.GetBytes(Environment.CommandLine), false))
			using (var reader = new StreamReader(memory))
			{
				int c;
				while ((c = reader.Peek()) != -1)
				{
					if ((char)c == '/')
					{
					}
				}
			}
			return false;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="character"></param>
		/// <param name="lastCharacter"></param>
		/// <param name="inQuote"></param>
		/// <param name="nextEscape"></param>
		/// <returns></returns>
		private void interpreteCharacterValue(char character, char lastCharacter, ref bool inQuote, ref bool nextEscape, out bool append, out bool quit)
		{
			//	do not append if
			//		character is "
			//			and not nextEscape
			//		character is \
			//			and not nextEscape
			//		character is ' '
			//			and not
			//				nextEscape
			//				or inQuote
			append = !((character == '"' & !nextEscape) | (character == '\\' & !nextEscape) | (character == ' ' & !(nextEscape | inQuote)));

			//	quit if
			//		character is "
			//			and inQuote and not nextEscape
			//		character is ' '
			//			and not
			//				inQuote
			//				or nextEscape
			quit = (character == '"' & inQuote & !nextEscape) | (character == ' ' & !(nextEscape | inQuote));

			if (character == '"' & !inQuote & lastCharacter == '\0')
				inQuote = true;
			var setNextEscape = false;
			if (character == '\\' & !nextEscape)
				setNextEscape = true;
			nextEscape = setNextEscape;
		}

		/// <summary>
		/// Tries to read a parameter out of the CommandLine.
		/// </summary>
		/// <param name="reader">A reader providing access to CommandLine</param>
		/// <returns></returns>
		private Token readParameter(StreamReader reader)
		{
			var token = default(Token);
			int read;

			if ((read = reader.Peek()) != -1 && (char)read == '/')
				read = reader.Read();

			token.Key = readParameterKey(reader);

			read = reader.Read();
			if (read != -1 && (char)read == '=')
			{
				token.Value = readParameterValue(reader);
			}

			return token;
		}

		/// <summary>
		/// Reads the key for a parameter.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private string readParameterKey(StreamReader reader)
		{
			var tokenBuilder = new StringBuilder();
			int read;
			char character;

			while ((read = reader.Peek()) != -1)
			{
				character = (char)read;

				if (character == '=')
					break;
				else if (character != '/')
					tokenBuilder.Append(character);

				read = reader.Read();
			}

			return tokenBuilder.ToString();
		}

		/// <summary>
		/// Reads a value from parameter.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		private string readParameterValue(StreamReader reader)
		{
			var tokenBuilder = new StringBuilder();
			int read;
			char character, lastCharacter = '\0';
			bool append = false, quit = false, inQuote = false, nextEscape = false, lastEscape;
			while (!quit & (read = reader.Read()) != -1)
			{
				character = (char)read;
				lastEscape = nextEscape;

				interpreteCharacterValue(character, lastCharacter, ref inQuote, ref nextEscape, out append, out quit);
				if (append)
					tokenBuilder.Append(character);

				if (lastEscape)
					nextEscape = false;
				lastCharacter = character;
			}
			return tokenBuilder.ToString();
		}
	}
}
