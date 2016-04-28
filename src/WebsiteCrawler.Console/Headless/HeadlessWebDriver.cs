using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HtmlAgilityPack;
using NullGuard;
using OpenQA.Selenium;

namespace WebsiteCrawler.Console.Headless
{
    // Quick and dirty implementation of only the methods I need.
    public class HeadlessWebDriver : IWebDriver
    {
        private readonly HeadlessNavigation _navigation;

        public HeadlessWebDriver()
        {
            _navigation = new HeadlessNavigation();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            if (by.ToString() != By.TagName("a").ToString())
            {
                throw new NotSupportedException($"by '{by}' is not supported.");
            }

            if (PageSource == null)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }

            var doc = new HtmlDocument();
            doc.LoadHtml(PageSource);

            var aNodes = doc.DocumentNode.SelectNodes("//a");
            var elements =
                from node in aNodes
                where node.HasAttributes
                let href = node.GetAttributeValue("href", null)
                where href != null
                let url = TryMakeAbsoluteUrl(href)
                where url != null
                select (IWebElement)new HeadlessWebElement("href", url);

            return new ReadOnlyCollection<IWebElement>(elements.ToList());
        }

        private string TryMakeAbsoluteUrl(string relativeUrl)
        {
            try
            {
                return new Uri(new Uri(_navigation.Url), relativeUrl).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            // nothing to do
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }

        public IOptions Manage()
        {
            throw new NotImplementedException();
        }

        public INavigation Navigate()
        {
            return _navigation;
        }

        public ITargetLocator SwitchTo()
        {
            throw new NotImplementedException();
        }

        public string Url
        {
            get { return _navigation.Url; }
            set { _navigation.GoToUrl(value); }
        }

        public string Title { get; }

        [AllowNull]
        public string PageSource => _navigation.PageSource;
        public string CurrentWindowHandle { get; }
        public ReadOnlyCollection<string> WindowHandles { get; }
    }
}