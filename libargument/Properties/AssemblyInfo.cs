using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("libargument")]
[assembly: AssemblyDescription("Simple library for parsing command line arguments.")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#elif NET35
[assembly: AssemblyConfiguration("Release NET35")]
#elif NET40
[assembly: AssemblyConfiguration("Release NET40")]
#else
[assembly: AssemblyConfiguration("")]
#endif
[assembly: AssemblyCompany("AliveDevil")]
[assembly: AssemblyProduct("libargument")]
[assembly: AssemblyCopyright("© 2014 AliveDevil")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("0.1.0.59")]
[assembly: AssemblyFileVersion("0.1.0.59")]
[assembly: AssemblyInformationalVersion("v0.1.0-pre")]
[assembly: Guid("b29fc4ca-cf38-45c9-8ab3-4969a3f5cb17")]
