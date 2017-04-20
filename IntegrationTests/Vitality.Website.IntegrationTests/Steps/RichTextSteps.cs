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
    using System.Threading;


    [Binding]
    public sealed class RichTextSteps :BaseSteps
    {

        [When(@"I click on the rich text dialog (.*) link")]
        public void WhenIClickOnTheRichTextDialogLink(string DialogLink)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-12-12 a:contains('" + DialogLink + "')"))
                .Click();
        }


        [Then(@"I expect the dialog pop up box to appear")]
        public void ThenIExpectTheDialogPopUpBoxToAppear()
        {
            //Check lightbox is visible
            WebDriver
                .WaitForElement(new JQuerySelector(".featherlight-content .hidden-dialogue-box-content.featherlight-inner"))
                .Displayed
                .ShouldBeTrue();

            //Check Close icon is visible
            WebDriver
                .WaitForElement(new JQuerySelector("span.featherlight-close-icon.featherlight-close"))
                .Displayed
                .ShouldBeTrue();          
        }


        [Then(@"I click on the close dialog box")]
        public void ThenIClickOnTheCloseDialogBox()
        {
            WebDriver
                .WaitForElement(new JQuerySelector("span.featherlight-close-icon.featherlight-close"))
                .Click();
        }


    }
}
