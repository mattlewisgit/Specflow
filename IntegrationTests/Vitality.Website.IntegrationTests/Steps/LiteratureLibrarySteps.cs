using TechTalk.SpecFlow;

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


    [Binding]
    public sealed class LiteratureLibrarySteps : BaseSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef



        [When(@"I search for (.*) document")]
        public void WhenISearchForDocument(string p0)
        {
            // Click in the search box
            WebDriver.
                FindElement(By.CssSelector("input.tt-input"))
                .Click();
            // type in document name
            WebDriver.
                FindElement(By.CssSelector("input.tt-input"))
                .SendKeys(p0);
            // click on document name in drop down list
            WebDriver.
                FindElement(By.CssSelector("strong.tt-highlight")).
                Click();
        }


        [Then(@"I expect the download and email  buttons to be visible")]
        public void ThenIExpectTheDownloadAndEmailButtonsToBeVisible()
        {
            // Download button is visible
            WebDriver
                .WaitForElement(By.LinkText("Download"))
                .Displayed
                .ShouldBeTrue();

            // Email button is visible
            WebDriver
                .WaitForElement(By.LinkText("Email"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I expect the (.*) document to be visible")]
        public void ThenIExpectTheDocumentToBeVisible(string p0)
        {
            WebDriver
                .WaitForElement(By.LinkText(p0))
                .Displayed
                .ShouldBeTrue();
        }



        [When(@"I choose Literature Type (.*)")]
        public void WhenIChooseLiteratureType(string p0)
        {
            WebDriver
                .FindElement(By.LinkText(p0))
                .Click();
        }


        [When(@"I select on (.*) Literature")]
        public void WhenISelectOnLiterature(string p0)
        {
            WebDriver
                .FindElement(By.LinkText(p0))
                .Click();
        }


        [Given(@"I enter plan start date (.*) (.*) (.*)")]
        public void GivenIEnterPlanStartDate(string p0, string p1, string p2)
        {
            WebDriver
                .FindElement(By.Id("day"))
                .Clear();

            WebDriver
                .FindElement(By.Id("day"))
                .SendKeys(p0);

            WebDriver
                .FindElement(By.Id("month"))
                .Clear();

            WebDriver
                .FindElement(By.Id("month"))
                .SendKeys(p1);

            WebDriver
                .FindElement(By.Id("year"))
                .Clear();

            WebDriver
                .FindElement(By.Id("year"))
                .SendKeys(p2);
        }


        [When(@"click on the submit button")]
        public void WhenClickOnTheSubmitButton()
        {
            WebDriver
                .FindElement(By.XPath("//input[@value='Submit']"))
                .Click();
        }




    }
}
