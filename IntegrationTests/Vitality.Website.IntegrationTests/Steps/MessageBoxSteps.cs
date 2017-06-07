namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class MessageBoxSteps : BaseSteps
    {
        [Then(@"I expect the Message Box Error Message to be displayed")]
        public void ThenIExpectTheMessageBoxErrorMessageToBeDisplayed()
        {
            // Check message box error appears.
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--error"))
                .Displayed
                .ShouldBeTrue();

            // Check message box contains a header.
            WebDriver
                .WaitForElement(new JQuerySelector
                    (".message-box.message-box--error h4.message-box__heading"))
                .Displayed
                .ShouldBeTrue();

            // Check background colour.
            WebDriver
                .FindElement(new JQuerySelector(".message-box.message-box--error"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(255, 105, 97, 0.2)");

            //check image
            //need to look into this..... Checking the image icons
        }

        [Then(@"I expect the Message Box Alert Message to be displayed")]
        public void ThenIExpectTheMessageBoxAlertMessageToBeDisplayed()
        {
            // Check message box alert appears.
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--alert"))
                .Displayed
                .ShouldBeTrue();

            // Check message box contains a header.
            WebDriver
                .WaitForElement(new JQuerySelector
                    (".message-box.message-box--alert h4.message-box__heading"))
                .Displayed
                .ShouldBeTrue();

            // Check background colour.
            WebDriver
                .FindElement(new JQuerySelector(".message-box.message-box--alert"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(91, 182, 177, 0.2)");

            //check image
            //need to look into this..... Checking the image icons
        }

        [Then(@"I expect the Message Box Expired Message to be displayed")]
        public void ThenIExpectTheMessageBoxExpiredMessageToBeDisplayed()
        {
            // Check message box expired appears.
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--expired"))
                .Displayed
                .ShouldBeTrue();

            // Check message box contains a header.
            WebDriver
                .WaitForElement(new JQuerySelector
                    (".message-box.message-box--expired h4.message-box__heading"))
                .Displayed
                .ShouldBeTrue();

            // Check background colour.
            WebDriver
                .FindElement(new JQuerySelector(".message-box.message-box--expired"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(91, 182, 177, 0.2)");

            //check image
            //need to look into this..... Checking the image icons
        }
    }
}
