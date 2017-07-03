namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class CallToActionSteps : BaseSteps
    {
        [Then(@"I expect the correct CTA CSS values to appear for mobile view")]
        public void ThenIExpectTheCorrectCTACSSValuesToAppearForMobileView()
        {
            // Check CTA header icon image.
            WebDriver
                .FindElement(new JQuerySelector(".cta .cta__header img"))
                .GetCssValue("display")
                .ShouldBe("inline-block");

            WebDriver
                .FindElement(new JQuerySelector(".cta .cta__header img"))
                .GetCssValue("max-height")
                .ShouldBe("32px");

            WebDriver
                .FindElement(new JQuerySelector(".cta .cta__header img"))
                .GetCssValue("vertical-align")
                .ShouldBe("top");

            // Check CTA body paragraph.
            WebDriver
                .FindElement(new JQuerySelector(".cta .cta__body"))
                .Displayed
                .ShouldBeTrue();

            // Check CTA button CSS layout.
            WebDriver
                .FindElement(new JQuerySelector(".cta .grid-module a"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(91, 182, 177, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".cta .grid-module a"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

           WebDriver
                .FindElement(new JQuerySelector(".cta .grid-module a"))
                .GetCssValue("box-shadow")
                .ShouldBe("none");
        }

        [When(@"I click on CTA (.*) button")]
        public void WhenIClickOnCTAButton(string button)
        {
            //WebDriver
            //     .WaitForElement(new JQuerySelector(
            //         $".cta .grid-module .box-button.box-button--rounded.box-button--secondary:contains('{button}')"))
            //     .Click();

                        
            var buttonSelector = new JQuerySelector(
                     $".cta .grid-module .box-button.box-button--rounded.box-button--secondary:contains('{button}')");

            // Scroll to button if not visible.
            WebDriver
                .WaitForElement(buttonSelector)
                .SendKeys(Keys.Space);

            // Click on button.
            WebDriver
                .WaitForElement(buttonSelector)
                .Click();


        }
    }
}
