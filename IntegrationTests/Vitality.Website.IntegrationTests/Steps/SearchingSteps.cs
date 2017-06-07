namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class SearchingSteps : BaseSteps
    {
        [When(@"I search content (.*)")]
        public void WhenISearchContent(string p0)
        {
            // Clear search box text.
            WebDriver
                .FindElement(By.XPath("//input[@type='text']"))
                .Clear();

            // Send string keys.
            WebDriver
                .FindElement(By.XPath("//input[@type='text']"))
                .SendKeys(p0);
        }

        [Then(@"I expect search contents (.*) to be visible")]
        public void ThenIExpectSearchContentsToBeVisible(string text)
        {
            WebDriver
                .WaitForElement(new JQuerySelector
                    ("li.search-results__item.ng-scope" + ":contains('" + text + "')"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"then I click on the (.*) results page")]
        public void ThenThenIClickOnTheResultsPage(string text)
        {
            // Click on search results.
            WebDriver
                .FindElement(new JQuerySelector
                    ("li.search-results__item.ng-scope" + ":contains('" + text + "')"))
                .Click();
        }
    }
}
