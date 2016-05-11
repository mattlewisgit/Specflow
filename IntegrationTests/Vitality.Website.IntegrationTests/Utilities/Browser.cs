namespace Vitality.Website.IntegrationTests.Utilities
{
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

        public static void GoTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static string CurrentUrl
        {
            get
            {
                return webDriver.Url;
            }
        }

        public static void Resize(int width, int height)
        {
            webDriver.Manage().Window.Size = new System.Drawing.Size(width, height);
        }
    }
}
