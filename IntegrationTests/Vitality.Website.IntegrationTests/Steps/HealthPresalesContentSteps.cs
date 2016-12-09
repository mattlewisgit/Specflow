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
    using OpenQA.Selenium.Interactions;
    [Binding]
    public class HealthPresalesContentSteps : BaseSteps
    {
        private readonly PresalesPage presalesPage;

        public HealthPresalesContentSteps(PresalesPage presalesPage)
        {
            this.presalesPage = presalesPage;
        }

        [When(@"I go to the (.*) feature block")]
        public void WhenIGoToTheFeatureBlock(string featureName)
        {
            
            WebDriver
                .FindElement(new JQuerySelector(".feature-block__content:has(h2:contains('" + featureName + "'))"));
        }


        [When(@"I click on the (.*) page link")]
        public void WhenIClickOnThePageLink(string linkName)
        {
            //this.presalesPage.PageNavigation.ClickPageNavigationLinkByText(WebDriver, p0);
            // TODO We need to add "context" functionality into a currently executing step
            // as then we can move incrementally through the html hierachy using different GWT steps

            IWebElement element =
                 WebDriver
                 .FindElement(new JQuerySelector(".feature-block__content:has(h2:contains('Award-winning cover')) .feature-block__content--body").Next());

            // Scroll to item
            Actions actions = new Actions(WebDriver);
            actions.MoveToElement(element);
            actions.Perform();
            actions.Click();    
          
            //WebDriver
            //.FindElement(OpenQA.Selenium.By.LinkText(linkName))
            //.Click();

        }

        [Then(@"I see the (.*) page")]
        public void ThenISeeThePage(string pageName)
        {
            Assert.StartsWith(pageName, WebDriver.Url);
        }
    }
}
