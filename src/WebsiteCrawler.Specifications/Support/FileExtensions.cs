using System;
using System.IO;
using EmptyStringGuard;
using Newtonsoft.Json.Linq;
using NullGuard;

namespace WebsiteCrawler.Specifications.Support
{
    internal static class FileExtensions
    {
        internal static void DeleteTempFile([AllowNull, AllowEmpty] this string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                File.Delete(path);
            }
        }

        internal static bool Exists(this string path)
        {
            return File.Exists(path);
        }

        internal static string GetTempFullName(string extension)
        {
            var fileName = string.Format("WebsiteCrawler.Specifications.{0}.{1}", Guid.NewGuid(), extension.Trim('.'));

            return Path.Combine(Path.GetTempPath(), fileName);
        }

        internal static JObject ReadJsonDocument(this string path)
        {
            var json = File.ReadAllText(path);
            var jobject = JObject.Parse(json);

            return jobject;
        }
    }
}