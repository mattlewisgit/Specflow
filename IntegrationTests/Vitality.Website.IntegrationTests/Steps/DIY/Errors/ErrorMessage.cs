using Kingfisher.Website.IntegrationTests.Steps;

namespace Vitality.Website.IntegrationTests.Steps.DIY.Errors
{
    using Kingfisher.Website.IntegrationTests.Extensions;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class ErrorMessage : BaseSteps
    {

        [Then(@"I expect an error message to appear")]
        public void ThenIExpectAnErrorMessageToAppear()
        {

            WebDriver
                .WaitForElement(new JQuerySelector(".message.error .msg-holder .msg-icon"))
                .Displayed
                .ShouldBeTrue();

        }

    }
}
