namespace Vitality.Website.IntegrationTests.Utilities
{
    using System;

    using OpenQA.Selenium;

    using Vitality.Website.IntegrationTests.Steps;

    public static class Browser
    {
        private static IWebDriver webDriver
        {
            get
            {
                return BaseSteps.WebDriver;
            }
        }

        private static readonly BrowserChainer browserChainerInstance = new BrowserChainer();

        public static string CurrentUrl
        {
            get
            {
                return webDriver.Url;
            }
        }

        public static BrowserChainer GoTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            return browserChainerInstance;
        }

        public static BrowserChainer GoTo(this BrowserChainer browserChainer, string url)
        {
            return Browser.GoTo(url);
        }

        public static BrowserChainer Resize(int width, int height)
        {
            webDriver.Manage().Window.Size = new System.Drawing.Size(width, height);
            return browserChainerInstance;
        }
        
        public static BrowserChainer Resize(this BrowserChainer browserChainer, int width, int height)
        {
            return Browser.Resize(width, height);
        }

        public static BrowserChainer Maximise()
        {
            webDriver.Manage().Window.Maximize();
            return browserChainerInstance;
        }

        public static BrowserChainer Maximise(this BrowserChainer browserChainer)
        {
            return Browser.Maximise();
        }

        public static BrowserChainer Wait(TimeSpan timespan)
        {
            webDriver.Manage().Timeouts().ImplicitlyWait(timespan);
            return browserChainerInstance;
        }

        public static BrowserChainer Wait(this BrowserChainer browserChainer, TimeSpan timespan)
        {
            return Browser.Wait(timespan);
        }

        public static string PageSource
        {
            get
            {
                return webDriver.PageSource;
            }
        }
        public class BrowserChainer
        {

        }
    }
}
