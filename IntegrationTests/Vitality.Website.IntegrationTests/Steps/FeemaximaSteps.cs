namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Linq;
    using System.Threading;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class FeemaximaSteps : BaseSteps
    {
        [When(@"I search for feemaxima (.*) data")]
        public void WhenISearchForFeemaximaData(string search)
        {
            WebDriver
                .FindElement(new JQuerySelector(".tt-input"))
                .Clear();

            WebDriver
                .FindElement(new JQuerySelector(".tt-input"))
                .SendKeys(search);

            Thread.Sleep(1000);

            WebDriver
                .FindElement(new JQuerySelector("strong.tt-highlight:contains('" + search + "')"))
                .Click();
        }

        [Then(@"I expect the feemaxima table to contain (.*) search results")]
        public void ThenIExpectTheFeemaximaTableToContainSearchResults(string search)
        {
            WebDriver
                .FindElement(new JQuerySelector("tr.ng-scope:contains('" + search + "')"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I click on the feemaxima (.*) button")]
        public void ThenIClickOnTheFeemaximaButton(string backButton)
        {
            WebDriver
                .FindElement(By.LinkText(backButton))
                .Click();
        }

        [Then(@"I expect the feemaxima home table to be displayed")]
        public void ThenIExpectTheFeemaximaHomeTableToBeDisplayed()
        {
            WebDriver
                .FindElement(new JQuerySelector("div.ng-scope"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I click on feemaxima (.*) and select on subcolumn (.*)")]
        public void WhenIClickOnFeemaximaAndSelectOnSubcolumn(string column, string subColumn)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(".expanding-list.js-expander-is-accordion.expander--init.expander--collapsible"))
                .Displayed
                .ShouldBeTrue();

            // If chapter or name contains column, then click on it.
            if (WebDriver.FindElements(new JQuerySelector("div.grid-col-2-12.chapter.ng-binding:contains('" + column + "')")).Any())
            {
                WebDriver
                .FindElement(new JQuerySelector("div.grid-col-2-12.chapter.ng-binding:contains('" + column + "')"))
                .Click();
            }
            else if (WebDriver.FindElements(new JQuerySelector("div.grid-col-10-12.name.ng-binding:contains('" + column + "')")).Any())
            {
                WebDriver
                .FindElement(new JQuerySelector("div.grid-col-10-12.name.ng-binding:contains('" + column + "')"))
                .Click();
            }

            // If subchapter or subname contains string subColumn, then click on it.
            if (WebDriver.FindElements(new JQuerySelector("div.grid-col-2-12.subchapter.ng-binding:contains('" + subColumn + "')")).Any())
            {
                WebDriver
                .FindElement(new JQuerySelector
                    ("div.grid-col-2-12.subchapter.ng-binding:contains('" + subColumn + "')"))
                .Click();
            }
            else if (WebDriver.FindElements(new JQuerySelector("div.grid-col-8-12.name.ng-binding:contains('" + subColumn + "')")).Any())
            {
                WebDriver
                .FindElement(new JQuerySelector
                    ("div.grid-col-8-12.name.ng-binding:contains('" + subColumn + "')"))
                .Click();
            }
        }
    }
}
