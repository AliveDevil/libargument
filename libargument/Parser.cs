using libargument.Exceptions;
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
		private string arguments;
		private T controller;
		private Type targetType;
		private List<Token> tokenList;

		/// Parser()
		/// <summary>
		/// Creates an Parser-object with Environment.CommandLine as argument.
		/// </summary>
		public Parser()
			: this(Environment.CommandLine)
		{
		}

		/// Parser(string)
		/// <summary>
		/// Constructor for copying getting custom arguments.
		/// </summary>
		public Parser(string arguments)
		{
			this.targetType = typeof(T);
			this.controller = Activator.CreateInstance<T>();
			this.arguments = arguments;
		}

		/// Match()
		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public void Match()
		{
			// prepare for bad code. Will be improved over time.

			// forward declaration.
			// don't know why I do this .. maybe OCD.
			var methodInfos = default(List<Method>);

			buildMethodInfo(ref methodInfos);
			strikeMethods(tokenList, ref methodInfos);

			if (methodInfos.Count == 0)
				throw new ActionNotFoundException();
			if (methodInfos.Count > 1)
				throw new EquivocalActionsException();

			var selectedMethod = methodInfos[0];

			//var selectedMethod = lookup.Single();
			//var objectSelect = selectedMethod.Parameter.Select(item => new
			//{
			//	Value = item.DefaultValue,
			//	Type = item.Type,
			//	TypeConverter = controller.ResolveType(item.Type),
			//	Optional = item.IsOptional,
			//});

			// do mapping
		}

		/// Tokenize()
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

		/// buildMethodInfo()
		/// <summary>
		///
		/// </summary>
		private void buildMethodInfo(ref List<Method> methods)
		{
			methods = targetType
				.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(method => method.ReturnType == typeof(void) & method.IsParse())
				.Select(method => new Method(method))
				.ToList();
		}

		/// interpreteCharacterValue(char, char, bool, bool, bool, bool)
		/// <summary>
		///
		/// </summary>
		/// <param name="character"></param>
		/// <param name="lastCharacter"></param>
		/// <param name="inQuote"></param>
		/// <param name="nextEscape"></param>
		/// <returns></returns>
		private void interpreteCharacterValue(
			char character,
			char lastCharacter,
			ref bool inQuote,
			ref bool nextEscape,
			out bool append,
			out bool quit)
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
			append = !(
						(character == '"' & !nextEscape) |
						(character == '\\' & !nextEscape) |
						(character == ' ' & !(nextEscape | inQuote))
					);

			//	quit if
			//		character is "
			//			and inQuote and not nextEscape
			//		character is ' '
			//			and not
			//				inQuote
			//				or nextEscape
			quit = (character == '"' & inQuote & !nextEscape) |
				(character == ' ' & !(nextEscape | inQuote));

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

		/// strikeMethod(List[Token], List[Method])
		/// <summary>
		///
		/// </summary>
		/// <param name="tokens"></param>
		/// <param name="methods"></param>
		/// <returns></returns>
		private void strikeMethods(List<Token> tokens, ref List<Method> methods)
		{
			foreach (var token in tokens)
			{
				for (int i = methods.Count - 1; i >= 0; i--)
				{
					if (!methods[i].Parameter.HasKey(token))
						methods.RemoveAt(i);
				}
			}
		}
	}
}
