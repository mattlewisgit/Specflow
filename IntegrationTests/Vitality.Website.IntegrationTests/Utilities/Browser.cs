namespace Vitality.Website.IntegrationTests.Utilities
{
    using System;

    using OpenQA.Selenium;

    using Vitality.Website.IntegrationTests.Steps;

    public static class Browser
    {
        private static IWebDriver WebDriver
        {
            get
            {
                return BaseSteps.WebDriver;
            }
        }

        private static readonly BrowserChainer BrowserChainerInstance = new BrowserChainer();

        public static string CurrentUrl
        {
            get
            {
                return WebDriver.Url;
            }
        }

        public static BrowserChainer GoTo(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
            return BrowserChainerInstance;
        }

        public static BrowserChainer GoTo(this BrowserChainer browserChainer, string url)
        {
            return GoTo(url);
        }

        public static BrowserChainer Resize(int width, int height)
        {
            WebDriver.Manage().Window.Size = new System.Drawing.Size(width, height);
            return BrowserChainerInstance;
        }

        public static BrowserChainer Resize(this BrowserChainer browserChainer, int width, int height)
        {
            return Resize(width, height);
        }

        public static BrowserChainer Maximise()
        {
            WebDriver.Manage().Window.Maximize();
            return BrowserChainerInstance;
        }

        public static BrowserChainer Maximise(this BrowserChainer browserChainer)
        {
            return Maximise();
        }

        public static BrowserChainer Wait(TimeSpan timespan)
        {
            WebDriver.Manage().Timeouts().ImplicitlyWait(timespan);
            return BrowserChainerInstance;
        }

        public static BrowserChainer Wait(this BrowserChainer browserChainer, TimeSpan timespan)
        {
            return Wait(timespan);
        }

        public static string PageSource
        {
            get
            {
                return WebDriver.PageSource;
            }
        }

        public class BrowserChainer { }
    }
}
