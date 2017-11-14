
namespace Vitality.Website.IntegrationTests.Steps.QuoteAndApply.PaymentDetails
{
    using System.Linq;
    using TechTalk.SpecFlow;
    using Selenium.WebDriver.Extensions.JQuery;
    using OpenQA.Selenium;
    using System;
    using Xunit;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;
    using Shouldly;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class PaymentDetailsSteps : BaseSteps
    {

        [When(@"I go to the button field and click on the button (.*)")]
        public void WhenIGoToTheFieldAndClickOnTheButton(string buttonName)
        {

            try
            {
                var findAddressButton = WebDriver
                   .FindElements(new JQuerySelector(".ok-btn"))
                   .FirstOrDefault(e => e.Text.Equals(buttonName));

                findAddressButton
                    .Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false, "" + buttonName + " button not found");
            }

        }

        [When(@"I go to the (.*) field and I choose the dropdown (.*)")]
        public void WhenIGoToTheFieldAndIChooseTheDropdown(string fieldName, string option)
        {

            try
            {
                //Need to implement Thread.Sleep in a better way.
                Thread.Sleep(10000);

                var findAddressList = WebDriver
                   .FindElements(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"))
                   .FirstOrDefault(e => e.Text.Equals(option));

                findAddressList
                    .Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false, "" + option + " dropdown option cannot be selected");
            }

        }


        [When(@"I enter the postal address manually and click on (.*)")]
        public void WhenIEnterThePostalAddressManuallyAndClickOn(string manualAddress)
        {
            try
            {
                WebDriver
                    .FindElement(new JQuerySelector($@".question--input__rich-text:contains(""{manualAddress}"")"))
                    .Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false, "" + manualAddress + " manual address link not found");
            }
        }


        [Then(@"I expect the postal address (.*) to be visible")]
        public void ThenIExpectThePostalAddressToBeVisible(string fieldName)
        {
            try
            {
                WebDriver
                   .FindElement(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"))
                   .Displayed
                   .ShouldBeTrue();


            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false, "" + fieldName + " manual address field is not visible");
            }
        }


        [Then(@"I expect the (.*) field to autopopulate with the correct information")]
        public void ThenIExpectTheFieldToAutopopulateWithTheCorrectInformation(string fieldName)
        {
            WebDriver.WaitForAngular();

            try
            {
                WebDriver
                    .FindElement(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"))
                    .Text
                    .Equals(ScenarioContext.Current[$"quote{fieldName}"].ToString());
            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.True(false, "" + fieldName + " does not match quote and apply" + (ScenarioContext.Current[$"quote{fieldName}"].ToString()) + "");
            }
        }

    }
}
