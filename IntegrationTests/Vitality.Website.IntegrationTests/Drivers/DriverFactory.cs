namespace Vitality.Website.IntegrationTests.Drivers
{
    using System.IO;

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
            var binary = File.Exists(AppSettings.Paths.Firefox)
                ? new FirefoxBinary(AppSettings.Paths.Firefox)
                : new FirefoxBinary(AppSettings.Paths.Firefox64);
            return new FirefoxDriver(binary, new FirefoxProfile());

            //This is for Marionette
            /*var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;

            var driver = new FirefoxDriver(driverService, new FirefoxOptions(), System.TimeSpan.FromSeconds(60)); */
        }

        public static IWebDriver Chrome()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("chrome.binary", AppSettings.Paths.Chrome);
            options.AddArguments("start-maximized");
            return new ChromeDriver(options);
        }
    }
}
