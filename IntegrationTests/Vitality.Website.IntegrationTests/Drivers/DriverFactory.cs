namespace Kingfisher.Website.IntegrationTests.Drivers
{
    using Extensions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;

    public static class DriverFactory
    {
        public static IWebDriver PhantonJs()
        {
            var service = PhantomJSDriverService.CreateDefaultService(AppSettings.Paths.PhantomJS);
            return new PhantomJSDriver(service);
        }

        public static IWebDriver Firefox()
        {
            return new FirefoxDriver();
        }

        public static IWebDriver Chrome()
        {
            var options = new ChromeOptions()
                .EnableAutomation()
                .StartMaximised();

            options.SetLoggingPreference(LogType.Browser, LogLevel.All);

            return new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, IWebDriverExtensions.DefaultWaitTimeSpan);
        }
    }
}
