namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Drawing;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Extensions;
    using Utilities;
    using OpenQA.Selenium.Interactions;
    using By = OpenQA.Selenium.By;
    using OpenQA.Selenium.Support.UI;
    using System;

    [Binding]
    public sealed class TabbedSteps : BaseSteps
    {
        [When(@"I click on tabbed content tab '(.*)'")]
        public void WhenIClickOnTabbedContentTab(string p0)
        {
            WebDriver
                    .FindElement(By.LinkText(p0))
                    .Click();
        }

        [Then(@"I expect the tabbed content description '(.*)' to appear")]
        public void ThenIExpectTheTabbedContentDescriptionToAppear(string p0)
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(p0 + ".expander__content.is-active"))
                    .Displayed.ShouldBeTrue();
        }

    }
}
