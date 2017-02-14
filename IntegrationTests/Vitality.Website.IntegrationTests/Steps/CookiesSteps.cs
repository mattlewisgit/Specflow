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
    public sealed class CookiesSteps : BaseSteps
    {

        [Given(@"I have cleared the browser cache")]
        public void GivenIHaveClearedTheBrowserCache()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
            Thread.Sleep(1000);
            //refresh page
            WebDriver.Navigate().Refresh();

        }


        [When(@"I click on (.*) cookies")]
        public void WhenIClickOnCookies(string CookiesButton)
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".cookie-message.animated.slideInDown .grid .grid-col-3-12"))
                    .Click();

            //needed to allow the cookie time to slide out
            Thread.Sleep(2000);

        }


        [Then(@"I expect cookies pop up to be visible")]
        public void ThenIExpectCookiesPopUpToBeVisible()
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".cookie-message.animated.slideInDown .grid .grid-col-3-12"))
                    .Displayed.ShouldBeTrue();
        }



        [Then(@"I expect cookies pop up to be hidden")]
        public void ThenIExpectCookiesPopUpToBeHidden()
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".cookie-message.animated.slideOutUp"))
                    .GetAttribute("style")
                    .ShouldContain("display: none;");
        }


    }
}
