namespace Vitality.Website.IntegrationTests.Steps.DIY
{
    using Kingfisher.Website.IntegrationTests.Extensions;
    using Kingfisher.Website.IntegrationTests.Steps;
    using Selenium.WebDriver.Extensions.JQuery;
    using System;
    using System.Linq;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding]
    public sealed class ButtonField : BaseSteps
    {

        [When(@"I click on the (.*) button")]
        public void WhenIClickOnTheButton(string button)
        {

            try
            {
                WebDriver.WaitForElement(new JQuerySelector(".btn.btn-primary"));

                var possibleOptions = WebDriver
                    .FindElements(new JQuerySelector(".btn.btn-primary"));
                
                possibleOptions
                    .FirstOrDefault(e => e.GetAttribute("value").LooseEquals(button))
                    .Click();

            }
            catch (Exception)
            {
                Assert.True(false, "" + button + " button not found!");
            }

        }

    }
}
