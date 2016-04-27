using System;

namespace WebsiteCrawler.Library.Logging
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsInformationEnabled { get; }
        bool IsWarningEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        void Debug(string format, params object[] args);
        void Debug(Exception exception, string format, params object[] args);
        void Information(string format);
        void Information(string format, params object[] args);
        void Information(Exception exception, string format, params object[] args);
        void Warning(string format, params object[] args);
        void Warning(Exception exception, string format, params object[] args);
        void Error(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
        void Fatal(string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);
    }
}