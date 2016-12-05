namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Drivers;

    [Binding]
    public class BaseSteps
    {
        public static IWebDriver WebDriver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            WebDriver = DriverFactory.Chrome();
            
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
