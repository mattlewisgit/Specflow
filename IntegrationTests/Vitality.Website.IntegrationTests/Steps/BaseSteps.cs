namespace Kingfisher.Website.IntegrationTests.Steps
{
    using System;
    using Drivers;
    using Extensions;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    [Binding]
    public class BaseSteps
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public static IWebDriver WebDriver;

        [BeforeScenario]
        public static void BeforeTestRun()
        {
            IWebDriverExtensions.DefaultWaitTimeSpan = new TimeSpan(0, 0, 30);
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
