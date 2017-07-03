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

            if (fieldName == "postcode")
            {
                Thread.Sleep(2000);
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
                    (new JQuerySelector($".quote--content > quoteapply-form .question #{fieldName}"));
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
            var inputText = DateTime.Now
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

            var inputText = DateTime.Now
                .AddDays(plusMinus == PlusMinus.plus ? days : -days)
                .ToString("dd/MM/yyyy");

            WebDriver
                .FindElement(new JQuerySelector($".quote--content > quoteapply-form .question .question--input__text #{fieldName}"))
                .SendKeys(inputText);
        }

        [When(@"I go to the (.*) field and look at the options available")]
        public void IGoToTheFieldAndLookAtTheOptionsAvailable(string fieldName)
        {
            WebDriver.ScrollToElement($"#{fieldName}");

            var possibleOptions = WebDriver
                .FindElements(new JQuerySelector($".quote--content > quoteapply-form .question #{fieldName} option"));


            ScenarioContext.Current.Add(fieldName, possibleOptions.Select(e => e.Text));
        }

        [Given(@"I set the PartnerContext as (.*)")]
        public void ISetThePartnerContextAs(string withOrWithoutPartner)
        {
            ScenarioContext.Current.Add("PartnerContext", withOrWithoutPartner);
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

    }
}
