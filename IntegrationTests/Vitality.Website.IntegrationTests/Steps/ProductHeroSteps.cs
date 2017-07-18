using OpenQA.Selenium;
using Selenium.WebDriver.Extensions.JQuery;
using Shouldly;
using TechTalk.SpecFlow;
using Vitality.Extensions.Selenium;

namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public sealed class ProductHeroSteps : BaseSteps
    {
        private string H1fontsize;

        [Then(@"I expect the correct CSS product hero values to appear for (.*)")]
        public void ThenIExpectTheCorrectCSSProductHeroValuesToAppearFor(string screensize)
        {
            //If string equal 'full view', then pass H1 font size Value
            if (screensize.Equals("full view"))
            {
                H1fontsize = "40px";
            }
            //If string equal 'mobile view', then pass H1 font size Value
            if (screensize.Equals("mobile view"))
            {
                H1fontsize = "28px";
            }


            //Product Hero image right hand side
            // Check Product Hero Images are LazyLoaded
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__image .lazyloaded"))
                .Displayed
                .ShouldBeTrue();

            //Check image colour
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__image"))
                .GetCssValue("background")
                .ShouldContain("rgb(244, 28, 94)");

            //check image padding
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__image"))
                .GetCssValue("padding-top")
                .ShouldContain("0");

            //Check image is centred
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__image"))
                .GetCssValue("text-align")
                .ShouldContain("center");


            //Product Hero image left hand side
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content .lead-in.lazyloaded"))
                .GetCssValue("height")
                .ShouldContain("70px");

            //Product Hero H1 colour
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content H1"))
                .GetCssValue("color")
                .ShouldContain("rgba(255, 255, 255, 1)");


            //Product Hero H1 font size ***
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content H1"))
                .GetCssValue("font-size")
                .ShouldContain(H1fontsize);


            //Product Hero body
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content .feature-block__content-body"))
                .GetCssValue("font-size")
                .ShouldContain("16px");

            //Product Hero CTA Button Colour
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content .button-cta"))
                .GetCssValue("color")
                .ShouldContain("rgba(77, 77, 77, 1)");

            //Product Hero CTA Button Background Colour
            WebDriver
                .FindElement(new JQuerySelector(".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content .button-cta"))
                .GetCssValue("background-color")
                .ShouldContain("rgba(255, 255, 255, 1)");
        }

        [When(@"I click on the Product Hero (.*) Button")]
        public void WhenIClickOnTheProductHeroButton(string button)
        {
            WebDriver
                .ScrollToElement($@".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content .button-cta:contains(""{button}"")");

            var buttonSelector = new JQuerySelector($".product-hero.feature-block.feature-block--primary .feature-block__content-container .feature-block__content .button-cta:contains('{button}')");

            // Click on button.
            WebDriver
                .WaitForElement(buttonSelector)
                .Click();
        }

    }
}
