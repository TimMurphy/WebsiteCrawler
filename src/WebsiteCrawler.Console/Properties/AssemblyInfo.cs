using System.Reflection;
using Anotar.Custom;
using WebsiteCrawler.Library.Logging;

[assembly: AssemblyTitle("WebsiteCrawler")]
[assembly: AssemblyDescription("WebsiteCrawler is a console application that crawls all links found from a starting URL.")]
[assembly: LogMinimalMessage]
[assembly: LoggerFactory(typeof (LoggerFactory))]