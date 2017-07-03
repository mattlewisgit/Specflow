using Selenium.WebDriver.Extensions.JQuery;
using Shouldly;
using TechTalk.SpecFlow;
using Vitality.Extensions.Selenium;

namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public sealed class Product_ComponentSteps : BaseSteps
    {
        [Then(@"I expect the correct CSS Products Component values to appear in full view")]
        public void ThenIExpectTheCorrectCSSProductsComponentValuesToAppearInFullView()
        {
            //check background colour is pink.
            WebDriver
                .WaitForElement(new JQuerySelector(".products-component.text-light .grid.pinch .products-component--panel.grid-col-6-12"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(244, 28, 94, 1)");

            //Check image.
            WebDriver
                .WaitForElement(new JQuerySelector(".products-component.text-light .grid.pinch .products-component--panel.grid-col-6-12 .lazyloaded"))
                .Displayed
                .ShouldBeTrue();

            //Check description font colour.
            WebDriver
                .WaitForElement(new JQuerySelector(".products-component.text-light .grid.pinch .products-component--panel.grid-col-6-12 .products-component--panel__body"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            //Check button background colour.
            WebDriver
                .WaitForElement(new JQuerySelector(".products-component.text-light .grid.pinch .products-component--panel.grid-col-6-12 .button-cta"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            //Check button border colour.
            WebDriver
                .WaitForElement(new JQuerySelector(".products-component.text-light .grid.pinch .products-component--panel.grid-col-6-12 .button-cta"))
                .GetCssValue("border")
                .ShouldBe("5px solid rgba(0, 0, 0, 0.4)");
        }

    }
}
