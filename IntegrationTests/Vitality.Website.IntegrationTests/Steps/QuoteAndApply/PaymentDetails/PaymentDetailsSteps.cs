
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
                Thread.Sleep(5000);

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



            //WebDriver.Manage().Timeouts().ImplicitlyWait(250);

            //WebDriver.Manage().Timeouts().ImplicitlyWait(250, TimeUnit.MILLISECONDS);

            //var possibleOptions = WebDriver
            //    .FindElements(new JQuerySelector($".quote--content > tell-form .question #{fieldName} option"));

            //possibleOptions
            //    .FirstOrDefault(e => e.Text.Equals(option))
            //    .Click();
        }



    }
}
