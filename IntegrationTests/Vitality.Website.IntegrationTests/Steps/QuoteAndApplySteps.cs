using System;
using System.Collections.Generic;
using System.Linq;
using Selenium.WebDriver.Extensions;
using Shouldly;
using TechTalk.SpecFlow;
using By = OpenQA.Selenium.By;
using OpenQA.Selenium;
using Xunit;
using System.Threading;
using System.Collections.ObjectModel;
using Selenium.WebDriver.Extensions.JQuery;
using OpenQA.Selenium.Support.UI;
using Vitality.Extensions.Selenium;
using Vitality.Website.IntegrationTests.Extensions;

namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public class QuoteAndApplySteps : BaseSteps
    {
        [Given(@"I see the Quote And Apply page feed load has completed")]
        public void ISeeTheQuoteAndApplyPageFeedLoadHasCompleted()
        {

            WebDriver
                .WaitForAngular();

        }

        [When(@"I go to the (.*) field and choose (.*)")]
        [Given(@"I go to the (.*) field and choose (.*)")]
        public void IGoToTheFieldAndChoose(string fieldName, string option)
        {

            //ReadOnlyCollection<IWebElement> possibleOptions;

            var possibleOptions = WebDriver
                .FindElements(new JQuerySelector($".quote--content > quoteapply-form .question #{fieldName} option"));

            possibleOptions
                .FirstOrDefault(e => e.Text.Equals(option))
                .Click();


        }

        [When(@"I go to the (.*) field and enter (.*)")]
        [Given(@"I go to the (.*) field and enter (.*)")]
        public void IGoToTheFieldAndEnter(string fieldName, string inputText)
        {
            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question .question--input__text #{fieldName}"))
                .SendKeys(inputText);
        }

        [When(@"I click on the (.*) button")]
        public void IClickOnTheButton(string buttonName)
        {
            WebDriver.ScrollToElement("form button");

            WebDriver.ExecuteScript($"$('form {buttonName}')[0].scrollIntoView();");

            var button = WebDriver
                .FindElement(new JQuerySelector($"button:contains('{buttonName}')"));

            button.Click();
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


        [Then(@"the (.*) field is not displayed")]
        public void TheFieldIsNotDisplayed(string fieldName)
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($".quote--content > quoteapply-form .question #{fieldName}"));
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Then(@"the (.*) field is displayed")]
        public void TheFieldIsDisplayed(string fieldName)
        {
            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question #{fieldName}"))
                .ShouldNotBeNull();
        }

        [Then(@"I see the (.*) field error text (.*)")]
        public void ISeeTheFieldErrorText(string fieldName, string errorText)
        {

            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question:has(#{fieldName}) .question--input__error"))
                .Text.LooseEquals(errorText);

        }


    }
}
