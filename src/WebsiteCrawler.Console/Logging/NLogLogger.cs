using System;
using NLog;
using WebsiteCrawler.Library.Logging;

namespace WebsiteCrawler.Console.Logging
{
    internal class NLogLogger : Library.Logging.ILogger
    {
        private readonly Logger _logger;

        internal NLogLogger(Type type)
        {
            _logger = LogManager.GetLogger(type.FullName);
        }

        public bool IsDebugEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInformationEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsWarningEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsErrorEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsFatalEnabled
        {
            get { throw new NotImplementedException(); }
        }

        public void Debug(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Information(string format)
        {
            _logger.Info(format);
        }

        public void Information(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public void Information(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warning(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            _logger.Error(exception, message);
        }

        public void Fatal(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}