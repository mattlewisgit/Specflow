namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class TabbedSteps : BaseSteps
    {
        [When(@"I click on tabbed content tab '(.*)'")]
        public void WhenIClickOnTabbedContentTab(string tabName)
        {
            WebDriver
                .FindElement(By.LinkText(tabName))
                .Click();
        }

        [Then(@"I expect the tabbed content description '(.*)' to appear")]
        public void ThenIExpectTheTabbedContentDescriptionToAppear(string tabName)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(tabName + ".expander__content.is-active"))
                .Displayed.ShouldBeTrue();
        }
    }
}
