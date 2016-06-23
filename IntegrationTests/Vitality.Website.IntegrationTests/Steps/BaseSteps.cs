namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support;
    using OpenQA.Selenium.Remote;

    using TechTalk.SpecFlow;
    using System.Collections.Generic;
    [Binding]
    public class BaseSteps
    {
  
        public static IWebDriver WebDriver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //var ffBinary = new FirefoxBinary(AppSettings.Paths.Firefox);
            //var firefoxProfile = new FirefoxProfile();

            //WebDriver = new FirefoxDriver(ffBinary, firefoxProfile);

            //This is for Marionette
            /*var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;

            var driver = new FirefoxDriver(driverService, new FirefoxOptions(), System.TimeSpan.FromSeconds(60)); */

            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("chrome.binary", AppSettings.Paths.Chrome );
            options.AddArguments("start-maximized");
            
            WebDriver = new ChromeDriver(options);


        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
