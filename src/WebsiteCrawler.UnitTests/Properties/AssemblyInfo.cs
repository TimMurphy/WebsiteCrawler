using System.Reflection;
using Anotar.Custom;
using WebsiteCrawler.Library.Logging;

[assembly: AssemblyTitle("WebsiteCrawler.UnitTests")]
[assembly: AssemblyDescription("Unit tests for all projects in WebsiteCrawler solution.")]
[assembly: LogMinimalMessage]
[assembly: LoggerFactory(typeof(LoggerFactory))]