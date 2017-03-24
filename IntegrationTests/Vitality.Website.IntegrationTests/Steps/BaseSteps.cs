namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Drivers;

    [Binding]
    public class BaseSteps
    {
        public static IWebDriver WebDriver;

        [BeforeScenario]
        public static void BeforeTestRun()
        {
            WebDriver = DriverFactory.Chrome();
            
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
