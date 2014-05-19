using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libargument
{
	public abstract class Controller : IController
	{
		private const string header = "Help powered by libargument {0}.\n© 2014 by AliveDevil\nhttps://github.com/alivedevil/libargument/\nSkip with /noheader\n";

		public void Help([Abbreviation("h"), Abbreviation("?")] bool help, bool noLogo = false)
		{
			if (!noLogo) PrintHeader();
		}

		public void Help()
		{
			Help(true, false);
		}

		private void PrintHeader()
		{
			Console.Write(header);
		}
	}
}
