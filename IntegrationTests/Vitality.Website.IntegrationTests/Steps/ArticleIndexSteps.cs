namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class ArticleIndexSteps : BaseSteps
    {

        [Then(@"I expect the correct CSS Article Index values to appear in full view")]
        public void ThenIExpectTheCorrectCSSArticleIndexValuesToAppearInFullView()
        {
            //Check Backfround Colour
            WebDriver
                .FindElement(new JQuerySelector(".article-index"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(79, 115, 138, 1)");

            //Check H2
            WebDriver
                .FindElement(new JQuerySelector(".article-index h2"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".article-index h2"))
                .GetCssValue("text-align")
                .ShouldBe("center");

            WebDriver
                .FindElement(new JQuerySelector(".article-index h2"))
                .GetCssValue("font-size")
                .ShouldBe("35px");

            //Check Paragraph
            WebDriver
                .FindElement(new JQuerySelector(".article-index p"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".article-index p"))
                .GetCssValue("text-align")
                .ShouldBe("center");

            //Check card image
            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-5-12"))
                .Displayed
                .ShouldBeTrue();

            //Check card content H3
            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-7-12.article-snippet--content a h3"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            //Check card content paragraph
            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-7-12.article-snippet--content a p"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");
        }


        [Then(@"I expect the correct CSS Article Index values to appear in mobile view")]
        public void ThenIExpectTheCorrectCSSArticleIndexValuesToAppearInMobileView()
        {
            //Check Backfround Colour
            WebDriver
                .FindElement(new JQuerySelector(".article-index"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(79, 115, 138, 1)");

            //Check H2
            WebDriver
                .FindElement(new JQuerySelector(".article-index h2"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".article-index h2"))
                .GetCssValue("text-align")
                .ShouldBe("center");

            WebDriver
                .FindElement(new JQuerySelector(".article-index h2"))
                .GetCssValue("font-size")
                .ShouldBe("25px");

            //Check Paragraph
            WebDriver
                .FindElement(new JQuerySelector(".article-index p"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".article-index p"))
                .GetCssValue("text-align")
                .ShouldBe("center");

            //Check card image
            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-5-12"))
                .Displayed
                .ShouldBeTrue();

            //Check card content H3
            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-7-12.article-snippet--content a h3"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            //Check card content paragraph
            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-7-12.article-snippet--content a p"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".article-index .grid-no-gutters .grid-col-6-12 .grid-no-gutters .grid-col-7-12.article-snippet--content a p"))
                .GetCssValue("font-size")
                .ShouldBe("20px");
        }

        [When(@"I click on Article Index (.*) card")]
        public void WhenIClickOnArticleIndexCard(string ArticleIndexCard)
        {
            //Check card image
            WebDriver
                .FindElement(new JQuerySelector(".grid-col-7-12.article-snippet--content:contains('" + ArticleIndexCard + "')"))
                .Click();
        }


    }
}
