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

    [Binding]
    public sealed class WFFMSteps : BaseSteps
    {

        [When(@"I enter the form details (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void WhenIEnterTheFormDetails(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9)
        {
            string WebFormID;
            WebFormID = "wffm6f9c146419a24306ad5b9a7db5e9b409_";

            //First Name
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_0__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_0__Value")).SendKeys(p0);

            //Last Name
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_1__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_1__Value")).SendKeys(p1);

            //Other names
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_2__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_2__Value")).SendKeys(p2);

            //Email Address
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_3__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_3__Value")).SendKeys(p3);

            //Phone Number
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_4__Value")).Clear();
            WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_4__Value")).SendKeys(p4);

            //Date
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Day"))).SelectByText(p5);
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Month"))).SelectByText(p6);
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Year"))).SelectByText(p7);

            //Drop List
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_1__Fields_0__Value"))).SelectByText(p8);

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


    }
}
