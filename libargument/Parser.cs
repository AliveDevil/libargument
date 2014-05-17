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
			bool quit = false, inQuote = false, nextEscape = false, lastEscape;
			while (!quit & (read = reader.Read()) != -1)
			{
				character = (char)read;
				lastEscape = nextEscape;

				switch (character)
				{
					case '"':
						if (!inQuote && lastCharacter == '\0')
							inQuote = true;
						else if (inQuote)
							if (nextEscape)
								tokenBuilder.Append('"');
							else
								quit = true;
						else
							quit = true;
						break;

					case '\\':
						if (nextEscape)
							tokenBuilder.Append('\\');
						else
							nextEscape = true;
						break;

					case ' ':
						if (nextEscape || inQuote)
							tokenBuilder.Append(' ');
						else
							quit = true;
						break;

					default:
						tokenBuilder.Append(character);
						break;
				}

				if (lastEscape)
					nextEscape = false;
				lastCharacter = character;
			}
			return tokenBuilder.ToString();
		}
	}
}
