using System;

namespace WebsiteCrawler.Library.Logging
{
    public static class LoggerFactory
    {
        static LoggerFactory()
        {
            Logger = t => new NoOpLogger();
        }

        public static Func<Type, ILogger> Logger { get; set; }

        public static ILogger GetLogger<T>()
        {
            return Logger(typeof (T));
        }
    }
}