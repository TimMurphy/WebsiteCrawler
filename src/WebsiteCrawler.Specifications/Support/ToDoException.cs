using System;
using System.Diagnostics;
using System.Linq;

namespace WebsiteCrawler.Specifications.Support
{
    internal class ToDoException : Exception
    {
        public ToDoException(int skipFrames = 0)
            : base(GetMessage(skipFrames))
        {
        }

        private static string GetMessage(int skipFrames)
        {
            var frame = new StackFrame(skipFrames + 2);
            var method = frame.GetMethod();

            // ReSharper disable once PossibleNullReferenceException
            return string.Format("{0}.{1}({2})", method.DeclaringType.Name, method.Name, string.Join(", ", method.GetParameters().Select(p => p.Name)));
        }
    }
}