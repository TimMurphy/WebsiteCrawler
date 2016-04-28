using System;
using System.Net;
using System.Net.Http;
using Anotar.Custom;
using NullGuard;
using OpenQA.Selenium;

namespace WebsiteCrawler.Console.Headless
{
    public class HeadlessNavigation : INavigation
    {
        private HttpStatusCode _lastStatusCode;
        private Uri _uri;

        public string Url => _uri.ToString();

        [AllowNull]
        public string PageSource { get; private set; }

        public void Back()
        {
            throw new NotImplementedException();
        }

        public void Forward()
        {
            throw new NotImplementedException();
        }

        public void GoToUrl(string url)
        {
            GoToUrl(new Uri(url));
        }

        public void GoToUrl(Uri uri)
        {
            _uri = uri;
            PageSource = ReadPageSource();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        private string ReadPageSource()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _uri;

                // New code:
                var response = client.GetAsync("").Result;

                _lastStatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                LogTo.Error($"Uri '{_uri}' returned failed status code '{response.StatusCode}'.");
                return null;
            }
        }
    }
}