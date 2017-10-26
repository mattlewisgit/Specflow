namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class AccordionSteps : BaseSteps
    {
        [When(@"I click on accordion tab (.*)")]
        public void WhenIClickOnAccordionTab(string accordionTitle)
        {
            // Send a "scroll"
            WebDriver
                .ScrollToElement($@".expander .expander__link:contains(""{accordionTitle}"")");

            WebDriver
                    .FindElement(new JQuerySelector($@".expander .expander__link:contains(""{accordionTitle}"")"))
                    .Click();
        }

        [Then(@"I expect the accordion description (.*) to appear")]
        public void ThenIExpectTheAccordionDescriptionToAppear(string accordion)
        {
            //Check selected accordion description is visible
            WebDriver
                    .WaitForElement(new JQuerySelector(accordion + ".expander__content.is-active"))
                    .Displayed.ShouldBeTrue();

            //Check selected accordion down arrow icon is visible
            WebDriver
                    .WaitForElement(new JQuerySelector(".expander__link.is-active"))
                    .Displayed.ShouldBeTrue();

        }
    }
}
