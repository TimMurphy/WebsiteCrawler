using System;
using CommandLine;
using CommandLine.Text;

namespace WebsiteCrawler.Console
{
    internal class Options
    {
        internal static Options Parse(string[] args, Action<string> showUsage)
        {
            var options = new Options();

            if (Parser.Default.ParseArguments(args, options))
            {
                return options;
            }

            showUsage(options.GetUsage());
            return null;
        }

        [Option('s', "startUrl", Required = true, HelpText = "The URL to start crawling.")]
        public string StartUrl { get; set; }

        [Option('r', "resultPath", Required = true, HelpText = "The file to write YAML result to.")]
        public string ResultPath { get; set; }

        [Option('w', "waitAfterPageLoad", Required = false, HelpText = "Number of milliseconds to wait after a page is loaded.")]
        public int WaitAfterPageLoad { get; set; }

        private string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }
    }
}
