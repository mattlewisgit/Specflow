namespace Vitality.Website.IntegrationTests.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using System.Linq;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class WFFMSteps : BaseSteps
    {
        private string WebFormID = "wffmed8ddd1863744393b9623a3f0e6c373a_";


        [Given(@"I have entered web forms section (.*) and field (.*) text box (.*)")]
        public void GivenIHaveEnteredWebFormsSectionAndFieldTextBox(int section, int field, string text)
        {
            //Scroll to element.
            WebDriver.ScrollToElement($"#{WebFormID + "Sections_" + section + "__Fields_" + field + "__Value"}");

            // Enter text field.
            WebDriver
                .WaitForElement(By.Id(WebFormID + "Sections_" + section + "__Fields_" + field + "__Value"))
                .ClearAndContinue()
                .SendKeys(text);
        }

        [Given(@"I have entered web forms section (.*) and field (.*) date field (.*) (.*) (.*)")]
        public void GivenIHaveEnteredWebFormsSectionAndFieldDateField(int section, int field, string day, string month, string year)
        {
            //Scroll to element.
            WebDriver.ScrollToElement($"#{WebFormID + "Sections_" + section + "__Fields_" + field + "__Day"}");

            // Enter date field.
            //Select day.
            var possibleDays = new SelectElement(WebDriver
                .FindElement(By.Id(WebFormID + "Sections_" + section + "__Fields_" + field + "__Day")));

            possibleDays.SelectByText(day);

            // Enter date field.
            //Select month.
            var possibleMonth = new SelectElement(WebDriver
                .FindElement(By.Id(WebFormID + "Sections_" + section + "__Fields_" + field + "__Month")));

            possibleMonth.SelectByText(month);

            // Enter date field.
            //Select year.
            var possibleYear = new SelectElement(WebDriver
                .FindElement(By.Id(WebFormID + "Sections_" + section + "__Fields_" + field + "__Year")));

            possibleYear.SelectByText(year);
        }


        [Given(@"I have entered web forms section (.*) and field (.*) dropdown list (.*)")]
        public void GivenIHaveEnteredWebFormsSectionAndFieldDropdownList(int section, int field, string dropdown)
        {
            //Scroll to element.
            WebDriver.ScrollToElement($"#{WebFormID + "Sections_" + section + "__Fields_" + field + "__Value"}");

            // Enter date field.
            //Select year.
            var possibleYear = new SelectElement(WebDriver
                .FindElement(By.Id(WebFormID + "Sections_" + section + "__Fields_" + field + "__Value")));

            possibleYear.SelectByText(dropdown);
        }

        [Given(@"I have entered web forms section (.*) and field (.*) check box (.*)")]
        public void GivenIHaveEnteredWebFormsSectionAndFieldCheckBox(int section, int field, string Checkbox)
        {
            //Scroll to element.
            WebDriver.ScrollToElement($"#{WebFormID + "Sections_" + section + "__Fields_" + field + "__Value"}");

            // Check Box.
            WebDriver
                .FindElement(By.Id(WebFormID + "Sections_" + section + "__Fields_" + field + "__Value"))
                .Click();
        }

        [When(@"I click on webform (.*) button")]
        public void WhenIClickOnWebformButton(string button)
        {
            //Find button called button
            var test = WebDriver
                .FindElements(new JQuerySelector(".form-submit-border .btn.btn-default"))
                .FirstOrDefault(e => e.InnerElement.GetAttribute("value").Contains(button));

            //Click on button
            test.Click();
        }

        [Then(@"I expect the web forms (.*) message to appear")]
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
                .WaitForElement(new JQuerySelector(".qtip .qtip-content"))
                .GetAttribute("innerText")
                .ShouldContain(tooltip);
        }
    }
}
