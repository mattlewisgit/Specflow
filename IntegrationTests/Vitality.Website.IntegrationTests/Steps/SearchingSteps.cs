using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

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


    [Binding]
    public sealed class SearchingSteps : BaseSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [When(@"I search content (.*)")]
        public void WhenISearchContent(string p0)
        {
            //Clear Search box text
            WebDriver
                .FindElement(By.XPath("//input[@type='text']"))
                .Clear();

            //Send string keys
            WebDriver
                .FindElement(By.XPath("//input[@type='text']"))
                .SendKeys(p0);
        }


        [Then(@"I expect search contents (.*) to be visible")]
        public void ThenIExpectSearchContentsToBeVisible(string p0)
        {
            //Wait for first search result to appear
            //WebDriver
            //    .WaitForElement(By.CssSelector("li.search-results__item.ng-scope > a"))
            //    .Displayed.ShouldBeTrue();

            WebDriver
                .WaitForElement(new JQuerySelector("li.search-results__item.ng-scope" + ":contains('" + p0 + "')"))
                .Displayed.ShouldBeTrue();
        }



        [Then(@"then I click on the (.*) results page")]
        public void ThenThenIClickOnTheResultsPage(string p0)
        {
            //Click on search results
            WebDriver
                .FindElement(new JQuerySelector("li.search-results__item.ng-scope" + ":contains('" + p0 + "')"))
                .Click();
        }


    }
}
