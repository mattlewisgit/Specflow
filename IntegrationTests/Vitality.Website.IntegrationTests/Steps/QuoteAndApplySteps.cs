using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Xunit;
using Selenium.WebDriver.Extensions.JQuery;
using Vitality.Extensions.Selenium;
using Vitality.Website.IntegrationTests.Extensions;
using System.Threading;
using System.Text.RegularExpressions;

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
            WebDriver.WaitForAngular();
            //WebDriver.ScrollToElement($"#{fieldName}");

            var possibleOptions = WebDriver
                .FindElements(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"));

            possibleOptions
                .FirstOrDefault(e => e.Text.Equals(option))
                .Click();
        }


        [Given(@"I go to the (.*) field and enter (.*)")]
        [When(@"I go to the (.*) field and enter (.*)")]
        public void IGoToTheFieldAndEnter(string fieldName, string inputText)
        {
            WebDriver.WaitForAngular();

            //WebDriver.ScrollToElement($"#{fieldName}");
            try
            {

                WebDriver
                    .FindElement(new JQuerySelector($".quote--content > tell-form .question .question--input__text #{fieldName}"))
                    .SendKeys(inputText);

                ScenarioContext.Current.Add($"quote{fieldName}", inputText);

            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false, "" + fieldName + " field cannot enter " + inputText + "");
            }

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
                    (new JQuerySelector($".quote--content > tell-form .question #{fieldName}"));
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }


        [Given(@"the (.*) field is displayed")]
        [When(@"the (.*) field is displayed")]
        [Then(@"the (.*) field is displayed")]
        public void TheFieldIsDisplayed(string fieldName)
        {
            WebDriver
                .FindElement(new JQuerySelector($".quote--content > tell-form .question #{fieldName}"))
                .ShouldNotBeNull();
        }

        [Then(@"I see the (.*) field error text (.*)")]
        public void ISeeTheFieldErrorText(string fieldName, string errorText)
        {

            WebDriver
                .WaitForElement(new JQuerySelector($".quote--content > tell-form .question:has(#{fieldName}) .question--input__error"))
                .Text.LooseEquals(errorText)
                .ShouldBe(true);

        }

        [Then(@"I don't see the (.*) field error")]
        public void IDontSeetheFieldError(string fieldName)
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($".quote--content > tell-form .question:has(#{fieldName}) .question--input__error"))
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
                    (new JQuerySelector($".quote--content > tell-form .question .question--input__error"))
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
            var inputText = DateTime.Now
                .AddYears(-age)
                .AddDays(plusMinus == PlusMinus.plus ? -days : days)
                .ToString("dd/MM/yyyy");

            WebDriver
                .FindElement(new JQuerySelector($".quote--content > tell-form .question .question--input__text #{fieldName}"))
                .SendKeys(inputText);

            if (fieldName == "postcode")
            {
                ScenarioContext.Current.Add("quoteDOB", inputText);
                Thread.Sleep(2000);
            }

        }

        [Given(@"I go to the (.*) field and make the date today (.*) (.*) days")]
        [When(@"I go to the (.*) field and make the date today (.*) (.*) days")]
        public void IGoToTheFieldAndMakeTheDateTodayDays(string fieldName, PlusMinus plusMinus, int days)
        {

            var inputText = DateTime.Now
                .AddDays(plusMinus == PlusMinus.plus ? days : -days)
                .ToString("dd/MM/yyyy");

            WebDriver
                .FindElement(new JQuerySelector($".quote--content > tell-form .question .question--input__text #{fieldName}"))
                .SendKeys(inputText);
        }

        [When(@"I go to the (.*) field and look at the options available")]
        public void IGoToTheFieldAndLookAtTheOptionsAvailable(string fieldName)
        {
            WebDriver.ScrollToElement($"#{fieldName}");

            var possibleOptions = WebDriver
                .FindElements(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"));


            ScenarioContext.Current.Add(fieldName, possibleOptions.Select(e => e.Text));
        }

        [Given(@"I set the PartnerContext as (.*)")]
        public void ISetThePartnerContextAs(string withOrWithoutPartner)
        {
            ScenarioContext.Current.Add("PartnerContext", withOrWithoutPartner);
        }


        [Then(@"I see that the Progress Bar is at (.*) %")]
        public void ISeeThatTheProgressBarIsAt(string progressPercentage)
        {
            var percent = WebDriver
                .FindElement(new JQuerySelector($".quote--footer .progress .progress-bar")).GetAttribute("style");

            var regex = new Regex(@"(?<=width: )\d+");
            var actualProgress = regex.Matches(percent);


            var arr = Regex.Matches(percent, @"(?<=width: )\d+")
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();


            try
            {
                Assert.True(arr[0] == progressPercentage);
            }
            catch (Exception)
            {
                throw new Exception("Expected " + progressPercentage + "%, but got " + arr[0] + "%");
            }
        }

        [Then(@"I see that the (.*) options are as expected")]
        public void ThenISeeThatTheOptionsAreAsExpected(string fieldName)
        {
            var possibleOptions = ScenarioContext.Current.Get<IEnumerable<string>>(fieldName).ToList();
            var targetList = new List<string>();


            switch (fieldName)
            {
                case "insuredStatus":
                    targetList.Add("Please select");
                    targetList.Add("currently insured");
                    targetList.Add("not currently insured");
                    break;

                case "noOfClaimFreeYears":
                    targetList.Add("Select");
                    targetList.Add("0 years");
                    targetList.Add("1 year");
                    targetList.Add("2 years");
                    targetList.Add("3 years");
                    targetList.Add("4 years");
                    targetList.Add("5+ years");
                    break;

                case "noOfClaims":
                    targetList.Add("Select");
                    targetList.Add("no claims");
                    targetList.Add("1 claim");
                    targetList.Add("2 claims");
                    targetList.Add("3+ claims");
                    break;

                case "membersToInsure":
                    targetList.Add("Please select");
                    targetList.Add("just me");
                    targetList.Add("me and my kids");
                    targetList.Add("me and my partner");
                    targetList.Add("me, my partner and kids");
                    break;

                case "noOfChildren":
                    targetList.Add("Select");
                    targetList.Add("kid's");
                    targetList.Add("2 kids'");
                    targetList.Add("3 kids'");
                    targetList.Add("4 kids'");
                    if (ScenarioContext.Current.Get<string>("PartnerContext") == "NoPartner")
                    {
                        targetList.Add("5 kids'");
                    }
                    break;

                case "marketingPermission":
                    targetList.Add("Select");
                    targetList.Add("Agreed");
                    targetList.Add("Not Agreed");
                    break;
            }
            Assert.True(possibleOptions.CompareLists(targetList));
        }

        [Given(@"I see that the Progress Bar is not displayed")]
        [Then(@"I see that the Progress Bar is not displayed")]
        public void ISeeThatTheProgressBarIsNotDisplayed()
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($"quote--footer .progress .progress-bar"))
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

        [Given(@"I see that the quote and apply (.*) button is displayed")]
        [Then(@"I see that the quote and apply (.*) button is displayed")]
        public void ThenISeeThatTheQuoteAndApplyButtonIsDisplayed(string button)
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($".quote--footer .quote--footer__progress:has(button:contains('{button}'))"))
                    .ShouldNotBeNull();
            }
            catch (Exception)
            {
                Assert.True(false, ""+ button +" button not found");
            }
        }

        [Given(@"I click on the quote and apply (.*) button")]
        [When(@"I click on the quote and apply (.*) button")]
        [Then(@"I click on the quote and apply (.*) button")]
        public void ThenIClickOnTheQuoteAndApplyButton(string button)
        {
            try
            {
                WebDriver.FindElement
                    (new JQuerySelector($".quote--footer .quote--footer__progress:has(button:contains('{button}'))"))
                    .Click();
            }
            catch (Exception)
            {
                Assert.True(false, "" + button + " button not found");
            }
        }


        [Given(@"I go to the (.*) checkbox field and select the value")]
        [When(@"I go to the (.*) checkbox field and select the value")]
        public void GivenIGoToTheCheckboxFieldAndSelectTheValue(string checkbox)
        {
            try
            {
                WebDriver
                .ScrollToElement(
                    $@".quote--content > tell-form .question .question--checkbox-list li label:contains(""{checkbox}"")");

                WebDriver
                .FindElement(new JQuerySelector(
                    $".quote--content > tell-form .question .question--checkbox-list li label:contains('{checkbox}')"))
                .Click();
            }
            catch (Exception)
            {
                Assert.True(false, "" + checkbox + " multiselector not found");
            }
        }

        [Then(@"I expect the (.*) checkbox field to be disabled")]
        public void ThenIExpectTheCheckboxFieldToBeDisabled(string checkbox)
        {
            try
            {
                WebDriver
                .FindElement(new JQuerySelector(
                    $".quote--content > tell-form .question .checkbox-list li:contains('{checkbox}')"))
                    .GetAttribute("outerHTML")
                    .ShouldContain("disabled");
            }
            catch (Exception)
            {
                Assert.True(false, "multiselector" + checkbox + " is not disabled");
            }
        }


        [Then(@"I expect the quote result personalised greeting to contain the users first name")]
        public void ThenIExpectTheQuoteResultPersonalisedGreetingToContainTheUsersFirstName() => WebDriver
            .FindElement(new JQuerySelector(".ambassabanner--content h1"))
            .Text
            .ShouldContain(ScenarioContext.Current["quoteFirstName"].ToString());

        [Then(@"I expect the quote result personalised greeting image to be hidden")]
        public void ThenIExpectTheQuoteResultPersonalisedGreetingImageToBeHidden() => WebDriver
            .FindElement(new JQuerySelector(".ambassabanner--image img"))
            .Displayed
            .ShouldBeFalse();
    }
}
