using Kingfisher.Website.IntegrationTests.Steps;

namespace Vitality.Website.IntegrationTests.Steps.DIY
{
    using Selenium.WebDriver.Extensions.JQuery;
    using System;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding]
    public sealed class TextField : BaseSteps
    {

        [When(@"I go to the (.*) text field and enter (.*)")]
        public void WhenIGoToTheFieldAndEnter(string fieldName, string inputText)
        {

            try
            {

                WebDriver
                    .FindElement(new JQuerySelector($"#{fieldName}"))
                    .SendKeys(inputText);

                ScenarioContext.Current.Add($"{fieldName}", inputText);

            }
            catch (Exception)
            {
                Assert.True(false, "" + fieldName + " field cannot enter " + inputText + "");
            }

        }

    }
}
