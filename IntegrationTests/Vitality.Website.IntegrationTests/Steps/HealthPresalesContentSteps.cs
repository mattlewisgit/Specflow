namespace Vitality.Website.IntegrationTests.Steps
{
    using System;

    using Selenium.WebDriver.Extensions.JQuery;

    using Shouldly;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;
    using Vitality.Website.IntegrationTests.PageObjects;
    using Vitality.Website.IntegrationTests.Utilities;
    using OpenQA.Selenium;
    using System.Linq;
    using Xunit;
    [Binding]
    public class HealthPresalesContentSteps : BaseSteps
    {
        private readonly PresalesPage presalesPage;

        public HealthPresalesContentSteps(PresalesPage presalesPage)
        {
            this.presalesPage = presalesPage;
        }

        [When(@"I click on the (.*) page link")]
        public void WhenIClickOnThePageLink(string linkName)
        {
            //this.presalesPage.PageNavigation.ClickPageNavigationLinkByText(WebDriver, p0);

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
