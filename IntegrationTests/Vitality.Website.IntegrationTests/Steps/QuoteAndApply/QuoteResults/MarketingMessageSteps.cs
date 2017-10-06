using Selenium.WebDriver.Extensions.JQuery;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Vitality.Extensions.Selenium;

namespace Vitality.Website.IntegrationTests.Steps.QuoteAndApply.QuoteResults
{
    [Binding]
    public sealed class MarketingMessageSteps : BaseSteps
    {

        [Then(@"I expect the marketing message (.*) to be displayed")]
        public void ThenIExpectTheMarketingMessageToBeDisplayed(string loadingMessage)
        {
            WebDriver
                 .WaitForElement(new JQuerySelector($"quote-result .full-loading-content h3 p"))
                 .Displayed
                 .ShouldBeTrue();

            WebDriver
                .WaitForElement(new JQuerySelector($"quote-result .full-loading-content .loader__icon"))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(new JQuerySelector($"quote-result .full-loading-content .full-loading-loading-text:contains('{loadingMessage}')"))
                .Displayed
                .ShouldBeTrue();
        }


    }
}
