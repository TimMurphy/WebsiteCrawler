using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace WebsiteCrawler.Console.Headless
{
    public class HeadlessWebElement : IWebElement
    {
        private readonly string _value;

        public HeadlessWebElement(string attributeName, string value)
        {
            if (attributeName != "href")
            {
                throw new NotSupportedException($"attributeName '{attributeName}' is not supported.");
            }
            _value = value;
        }

        public IWebElement FindElement(By @by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            if (attributeName != "href")
            {
                throw new NotSupportedException($"attributeName '{attributeName}' is not supported.");
            }
            return _value;
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed { get; }
    }
}