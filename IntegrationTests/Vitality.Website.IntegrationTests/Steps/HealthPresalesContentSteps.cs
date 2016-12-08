namespace Vitality.Website.IntegrationTests.Steps
{
    using TechTalk.SpecFlow;

    using Xunit;

    [Binding]
    public class HealthPresalesContentSteps : BaseSteps
    {
        [When(@"I click on the (.*) page link")]
        public void WhenIClickOnThePageLink(string linkName)
        {
            WebDriver
            .FindElement(OpenQA.Selenium.By.LinkText(linkName))
            .Click();
        }

        [Then(@"I see the (.*) page")]
        public void ThenISeeThePage(string pageName)
        {
            Assert.StartsWith(pageName, WebDriver.Url);
        }
    }
}
