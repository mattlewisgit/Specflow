namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using System;


    [Binding]
    public sealed class CardsStackedSteps : BaseSteps
    {




        [Given(@"I expect the correct CSS values to appear for full-screen view")]
        [When(@"I expect the correct CSS values to appear for full-screen view")]
        [Then(@"I expect the correct CSS values to appear for full-screen view")]
        public void GivenIExpectTheCorrectCSSValuesToAppearForFull_ScreenView()
        {
            String padding = WebDriver.FindElement(new JQuerySelector(".cards-stacked.background-position-top-right.lazyloaded"))
                       .GetCssValue("padding");

            String backgroundsize = WebDriver.FindElement(new JQuerySelector(".cards-stacked.background-position-top-right.lazyloaded"))
                      .GetCssValue("background-size");

            padding.ShouldBe("20px");
            backgroundsize.ShouldBe("cover");
        }



        [Given(@"I expect the correct CSS values to appear for mobile view")]
        [When(@"I expect the correct CSS values to appear for mobile view")]
        [Then(@"I expect the correct CSS values to appear for mobile view")]
        public void GivenIExpectTheCorrectCSSValuesToAppearForMobileView()
        {
            String padding = WebDriver.FindElement(new JQuerySelector(".cards-stacked.background-position-top-right.lazyloaded"))
                      .GetCssValue("padding");

            String backgroundsize = WebDriver.FindElement(new JQuerySelector(".cards-stacked.background-position-top-right.lazyloaded"))
                      .GetCssValue("background-size");

            String backgroundcolor = WebDriver.FindElement(new JQuerySelector(".cards-stacked.background-position-top-right.lazyloaded"))
                      .GetCssValue("background-color");            

            padding.ShouldBe("40px");
            backgroundsize.ShouldBe("auto");
            //rgba(234, 239, 244, 1) = mobile view default colour
            backgroundcolor.ShouldBe("rgba(234, 239, 244, 1)");


        }


    }
}
