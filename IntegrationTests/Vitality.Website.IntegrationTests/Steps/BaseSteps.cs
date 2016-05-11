namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    using TechTalk.SpecFlow;

    [Binding]
    public class BaseSteps
    {
        public static IWebDriver WebDriver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var ffBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\Firefox.exe");
            var firefoxProfile = new FirefoxProfile();

            WebDriver = new FirefoxDriver(ffBinary, firefoxProfile);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
