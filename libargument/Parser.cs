﻿using libargument.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace libargument
{
	/// <summary>
	/// Provides access to <see cref="M:Tokenize()"/> and <see cref="M:Match()"/>. Executes matching methods in given <see cref="T:libargument.IController"/>.
	/// </summary>
	/// <typeparam name="T">Some type of <seealso cref="T:libargument.IController"/></typeparam>
	public sealed partial class Parser<T> where T : IController, new()
	{
		private string arguments;
		private T controller;
		private Type targetType;
		private List<Token> tokenList;

		/// Parser(string)
		/// <summary>
		/// Constructor with specified arguments.
		/// </summary>
		/// <param name="arguments">Arguments for this instance.</param>
		public Parser(string arguments)
		{
			this.targetType = typeof(T);
			this.controller = new T();
			this.arguments = arguments;
		}

		/// Match()
		/// <summary>
		/// Executes <seealso cref="M:Match&lt;TOut&gt;()" /> without returning anything.
		/// </summary>
		public void Match()
		{
			// does anyone has an idea how to get Visual Studio to accept libargument.Parser<T>.Match<TOut>() ?
			Match<object>();
		}

		/// Match(TOut)
		/// <summary>
		/// Checks every method in current controller and executes best matching method.
		/// This method tries to return correct type or throws an InvalidCastException.
		/// </summary>
		/// <remarks>Tokenize() has to be called before!</remarks>
		/// <typeparam name="TOut">Return type</typeparam>
		/// <returns>Invoked action return object.</returns>
		/// <exception cref="System.InvalidCastException">Thrown if target type does not match returned type.</exception>
		public TOut Match<TOut>()
		{
			// strike every token which is available as field.
			applyOptions(tokenList);

			// forward declaration.
			// don't know why I do this .. maybe OCD.
			var methodInfos = default(List<Method>);

			applyParameters(tokenList, ref methodInfos);

			if (!controller.SkipUnresolvedArguments && tokenList.Count > 0)
				throw new NotResolvedException();

			strikeMethods(ref methodInfos);

			if (methodInfos.Count == 0)
				throw new ActionNotFoundException();
			if (methodInfos.Count > 1)
				throw new EquivocalActionsException();

			var selectedMethod = methodInfos.First();
			var objectParameter = new List<object>();

			foreach (var item in selectedMethod.Parameter)
			{
				var converter = controller.ResolveType(item.Type);
				objectParameter.Add(Assembling.Resolve(converter, item));
			}

			try
			{
				var retVal = selectedMethod.MethodInfo.Invoke(controller, objectParameter.ToArray());
				if (retVal == null)
					return default(TOut);
				if (retVal is TOut)
					return (TOut)retVal;
				throw new InvalidCastException();
			}
			catch (TargetInvocationException targetException)
			{
				throw targetException.InnerException;
			}
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
			var chars = Encoding.Default.GetBytes(arguments);
			using (var memory = new MemoryStream(chars, false))
			using (var reader = new StreamReader(memory))
				while (reader.Peek() != -1)
					tokenList.Add(readParameter(reader));
		}

		/// applyOptions(List[Token])
		/// <summary>
		///
		/// </summary>
		private void applyOptions(List<Token> tokens)
		{
			var fields = targetType
				.GetFields(BindingFlags.Public | BindingFlags.Instance)
				.Where(field => field.IsOption())
				.Select(field => new Field(field))
				.ToList();

			for (int i = tokens.Count - 1; i >= 0; i--)
			{
				bool known = false;
				foreach (var field in fields)
					known |= field.IsKnown(tokens[i]);
				if (known)
					tokens.RemoveAt(i);
			}

			fields = fields.Where(field => field.Token.Count > 0).ToList();

			if (fields.Any(field => field.Token.Count > 1))
				throw new DuplicateKeyException();

			foreach (var field in fields)
			{
				var converter = controller.ResolveType(field.Type);
				field.Info.SetValue(controller, Assembling.Resolve(converter, field));
			}
		}


		/// applyParameters(List[Token])
		/// <summary>
		/// 
		/// </summary>
		/// <param name="tokens"></param>
		/// <param name="methods"></param>
		private void applyParameters(List<Token> tokens, ref List<Method> methods)
		{
			methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
					.Where(method => method.IsParse())
					.Select(method => new Method(method))
					.ToList();

			for (int i = tokens.Count - 1; i >= 0; i--)
			{
				bool known = false;
				foreach (var method in methods)
					known |= method.Parameter.HasKey(tokens[i]);
				if (known)
					tokens.RemoveAt(i);
			}

			if (methods.Any(method => method.Parameter.Any(parameter => parameter.Token.Count > 1 & !parameter.IsArray)))
				throw new DuplicateKeyException();
		}

		/// interpreteCharacterValue(char, char, bool, bool, bool, bool)
		/// <summary>
		///
		/// </summary>
		/// <param name="character"></param>
		/// <param name="lastCharacter"></param>
		/// <param name="inQuote"></param>
		/// <param name="nextEscape"></param>
		/// <param name="append"></param>
		/// <param name="quit"></param>
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

			// skip any leading non '/' character
			while ((read = reader.Peek()) != -1 && (char)read != '/')
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

			// reads first char and returns if it is no valid option
			// may be throw an exception?
			if ((read = reader.Read()) != -1 && (char)read != '/')
				return "";

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

			while (!quit && (read = reader.Read()) != -1)
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
		/// <param name="methods"></param>
		/// <returns></returns>
		private void strikeMethods(ref List<Method> methods)
		{
			methods = methods.Where(method => method.Parameter.All(parameter => parameter.Token.Count > 0 | parameter.IsOptional)).ToList();
		}
	}
}
