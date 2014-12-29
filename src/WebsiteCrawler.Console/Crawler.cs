using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private TimeSpan _waitAfterPageLoad;

        public string Crawl(string startUrl, TimeSpan waitAfterPageLoad)
        {
            LogTo.Debug("Crawl(startUrl: {0})", startUrl);

            _startUri = new Uri(startUrl);
            _waitAfterPageLoad = waitAfterPageLoad;
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
            var internalUrls = newUrls.Where(IsInternalUrl).Where(u => !ExcludeUrl(u)).ToArray();

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            //
            // Loop cannot be converted to query because ProcessLinks(IReadOnlyCollection<IWebElement> links) is
            // called recursively and therefore _internalUrls may have been updated since newUrls was generated.
            foreach (var internalUrl in internalUrls)
            {
                if (_internalUrls.Add(internalUrl))
                {
                    ReadUrl(internalUrl);
                }
            }
        }

        private bool ExcludeUrl(string url)
        {
            // hack
            //
            // Urls with # represent navigation to bookmark o page or navigation via a JavaScript call.
            // Excluding these urls seemed to help with any issues while crawling www.croquetscores.com.
            return url.Contains("#");
        }

        private IReadOnlyCollection<IWebElement> GetLinks()
        {
            LogTo.Information("Searching for links on '{0}'...", _webDriver.Url);
            var links = _webDriver.FindElements(By.TagName("a"));
            return links;
        }

        private void NavigateTo(string url)
        {
            LogTo.Information("Navigating to '{0}'...", url);
            _webDriver.Navigate().GoToUrl(url);

            // hack: IWebDriver waits for page to load but I found while crawling www.croquetscores.com adding 
            // some wait time helped.
            Thread.Sleep(_waitAfterPageLoad);
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