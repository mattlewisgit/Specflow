using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TechTalk.SpecFlow;
using Selenium.WebDriver.Extensions.JQuery;
using Vitality.Extensions.Selenium;
using Vitality.Website.IntegrationTests.Extensions;
using System;
using Xunit;
using OpenQA.Selenium;
using System.Threading;
using System.Text.RegularExpressions;

namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public class QuoteResultsSteps : BaseSteps
    {
        private class QuoteModel
        {
            public string OptionRow { get; set; }
            public string Selection { get; set; }

        }


        [Given(@"I see the Quote Results page feed load has completed")]
        public void ISeeTheQuoteResultsPageFeedLoadHasCompleted()
        {
            WebDriver
                .WaitForAngular();
        }


        [When(@"I Edit the (.*) to (.*)")]
        public void IEditTheQuoteTo(string fieldName, string updatedOption)
        {
            // Store these choices in case we want to validate them in following steps
            ScenarioContext.Current.Set<QuoteModel>(new QuoteModel
            {
                OptionRow = fieldName,
                Selection = updatedOption
            });


            var section = WebDriver
                .FindElement(new JQuerySelector($"quote-result .comparison-table .comparison-table--label:has(.comparison-table--label__text:contains('{fieldName}'))"));

            section.
                FindElement(new JQuerySelector($"button"))
                .Click();

            section
                .FindElements(new JQuerySelector("option"))
                .FirstOrDefault(e => e.Text.Equals(updatedOption))
                .Click();

        }

        [Then(@"I see the price of the (.*) offering change to (.*)")]
        public void ISeeThePriceOfTheOfferingChangeTo(string offering, string price)
        {

            WebDriver
                .FindElement(new JQuerySelector($"quote-result .comparison-table th:contains('{offering}') b:contains('{price}')"));

        }


        [Then(@"I see this reflected across all the offerings")]
        public void ISeeThisReflectedAcrossAllTheOfferings()
        {

            var quoteModel = ScenarioContext.Current.Get<QuoteModel>();

            WebDriver
            .FindElements(new JQuerySelector($"quote-result .comparison-table tr:has(.comparison-table--label__text:contains('{quoteModel.OptionRow}')) benefit-option b"))
                .All(e => e.Text.Equals(quoteModel.Selection));

        }

        [When(@"I look at the options available within the (.*) dropdown")]
        public void ILookAtTheOptionsAvailableWithinTheDropdown(string fieldName)
        {
            var section = WebDriver
                .FindElement(new JQuerySelector($"quote-result .comparison-table .comparison-table--label:has(.comparison-table--label__text:contains('{fieldName}'))"));

            section.
                FindElement(new JQuerySelector("button"))
                .Click();

            var possibleOptions = section
                .FindElements(new JQuerySelector("option"));

            ScenarioContext.Current.Add("Options", possibleOptions.Select(e => e.Text));
        }

        [Then(@"I see the following options")]
        public void ThenISeeTheFollowingOptions(Table table)
        {
            // Get the Options we found earlier from the ScenarioContext and convert to a List
            var possibleOptions = ScenarioContext.Current.Get<IEnumerable<string>>("Options").ToList();

            var targetList = table.Rows.Select(r => r.Values.FirstOrDefault()).ToList();
            //Skip the first as it will be "Please select" ... compare...
            possibleOptions.Skip(1).ToList().CompareLists(targetList).ShouldBeTrue();
        }

        [When(@"I look at the cover available within the (.*) offering")]
        public void ILookAtTheCoverAvailableWithinTheOffering(string offering)
        {
            // Don't know why, but form sometimes not ready!!
            Thread.Sleep(1000);

            var tableHeaders = WebDriver
                .FindElements(new JQuerySelector("quote-result .comparison-table tr:first-child th p"))
                .ToList();

            for (var i = 0; i < tableHeaders.Count; ++i)
            {
                if (tableHeaders[i].Text.Trim().StartsWith(offering))
                {
                    //Index working from 1 in subsequent calls
                    ScenarioContext.Current.Add("OfferingIndex", i++.ToString());
                    return;
                }
            }

            AssertionExtensions.Fail($"Expected {offering} offering to be in results table, but not found");

        }

        [Then(@"I see that the (.*) cover option is set to (.*)")]
        public void ISeeThatTheCoverOptionIsSetTo(string fieldName, string option)
        {
            var offeringIndex = ScenarioContext.Current.Get<string>("OfferingIndex");

            WebDriver.
                FindElement(new JQuerySelector($"quote-result .comparison-table tr:has(.comparison-table--label__text:contains('{fieldName}')) td:eq({offeringIndex}) b"))
                .Text.LooseEquals(option)
                .ShouldBe(true);

        }

        [Then(@"I see that the Quote CTA button text is set to (.*)")]
        public void ISeeThatTheQuoteCTAButtonTextIsSetTo(string ctaText)
        {
            var offeringIndex = ScenarioContext.Current.Get<string>("OfferingIndex");

            WebDriver
               .FindElement(new JQuerySelector($"quote-result .comparison-table tr:has(permutation-button) > th:eq({offeringIndex}) permutation-button"))
               .Text.LooseEquals(ctaText)
               .ShouldBe(true);
        }
    }
}
