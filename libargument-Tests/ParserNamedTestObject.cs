using libargument;
using libargument.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libargument_Tests
{
	[ApplicationName("Tests")]
	public sealed class ParserNamedTestObject : Controller
	{
		[Parse]
		public string Name([Key("name")] Switch name)
		{
			return Name();
		}
	}
}
