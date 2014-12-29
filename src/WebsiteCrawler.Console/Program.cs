using System;
using System.IO;
using Anotar.Custom;
using WebsiteCrawler.Console.Logging;
using WebsiteCrawler.Library.Logging;

namespace WebsiteCrawler.Console
{
    public class Program
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once NotAccessedField.Local
        static ILogger AnotarLogger = LoggerFactory.GetLogger<Program>();

        public enum ExitCodes
        {
            OK,
            Exception,
            UsageError
        };

        public static int Main(string[] args)
        {
            try
            {
                LoggerFactory.Logger = t => new NLogLogger(t);
                AnotarLogger = LoggerFactory.GetLogger<Program>();

                var options = Options.Parse(args, usage => LogTo.Information(usage));

                if (options == null)
                {
                    return (int) ExitCodes.UsageError;
                }

                var crawler = new Crawler();
                var result = crawler.Crawl(options.StartUrl, TimeSpan.FromMilliseconds(options.WaitAfterPageLoad));

                File.WriteAllText(options.ResultPath, result);

                return (int) ExitCodes.OK;
            }
            catch (Exception ex)
            {
                LogTo.Error(ex, ex.Message);
                return (int) ExitCodes.Exception;
            }
        }
    }
}