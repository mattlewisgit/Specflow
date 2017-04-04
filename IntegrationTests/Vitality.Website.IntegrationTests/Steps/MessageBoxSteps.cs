namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Drawing;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Extensions;
    using Utilities;
    using OpenQA.Selenium.Interactions;
    using By = OpenQA.Selenium.By;
    using OpenQA.Selenium.Support.UI;
    using System;

    [Binding]
    public sealed class MessageBoxSteps : BaseSteps
    {

        [Then(@"I expect the Message Box Error Message to be displayed")]
        public void ThenIExpectTheMessageBoxErrorMessageToBeDisplayed()
        {
            //check message box error appears
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--error"))
                .Displayed.ShouldBeTrue();

            //check message box contains H4
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--error h4.message-box__heading"))
                .Displayed.ShouldBeTrue();

            //check background color
            String messagecolor = WebDriver.FindElement(new JQuerySelector(".message-box.message-box--error"))
                                    .GetCssValue("background-color");

            messagecolor.ShouldBe("rgba(255, 105, 97, 0.2)");

            //check image
            //need to look into this..... Checking the image icons

        }


        [Then(@"I expect the Message Box Alert Message to be displayed")]
        public void ThenIExpectTheMessageBoxAlertMessageToBeDisplayed()
        {
            //check message box alert appears
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--alert"))
                .Displayed.ShouldBeTrue();

            //check message box contains H4
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--alert h4.message-box__heading"))
                .Displayed.ShouldBeTrue();

            //check background color
            String messagecolor = WebDriver.FindElement(new JQuerySelector(".message-box.message-box--alert"))
                                    .GetCssValue("background-color");

            messagecolor.ShouldBe("rgba(91, 182, 177, 0.2)");

            //check image
            //need to look into this..... Checking the image icons
        }



        [Then(@"I expect the Message Box Expired Message to be displayed")]
        public void ThenIExpectTheMessageBoxExpiredMessageToBeDisplayed()
        {
            //check message box expired appears
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--expired"))
                .Displayed.ShouldBeTrue();

            //check message box contains H4
            WebDriver
                .WaitForElement(new JQuerySelector(".message-box.message-box--expired h4.message-box__heading"))
                .Displayed.ShouldBeTrue();

            //check background color
            String messagecolor = WebDriver.FindElement(new JQuerySelector(".message-box.message-box--expired"))
                                    .GetCssValue("background-color");

            messagecolor.ShouldBe("rgba(91, 182, 177, 0.2)");

            //check image
            //need to look into this..... Checking the image icons
        }



    }
}
