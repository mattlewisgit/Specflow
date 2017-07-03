namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class PartnerHeroSteps : BaseSteps
    {
        private string cardvalue;

        [Then(@"I expect the correct CSS Partner Hero (.*) font values and (.*) card snippet to appear")]
        public void ThenIExpectTheCorrectCSSPartnerHeroFontValuesAndCardSnippetToAppear(string colour, string card)
        {
            //If string equals 'with', then pass card snippet with JQuery Selector Value
            if (card.Equals("with"))
            {
                cardvalue = "6";
            }
            //If string equals 'without', then pass card snippet hidden JQuery Selector Value
            if (card.Equals("without"))
            {
                cardvalue = "12";
            }


            //LEFT hand side panel
            //Partner Hero contains Paragraph
            WebDriver
                .FindElement(new JQuerySelector(".partner-hero .grid .partner-hero--headline.grid-col-" + cardvalue + "-12.text-" + colour + " .partner-hero--headline__intro"))
                .Displayed
                .ShouldBeTrue();

            //Partner Hero contains H1
            WebDriver
                .FindElement(new JQuerySelector(".partner-hero .grid .partner-hero--headline.grid-col-" + cardvalue + "-12.text-" + colour + " h1"))
                .Displayed
                .ShouldBeTrue();

            //Partner Hero contains Div
            WebDriver
                .FindElement(new JQuerySelector(".partner-hero .grid .partner-hero--headline.grid-col-" + cardvalue + "-12.text-" + colour + " .partner-hero--headline__body"))
                .Displayed
                .ShouldBeTrue();


            //PARTNER CARD
            //Partner Hero contains 'with' Card image
            if (card.Equals("with"))
            {
                WebDriver
                .FindElement(new JQuerySelector(".partner-hero .grid .grid-col-" + cardvalue + "-12.partner-hero--right .partner-hero--card .spotlight-item__logo--large img"))
                .Displayed
                .ShouldBeTrue();

                //Partner Hero contains Card paragraph
                WebDriver
                    .FindElement(new JQuerySelector(".partner-hero .grid .grid-col-" + cardvalue + "-12.partner-hero--right .partner-hero--card .partner-hero--card__top p"))
                    .Displayed
                    .ShouldBeTrue();

                //Partner Hero contains Card bottom text background colour
                WebDriver
                    .FindElement(new JQuerySelector(".partner-hero .grid .grid-col-" + cardvalue + "-12.partner-hero--right .partner-hero--card .partner-hero--card__bottom.text-light"))
                    .GetCssValue("background")
                    .Contains("rbg(244, 28, 94)");

                //Partner Hero contains Card bottom text font colour
                WebDriver
                    .FindElement(new JQuerySelector(".partner-hero .grid .grid-col-" + cardvalue + "-12.partner-hero--right .partner-hero--card .partner-hero--card__bottom.text-light"))
                    .GetCssValue("color")
                    .Contains("rbga(255, 255, 255, 1)");
            }

        }
    }
}
