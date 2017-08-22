namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class SummaryComponentSteps : BaseSteps
    {

        [Then(@"I expect the correct CSS summary component values to appear in full view")]
        public void ThenIExpectTheCorrectCSSSummaryComponentValuesToAppearInFullView()
        {
            //Left side panel.

            //Summary Component contains paragraph.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-left.grid-col-6-12 p"))
                .Displayed
                .ShouldBeTrue();
            
            //Summary Component contains h2.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-left.grid-col-6-12 h2"))
                .Displayed
                .ShouldBeTrue();

            //Summary Component contains paragraph.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-left.grid-col-6-12 div p"))
                .Displayed
                .ShouldBeTrue();


            //Right hand side panel.

            //Summary Component contains title paragraph.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .title p"))
                .Displayed
                .ShouldBeTrue();

            //Summary Component contains body text.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .content .summary-right--content__body"))
                .Displayed
                .ShouldBeTrue();

            //Summary Component icon list short.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .content .iconlist.iconlist--check .iconlist__item h4"))
                .Displayed
                .ShouldBeTrue();

            //Summary Component icon list long.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .content .iconlist.iconlist--check.iconlist--full .iconlist__item h4"))
                .Displayed
                .ShouldBeTrue();

            //Summary Component button.
            WebDriver
                .FindElement(new JQuerySelector(".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .content .cta a"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I click on the summary component button (.*)")]
        public void WhenIClickOnTheSummaryComponentButton(string button)
        {
            //Scroll to element
            WebDriver.ScrollToElement(".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .content .cta a");

            var buttonSelector = new JQuerySelector(
            $".summary.grid .summary-right.feature-block-gradient__image.text-light.grid-col-6-12.lazyloaded .content .cta:contains('{button}')");

            // Click on button.
            WebDriver
                .WaitForElement(buttonSelector)
                .Click();
        }



    }
}
