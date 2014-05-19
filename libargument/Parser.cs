using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace libargument
{
	/// <summary>
	///
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed partial class Parser<T>
	{
		private const string header = "Help powered by libargument {0}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument\nSkip with /noheader\n";
		private string arguments;

		/// <summary>
		/// Creates an Parser-object with Environment.CommandLine as argument.
		/// </summary>
		public Parser()
			: this(Environment.CommandLine)
		{
		}

		/// <summary>
		/// Constructor for copying getting custom arguments.
		/// </summary>
		public Parser(string arguments)
		{
			this.arguments = arguments;
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

		/// <summary>
		/// Reads Environment.CommandLine and prepares tokens.
		/// </summary>
		/// <returns>If creation of tokens was successful.</returns>
		public bool Tokenize()
		{
			var tokenList = new List<Token>();
			using (var memory = new MemoryStream(Encoding.Default.GetBytes(arguments), false))
			using (var reader = new StreamReader(memory))
			{
				int c;
				while ((c = reader.Peek()) != -1)
				{
					tokenList.Add(readParameter(reader));
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
