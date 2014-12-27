using System;

namespace WebsiteCrawler.Library.Logging
{
    public class NoOpLogger : ILogger
    {
        public bool IsDebugEnabled
        {
            get { return false; }
        }

        public bool IsInformationEnabled
        {
            get { return false; }
        }

        public bool IsWarningEnabled
        {
            get { return false; }
        }

        public bool IsErrorEnabled
        {
            get { return false; }
        }

        public bool IsFatalEnabled
        {
            get { return false; }
        }

        public void Debug(string format, params object[] args)
        {
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
        }

        public void Information(string format, params object[] args)
        {
        }

        public void Information(Exception exception, string format, params object[] args)
        {
        }

        public void Warning(string format, params object[] args)
        {
        }

        public void Warning(Exception exception, string format, params object[] args)
        {
        }

        public void Error(string format, params object[] args)
        {
        }

        public void Error(Exception exception, string format, params object[] args)
        {
        }

        public void Fatal(string format, params object[] args)
        {
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
        }
    }
}