namespace Vitality.Website.IntegrationTests.Drivers
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;
    using Extensions;

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
            var options = new ChromeOptions();

           
            options.AddArguments("--start-maximized");
            options.AddArguments("--enable-automation");
          //  options.AddArguments("--disable-extensions-except");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);

            return new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, IWebDriverExtensions.DefaultWaitTimeSpan);
        }
    }
}
