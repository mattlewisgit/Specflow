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
            } );

            
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
