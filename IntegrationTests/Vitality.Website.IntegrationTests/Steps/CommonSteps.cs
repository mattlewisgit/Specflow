namespace Vitality.Website.IntegrationTests.Steps {     using TechTalk.SpecFlow;     using Vitality.Extensions.Selenium; 
    [Binding]     public class CommonSteps : BaseSteps     {         [Given(@"I am on the (.*)")]         public void GivenIAmOnTheTable(string link)         {             WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityBaseUrl + link);
            WebDriver.WaitForPageLoad();
        }          [Given(@"I am on advisers (.*)")]
        public void GivenIAmOnAdvisers(string link)
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityAdvisersUrl + link);
            WebDriver.WaitForPageLoad();
        }

        [Given(@"I am on production advisers (.*)")]
        public void GivenIAmOnProductionAdvisers(string link)
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityAdvisersProductionUrl + link);
            WebDriver.WaitForPageLoad();
        }

        [Given(@"I am on presales (.*)")]
        public void GivenIAmOnPresales(string link)
        {             WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityPresalesUrl + link);
            WebDriver.WaitForPageLoad();
        }

        [Given(@"I am on production presales (.*)")]
        public void GivenIAmOnProductionPresales(string link)
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityPresalesProductionUrl + link);
            WebDriver.WaitForPageLoad();
        }
    } } 