namespace Vitality.Website.IntegrationTests.Steps.QuoteAndApply.QuoteResults
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class RichTextSteps : BaseSteps
    {
        [Then(@"I expect the quote result rich text component to appear")]
        public void ThenIExpectTheQuoteResultRichTextComponentToAppear()
        {
            // Check rich text box is centred
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 p"))
                .GetCssValue("text-align")
                .ShouldBe("center");

            // Check rich text is white font colour
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 p"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");
        }

    }
}
