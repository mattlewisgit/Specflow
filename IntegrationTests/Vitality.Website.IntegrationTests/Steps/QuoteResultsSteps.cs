using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TechTalk.SpecFlow;
using Selenium.WebDriver.Extensions.JQuery;
using Vitality.Extensions.Selenium;
using Vitality.Website.IntegrationTests.Extensions;


namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public class QuoteResultsSteps : BaseSteps
    {
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
            ScenarioContext.Current.Add("OptionRow", fieldName);
            ScenarioContext.Current.Add("Selection", updatedOption);
            
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
            var optionRow = ScenarioContext.Current.Get<string>("OptionRow");
            var selection = ScenarioContext.Current.Get<string>("Selection");

            WebDriver
            .FindElements(new JQuerySelector($"quote-result .comparison-table tr:has(.comparison-table--label__text:contains('{optionRow}')) benefit-option b"))
                .All(e => e.Text.Equals(selection));

        }


        [When(@"I go to the (.*) field and look at the options available")]
        public void IGoToTheFieldAndLookAtTheOptionsAvailable(string fieldName)
        {
            WebDriver.ScrollToElement($"#{fieldName}");

            var possibleOptions = WebDriver
                .FindElements(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"));


            ScenarioContext.Current.Add(fieldName, possibleOptions.Select(e => e.Text));
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

    }
}
