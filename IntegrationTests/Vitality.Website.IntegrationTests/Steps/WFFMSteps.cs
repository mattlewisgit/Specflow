namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class WFFMSteps : BaseSteps
    {

        [When(@"I enter the form details (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void WhenIEnterTheFormDetails(string Firstname, string Lastname, string Othername, string Email, string Phone, string Day, string Month, string Year, string Droplist)
        {
            const string WebFormID = "wffm6f9c146419a24306ad5b9a7db5e9b409_";

            // First Name.
            WebDriver
                .FindElement(By.Id(WebFormID + "Sections_0__Fields_0__Value"))
                .ClearAndContinue()
                .SendKeys(Firstname);

            // Last Name.
            WebDriver
                .FindElement(By.Id(WebFormID + "Sections_0__Fields_1__Value"))
                .ClearAndContinue()
                .SendKeys(Lastname);

            // Other names.
            WebDriver
                .FindElement(By.Id(WebFormID + "Sections_0__Fields_2__Value"))
                .ClearAndContinue()
                .SendKeys(Othername);

            // Email Address.
            WebDriver
                .FindElement(By.Id(WebFormID + "Sections_0__Fields_3__Value"))
                .ClearAndContinue()
                .SendKeys(Email);

            // Phone Number.
            WebDriver
                .FindElement(By.Id(WebFormID + "Sections_0__Fields_4__Value"))
                .ClearAndContinue()
                .SendKeys(Phone);

            // Date.
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Day"))).SelectByText(Day);
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Month"))).SelectByText(Month);
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_0__Fields_5__Year"))).SelectByText(Year);

            // Drop List.
            new SelectElement(WebDriver.FindElement(By.Id(WebFormID + "Sections_1__Fields_0__Value"))).SelectByText(Droplist);

            // Check Box.
            WebDriver.FindElement(By.Id(WebFormID + "Sections_1__Fields_1__Value")).Click();
        }

        [When(@"I click on webform (.*) button")]
        public void WhenIClickOnWebformButton(string button)
        {
            WebDriver
                .FindElement(new JQuerySelector(".form-submit-border .btn.btn-default"))
                .Click();
        }

        [Then(@"I expect the web forms '(.*)' message to appear")]
        public void ThenIExpectTheWebFormsMessageToAppear(string SuccessMessage)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(".form.pinch" + ":contains('" + SuccessMessage + "')"))
                .Displayed.ShouldBeTrue();
        }

        [Then(@"I expect the web forms (.*) error message to appear")]
        public void ThenIExpectTheWebFormsErrorMessageToAppear(string ErrorMessage)
        {
            WebDriver
                .WaitForElement(new JQuerySelector
                    (".required-field.form-group.has-error .field-validation-error.help-block"))
                .GetAttribute("innerHTML")
                .ShouldContain(ErrorMessage);
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
