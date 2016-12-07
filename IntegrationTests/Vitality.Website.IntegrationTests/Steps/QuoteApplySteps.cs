namespace Vitality.Website.IntegrationTests.Steps
{
    using System;
    using TechTalk.SpecFlow;

    using Shouldly;

    using Vitality.Website.IntegrationTests.Extensions;
    using Vitality.Website.IntegrationTests.PageObjects;
    using Vitality.Website.IntegrationTests.Utilities;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;

    [Binding]
    public class QuoteApplySteps : BaseSteps
    {




        [When(@"I enter the about you quote details")]
        public void WhenIEnterTheAboutYouQuoteDetails()
        {
            new SelectElement(WebDriver.FindElement(By.Id("day"))).SelectByText("1");
            WebDriver.FindElement(By.CssSelector("#day > option[value=\"1\"]")).Click();
            new SelectElement(WebDriver.FindElement(By.Id("month"))).SelectByText("JAN");
            WebDriver.FindElement(By.CssSelector("#month > option[value=\"1\"]")).Click();
            new SelectElement(WebDriver.FindElement(By.Id("year"))).SelectByText("1980");
            WebDriver.FindElement(By.CssSelector("#year > option[value=\"1980\"]")).Click();
            WebDriver.FindElement(By.Id("PostCode")).SendKeys("SO53 3LQ");
            new SelectElement(WebDriver.FindElement(By.Id("Title"))).SelectByText("Mr");
            WebDriver.FindElement(By.CssSelector("option[value=\"Mr\"]")).Click();
            WebDriver.FindElement(By.Id("UserFirstName")).SendKeys("test");
            WebDriver.FindElement(By.Id("Userlastname")).SendKeys("ing");
            WebDriver.FindElement(By.Id("Email")).SendKeys("matt.lewis@vitality.co.uk");
            WebDriver.FindElement(By.Id("Phone")).SendKeys("02380 123123");
            WebDriver.FindElement(By.Id("M")).Click();
        }


        [When(@"click on the Now get a quote button")]
        public void WhenClickOnTheNowGetAQuoteButton()
        {
            //click on get a quote
            WebDriver.FindElement(By.Id("getquote")).Click();
        }


        [Then(@"when I personalise your plan")]
        public void ThenWhenIPersonaliseYourPlan()
        {
            WebDriver.FindElement(By.Id("apply-now")).Click();
        }


        [Then(@"when continue the quote summary")]
        public void ThenWhenContinueTheQuoteSummary()
        {
            WebDriver.FindElement(By.Id("confirm")).Click();
        }


        [Then(@"when I complete the medical questions")]
        public void ThenWhenICompleteTheMedicalQuestions()
        {
            WebDriver.FindElement(By.Id("No_1")).Click();
            WebDriver.FindElement(By.Id("No_2")).Click();
            WebDriver.FindElement(By.Id("No_3")).Click();
            WebDriver.FindElement(By.Id("apply_medical_continue")).Click();
            new SelectElement(WebDriver.FindElement(By.Id("addresses"))).SelectByText("1 HUT FARM PLACE, EASTLEIGH");

            WebDriver.FindElement(By.Name("BankDetails.AccountholderName")).Clear();
            WebDriver.FindElement(By.Name("BankDetails.AccountholderName")).SendKeys("acount name");
            WebDriver.FindElement(By.Id("accountnumber")).SendKeys("61333992");
            WebDriver.FindElement(By.Id("sortcode1")).Clear();
            WebDriver.FindElement(By.Id("sortcode1")).SendKeys("40");
            WebDriver.FindElement(By.Id("sortcode2")).Clear();
            WebDriver.FindElement(By.Id("sortcode2")).SendKeys("02");
            WebDriver.FindElement(By.Id("sortcode3")).Clear();
            WebDriver.FindElement(By.Id("sortcode3")).SendKeys("50");
            WebDriver.FindElement(By.Id("pay_now")).Click();
        }

        [Then(@"when I confirm payment now")]
        public void ThenWhenIConfirmPaymentNow()
        {
            WebDriver.FindElement(By.Id("pay_now")).Click();
        }


    }

}
