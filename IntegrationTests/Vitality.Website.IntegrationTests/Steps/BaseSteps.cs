namespace Vitality.Website.IntegrationTests.Steps
{
    using System;
    using Drivers;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public class BaseSteps
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public static IWebDriver WebDriver;

        [BeforeScenario]
        public static void BeforeTestRun()
        {
            IWebDriverExtensions.DefaultWaitTimeSpan = new TimeSpan(0, 2, 0);
            WebDriver = DriverFactory.Chrome();

            // Need to set these after as there are no options for Chrome.
            WebDriver
                .Manage()
                .Timeouts()
                .SetPageLoadTimeout(IWebDriverExtensions.DefaultWaitTimeSpan)
                .SetScriptTimeout(IWebDriverExtensions.DefaultWaitTimeSpan)
                .ImplicitlyWait(IWebDriverExtensions.DefaultWaitTimeSpan);
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            WebDriver.Quit();
        }
    }
}
