namespace Vitality.Website.IntegrationTests.Steps {     using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;

    [Binding]     public class CommonSteps : BaseSteps     {         [Given(@"I am on the (.*)")]         public void GivenIAmOnTheTable(string p0)         {             WebDriver.Manage().Window.Maximize();             WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityBaseUrl + p0);
            WebDriver.WaitForPageLoad();
        }          [Given(@"I am on advisers (.*)")]
        public void GivenIAmOnAdvisers(string p0)
        {
            WebDriver.Manage().Window.Maximize();             WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityAdvisersUrl + p0);
            WebDriver.WaitForPageLoad();
        }

        [Given(@"I am on presales (.*)")]
        public void GivenIAmOnPresales(string p0)
        {
            WebDriver.Manage().Window.Maximize();             WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityPresalesUrl + p0);
            WebDriver.WaitForPageLoad();
        }     } } 