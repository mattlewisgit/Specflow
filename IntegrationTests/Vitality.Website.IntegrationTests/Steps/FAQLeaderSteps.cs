namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class FAQLeaderSteps : BaseSteps
    {
        [Then(@"I expect the correct CSS FAQ Leader values to appear")]
        public void ThenIExpectTheCorrectCSSFAQLeaderValuesToAppear()
        {
            //FAQ Heading contains H2
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .header h2"))
                .Displayed
                .ShouldBeTrue();

            //FAQ Heading contains description
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .header .paragraph-emphasis"))
                .Displayed
                .ShouldBeTrue();

            //FAQ Leader Block contains H3
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .faqs .grid-no-gutters .grid-col-1-2 h3"))
                .Displayed
                .ShouldBeTrue();

            //FAQ Leader Block contains description
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .faqs .grid-no-gutters .grid-col-1-2 div"))
                .Displayed
                .ShouldBeTrue();

            //FAQ contains paragraph anchor link - font colour
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .faqs .grid-no-gutters .grid-col-1-2 p a"))
                .GetCssValue("font-weight")
                .ShouldBe("600");

            //FAQ contains paragraph anchor link - font weight
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .faqs .grid-no-gutters .grid-col-1-2 p a"))
                .GetCssValue("color")
                .ShouldBe("rgba(102, 102, 102, 1)");

            //FAQ Link Button at the bottom - Border thickness
            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .more a"))
                .GetCssValue("border")
                .ShouldBe("1px solid rgb(102, 102, 102)");

            WebDriver
                .FindElement(new JQuerySelector(".faq_leader .more a"))
                .GetCssValue("padding")
                .ShouldBe("10px 40px");
        }

        [When(@"I click on FAQ Leader paragraph anchor (.*) link")]
        public void WhenIClickOnFAQLeaderParagraphAnchorLink(string anchorText)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(
                    $".faq_leader .faqs .grid-no-gutters .grid-col-1-2 p a:contains('{anchorText}')"))
                .Click();
        }

        [When(@"I click on FAQ Leader bottom button (.*) link")]
        public void WhenIClickOnFAQLeaderComponentLink(string buttonLink)
        {
            var buttonSelector = new JQuerySelector($".faq_leader .more a:contains('{buttonLink}')");

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
