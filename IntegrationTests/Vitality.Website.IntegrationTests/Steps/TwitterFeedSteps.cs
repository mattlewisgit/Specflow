

namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class TwitterFeedSteps : BaseSteps
    {
        [Then(@"I expect the twitter feed to open")]
        public void ThenIExpectTheTwitterFeedToOpen()
        {
            // Check twitter feed renders onto the page
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 .twitter-timeline.twitter-timeline-rendered"))
                .Displayed
                .ShouldBeTrue();
        }

    }
}
