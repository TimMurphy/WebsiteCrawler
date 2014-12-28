using System;
using System.Collections.Generic;
using System.Linq;
using Anotar.Custom;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebsiteCrawler.Console
{
    public class Crawler
    {
        private HashSet<string> _internalUrls;
        private IWebDriver _webDriver;
        private Uri _startUri;

        public string Crawl(string startUrl)
        {
            LogTo.Debug("Crawl(startUrl: {0})", startUrl);

            _startUri = new Uri(startUrl);
            _internalUrls = new HashSet<string>();

            LogTo.Information("Opening initial page '{0}'...", startUrl);
            _webDriver = new FirefoxDriver();

            try
            {
                ReadUrl(startUrl);

                var result = new { InternalLinks = _internalUrls };
                var json = JsonConvert.SerializeObject(result);

                return json;
            }
            finally
            {
                _webDriver.Close();
            }
        }

        private void ReadUrl(string url)
        {
            NavigateTo(url);

            var links = GetLinks();

            ProcessLinks(links);
        }

        private void ProcessLinks(IReadOnlyCollection<IWebElement> links)
        {
            LogTo.Information("Processing {0:N0} links on '{1}'...", links.Count, _webDriver.Url);

            var newUrls = links.Select(n => n.GetAttribute("href")).Where(IsNewUrl).ToArray();
            var internalUrls = newUrls.Where(IsInternalUrl).ToArray();

            _internalUrls = new HashSet<string>(_internalUrls.Concat(internalUrls));

            foreach (var internalUrl in internalUrls)
            {
                ReadUrl(internalUrl);
            }
        }

        private IReadOnlyCollection<IWebElement> GetLinks()
        {
            LogTo.Information("Searching for links on '{0}'...", _webDriver.Url);
            var links = _webDriver.FindElements(By.TagName("a"));
            return links;
        }

        private void NavigateTo(string url)
        {
            LogTo.Information("Navigating to '{0}'...", _webDriver.Url);
            _webDriver.Navigate().GoToUrl(url);
        }

        private bool IsNewUrl(string url)
        {
            return !_internalUrls.Contains(url);
        }

        private bool IsInternalUrl(string url)
        {
            var result = _startUri.IsBaseOf(new Uri(url));

            LogTo.Debug("IsInternalUrl(url: {0}) => {1}", url, result);

            return result;
        }
    }
}