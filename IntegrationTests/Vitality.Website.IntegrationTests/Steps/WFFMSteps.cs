namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Drawing;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Extensions;
    using Utilities;
    using OpenQA.Selenium.Interactions;
    using By = OpenQA.Selenium.By;
    using OpenQA.Selenium.Support.UI;
    using System;
    using OpenQA.Selenium;

    [Binding]
    public sealed class WFFMSteps : BaseSteps
    {

        [When(@"I enter the form details (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void WhenIEnterTheFormDetails(string FirstName, string LastName, string OtherName, string Email, string Phone, string Day, string Month, string Year, string DropList, string p9)
        {
            string WebFormID;
            WebFormID = "wffm6f9c146419a24306ad5b9a7db5e9b409_";

            //First Name
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_0__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_0__Value")).SendKeys(FirstName);

            //Last Name
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_1__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_1__Value")).SendKeys(LastName);

            //Other names
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_2__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_2__Value")).SendKeys(OtherName);

            //Email Address
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_3__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_3__Value")).SendKeys(Email);

            //Phone Number
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_4__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_4__Value")).SendKeys(Phone);

            //Date
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Day"))).SelectByText(Day);
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Month"))).SelectByText(Month);
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Year"))).SelectByText(Year);

            //Drop List
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_1__Fields_0__Value"))).SelectByText(DropList);

            //Check Box
            WebDriver.FindElement(By.Id(WebFormID + "Sections_1__Fields_1__Value")).Click();

        }



        [When(@"I click on the Submit button")]
        public void WhenIClickOnTheSubmitButton()
        {
            WebDriver
                .FindElement(By.XPath("//input[@value='Submit']"))
                .Click();
        }

        [Then(@"I expect the web forms '(.*)' message to appear")]
        public void ThenIExpectTheWebFormsMessageToAppear(string p0)
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".form.pinch" + ":contains('" + p0 + "')"))
                    .Displayed.ShouldBeTrue();
        }


        [Then(@"I expect the web forms mandatory error message to appear")]
        public void ThenIExpectTheWebFormsMandatoryErrorMessageToAppear()
        {
            WebDriver
                    .FindElement(new JQuerySelector(".required-field.form-group.has-feedback.has-error"))
                    .Displayed.ShouldBeTrue();
        }


        [When(@"I click on field (.*) tool tips")]
        public void WhenIClickOnFieldToolTips(string tooltipfield)
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".required-field.form-group.has-feedback .control-label:contains('" + tooltipfield + "') .tool-tip-icon.tool-tip-icon--inline button"))
                    .SendKeys(Keys.Space);


            WebDriver
                    .WaitForElement(new JQuerySelector(".required-field.form-group.has-feedback .control-label:contains('" + tooltipfield + "') .tool-tip-icon.tool-tip-icon--inline button"))
                    .Click();
        }


        [Then(@"I expect (.*) tool tips to be displayed")]
        public void ThenIExpectToolTipsToBeDisplayed(string tooltip)
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".qtip.qtip-default.qtip-pos-br.qtip-focus .qtip-content:contains('" + tooltip + "')"))
                    .Displayed
                    .ShouldBeTrue();
        }



    }
}
