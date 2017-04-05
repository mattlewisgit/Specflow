namespace Vitality.Website.IntegrationTests.Steps
{
    using Shouldly;
    using TechTalk.SpecFlow;
    using Extensions;
    using By = OpenQA.Selenium.By;
    using Selenium.WebDriver.Extensions.JQuery;

    [Binding]
    public sealed class LiteratureLibrarySteps : BaseSteps
    {
        [When(@"I search for (.*) document")]
        public void ISearchForDocument(string p0)
        {
            // Click in the search box and type the document name.
            WebDriver.
                FindElement(By.CssSelector("input.tt-input"))
                .ClickAndContinue()
                .SendKeys(p0);
            
            // Click on the document name in the drop down list.
            WebDriver.
                FindElement(By.CssSelector("strong.tt-highlight")).
                Click();
        }

        [Then(@"I expect the download and email buttons to be visible")]
        public void IExpectTheDownloadAndEmailButtonsToBeVisible()
        {
            // Download button is visible.
            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Download')"))
                .Displayed
                .ShouldBeTrue();

            // Email button is visible.
            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Email')"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I expect the (.*) document to be visible")]
        public void IExpectTheDocumentToBeVisible(string Selection)
        {
            //Check your selection contains String
            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--header.ng-binding:contains('" + Selection + "')"))
                .Displayed
                .ShouldBeTrue();

        }

        [When(@"I choose Literature Type (.*)")]
        public void IChooseLiteratureType(string p0)
        {
            WebDriver
                .WaitForElement(By.LinkText(p0))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(By.LinkText(p0))
                .Click();
        }

        [When(@"I select on (.*) Literature")]
        public void ISelectOnLiterature(string p0)
        {
            WebDriver
                .FindElement(By.LinkText(p0))
                .Click();
        }

        [Given(@"I enter plan start date (.*) (.*) (.*)")]
        public void IEnterPlanStartDate(string p0, string p1, string p2)
        {
            WebDriver
                .FindElement(By.Id("day"))
                .ClearAndContinue()
                .SendKeys(p0);

            WebDriver
                .FindElement(By.Id("month"))
                .ClearAndContinue()
                .SendKeys(p1);

            WebDriver
                .FindElement(By.Id("year"))
                .ClearAndContinue()
                .SendKeys(p2);
        }

        [When(@"click on the submit button")]
        public void ClickOnTheSubmitButton()
        {
            WebDriver
                .FindElement(By.XPath("//input[@value='Submit']"))
                .Click();
        }
    }
}
