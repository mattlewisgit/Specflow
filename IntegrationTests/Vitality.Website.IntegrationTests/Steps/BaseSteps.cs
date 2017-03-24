namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using Extensions;
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

            // Need to set these after as there are no options for Chrome.
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(IWebDriverExtensions.DefaultWaitTimeSpan);
            WebDriver.Manage().Timeouts().SetScriptTimeout(IWebDriverExtensions.DefaultWaitTimeSpan);
            WebDriver.Manage().Timeouts().ImplicitlyWait(IWebDriverExtensions.DefaultWaitTimeSpan);

        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
