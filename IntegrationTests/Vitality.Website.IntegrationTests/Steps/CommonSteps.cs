namespace Vitality.Website.IntegrationTests.Steps {     using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;

    [Binding]     public class CommonSteps : BaseSteps     {         [Given(@"I am on the (.*)")]         public void GivenIAmOnTheTable(string p0)         {             WebDriver.Manage().Window.Maximize();             WebDriver.Navigate().GoToUrl(AppSettings.Links.VitalityBaseUrl + p0);
            WebDriver.WaitForPageLoad();
        }     } } 