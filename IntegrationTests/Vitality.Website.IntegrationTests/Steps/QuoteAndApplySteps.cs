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
            WebDriver.ScrollToElement($"#{fieldName}");

            var possibleOptions = WebDriver
                .FindElements(new JQuerySelector($".quote--content > quoteapply-form .question #{fieldName} option"));

            possibleOptions
                .FirstOrDefault(e => e.Text.Equals(option))
                .Click();
        }


        [Given(@"I go to the (.*) field and enter (.*)")]
        [When(@"I go to the (.*) field and enter (.*)")]
        public void IGoToTheFieldAndEnter(string fieldName, string inputText)
        {
            WebDriver.ScrollToElement($"#{fieldName}");

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


        [Given(@"the (.*) field is not displayed")]
        [When(@"the (.*) field is not displayed")]
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


        [Given(@"the (.*) field is displayed")]
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
                .Text.LooseEquals(errorText)
                .ShouldBe(true);

        }

        [Then(@"I don't see the (.*) field error")]
        public void IDontSeetheFieldError(string fieldName)
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($".quote--content > quoteapply-form .question:has(#{fieldName}) .question--input__error"))
                    .ShouldBeNull();
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


        [Then(@"I don't see any field errors")]
        public void IDonTSeeAnyFieldErrors()
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($".quote--content > quoteapply-form .question .question--input__error"))
                    .ShouldBeNull();
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

        public enum PlusMinus
        {
            plus,
            minus
        }


        [Given(@"I go to the (.*) field and make the age (.*) (.*) (.*) days")]
        [When(@"I go to the (.*) field and make the age (.*) (.*) (.*) days")]
        public void IGoToTheFieldAndMakeTheAgeDays(string fieldName, int age, PlusMinus plusMinus, int days)
        {
            // As this function is setting the age, I have deliberately reversed the logic around adding and subtracting days
            // so a "plus" enum actually takes a day off the birthdate to make the Member older!!
            string inputText = DateTime.Now
                .AddYears(-age)
                .AddDays(plusMinus == PlusMinus.plus ? -days : days)
                .ToString("dd/MM/yyyy");

            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question .question--input__text #{fieldName}"))
                .SendKeys(inputText);
        }

        [Given(@"I go to the (.*) field and make the date today (.*) (.*) days")]
        [When(@"I go to the (.*) field and make the date today (.*) (.*) days")]
        public void IGoToTheFieldAndMakeTheDateTodayDays(string fieldName, PlusMinus plusMinus, int days)
        {
            
            string inputText = DateTime.Now
                .AddDays(plusMinus == PlusMinus.plus ? days : -days)
                .ToString("dd/MM/yyyy");

            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question .question--input__text #{fieldName}"))
                .SendKeys(inputText);
        }

    }
}
