using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace libargument
{
	/// <summary>
	///
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed partial class Parser<T> where T : IController
	{
		private const string header = "Help powered by libargument {0}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument/\nSkip with /noheader\n";
		private string arguments;
		private List<Token> tokenList;

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
		///
		/// </summary>
		/// <returns></returns>
		public void Match()
		{
			// prepare for bad code. Will be improved over time.

			var targetType = typeof(T);
			var methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance).Where(item => item.ReturnType == typeof(void));
			var lookup = methods.Select(item => new
			{
				Key = item.Name,
				Parameter = item.GetParameters().Select(parameter => new
				{
					Key = parameter.GetKey(),
					Type = parameter.ParameterType,
					Abbreviations = parameter.GetAbbreviations(),
					DefaultValue = parameter.DefaultValue
				}),
				MethodInfo = item
			}).ToList();

			foreach (var item in tokenList)
			{
				lookup = lookup.Where(method => method.Parameter.Any(parameter => parameter.Key.Equals(item.Key, StringComparison.OrdinalIgnoreCase) | parameter.Abbreviations.Contains(item.Key, OrdinalIgnoreCaseEqualityComparer.Singleton))).ToList();
			}

			if (lookup.Count == 0)
				throw new InvalidOperationException(); // add descriptive message
			if (lookup.Count > 1)
				throw new InvalidOperationException(); // add descriptive message
		}

		/// <summary>
		/// Reads Environment.CommandLine and prepares tokens.
		/// </summary>
		/// <returns>If creation of tokens was successful.</returns>
		public void Tokenize()
		{
			if (tokenList == null)
				tokenList = new List<Token>();
			tokenList.Clear();
			using (var memory = new MemoryStream(Encoding.Default.GetBytes(arguments), false))
			using (var reader = new StreamReader(memory))
				while (reader.Peek() != -1)
					tokenList.Add(readParameter(reader));
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

			// skip any leading '/' and whitespace
			while ((read = reader.Peek()) != -1 && ((char)read == '/' | (char)read == ' '))
				read = reader.Read();

			token.Key = readParameterKey(reader);

			if ((read = reader.Read()) != -1 && (char)read == '=')
				token.Value = readParameterValue(reader);

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

				if (character == '=' | character == ' ')
					break;

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

				lastCharacter = character;
			}
			return tokenBuilder.ToString();
		}
	}
}
