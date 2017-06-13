namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using TechTalk.SpecFlow;
    using Extensions;
    using OpenQA.Selenium.Interactions;

    [Binding]
    public class QuoteAndApplySteps : BaseSteps
    {
        [Given(@"I see the Quote And Apply page feed load has completed")]
        public void ISeeTheQuoteAndApplyPageFeedLoadHasCompleted()
        {
            //Use the specific function for Angular 2
            WebDriver
                .WaitForAngular();
        }

        [Given(@"I go to the (.*) field and choose (.*)")]
        public void IGoToTheFieldAndChoose(string fieldName, string option)
        {
            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question select[formcontrolname|='{fieldName}']"))
                .FindElement(new JQuerySelector($"option[value='{option}']"))
                .Click();
        }

        [Given(@"I go to the (.*) field and enter (.*)")]
        public void IGoToTheFieldAndEnter(string fieldName, string inputText)
        {
            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question input[formcontrolname|='{fieldName}']"))
                .SendKeys(inputText);
        }

        [When(@"I click on the (.*) button")]
        public void IClickOnTheButton(string buttonName)
        {
            WebDriver.ScrollToElement("form button");

            var button = WebDriver
                .FindElement(new JQuerySelector($"button:contains('{buttonName}')"));

            button.Click();
            // Send a "scroll" - in case button is not in viewport

        }

        [Then(@"I expect to see the interim panel")]
        public void ThenIExpectToSeeTheInterimPanel()
        {
            var interimPanel = WebDriver
                .FindElement(new JQuerySelector(".quote--content > quoteapply-form div:contains('You will be submitting following values when development completed:')"));

            interimPanel
                .FindElement(new JQuerySelector("ul > li:contains('Name : Mrs.Sarah Nicholas')"));

            interimPanel
                .FindElement(new JQuerySelector("ul > li:contains('Contact Number : 01202 223344')"));

            interimPanel
                .FindElement(new JQuerySelector("ul > li:contains('sarah.nicholas@gmail.com')"));

            interimPanel
                .FindElement(new JQuerySelector("ul > li:contains('Date of Birth : 01/01/1970')"));

        }


    }
}
