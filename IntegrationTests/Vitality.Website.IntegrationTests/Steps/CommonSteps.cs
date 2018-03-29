using System;
using System.ComponentModel.Design;
using OpenQA.Selenium;
using Selenium.WebDriver.Extensions.JQuery;

namespace Kingfisher.Website.IntegrationTests.Steps {
    using System.Threading;
    using Extensions;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Xunit; 
    [Binding]     public class CommonSteps : BaseSteps     { 
        [Given(@"I am on DIY\.com URL (.*)")]
        public void GivenIAmOnDIY_ComURL(string link)
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Links.DIYBaseUrl + link);
            WebDriver.WaitForPageLoad();
        }

        [Given(@"I am on stock API endpoint URL (.*)")]
        public void GivenIAmOnStockAPIEndpointURL(string link)
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Links.StockEndpointUrl + link);
            WebDriver.WaitForPageLoad();
        }


        [Given(@"I am on Riversand URL (.*)")]
        public void GivenIAmOnRiversandURL(string link)
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Links.RiversandBaseUrl + link);
            WebDriver.WaitForPageLoad();
        }


        [Then(@"I expect the kingfisher URL (.*) to open")]
        public void ThenIExpectTheKingfisherURLToOpen(string link)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldContain(AppSettings.Links.DIYBaseUrl + link);
        }

        [Then(@"I expect the page heading to be (.*) and URL to be (.*)")]
        public void ThenIExpectThePageHeadingToBeAndURLToBe(string pageHeading, string URL)
        {

            //Check heading
            try
            {
                WebDriver
                    .FindElement(new JQuerySelector(".wrapper-main .page-title"))
                    .Text.LooseEquals(pageHeading)
                    .ShouldBe(true);
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                var heading = WebDriver
                    .FindElement(new JQuerySelector
                        (".wrapper-main .page-title"))
                    .GetAttribute("innerText");

                Assert.True(false, "page heading '" + heading + "' does not match expected page heading '" + pageHeading + "'");
            }

            //check URL
            WebDriver
                .WaitForPageLoad()
                .Url
                .Contains(URL)
                .ShouldBeTrue();
        }
        

        [Then(@"I expect the Riversand URL (.*) to open")]
        public void ThenIExpectTheRiversandURLToOpen(string link)
        {
            //Need to add wait for page to load instead of sleep
            WebDriver.WaitForPageLoad();
            Thread.Sleep(2000);

            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldContain(AppSettings.Links.RiversandBaseUrl + link);
        }


    } } 