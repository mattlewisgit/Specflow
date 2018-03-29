using System.Threading;
using Shouldly;

namespace Vitality.Website.IntegrationTests.Steps.GAPI
{
    using Kingfisher.Website.IntegrationTests.Steps;
    using Selenium.WebDriver.Extensions.JQuery;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class StockEndpointSteps : BaseSteps
    {

        [Then(@"I expect the quantity to be (.*)")]
        public void ThenIExpectTheQuantityToBe(int quantity)
        {
            //Thread.Sleep(1000);

            WebDriver
                .FindElement(new JQuerySelector("#pre"))
                .Displayed
                .ShouldBeTrue();
        }


    }
}
