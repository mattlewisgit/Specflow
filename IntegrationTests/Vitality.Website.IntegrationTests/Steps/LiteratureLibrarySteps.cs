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
            // DOWNLOAD button is visible.
            WebDriver
                .WaitForElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Download')"))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Download')"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(91, 182, 177, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Download')"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");


            // EMAIL button is visible.
            WebDriver
                .WaitForElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Email')"))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Email')"))
                .GetCssValue("background-color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            WebDriver
                .FindElement(new JQuerySelector(".preview-card.ng-scope .preview-card--body__buttons div a:contains('Email')"))
                .GetCssValue("color")
                .ShouldBe("rgba(91, 182, 177, 1)");
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
        public void IChooseLiteratureType(string literaturetype)
        {
            //Click on Literature type
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-4-12.ng-scope .list--buttons .ng-scope a:contains('" + literaturetype + "')"))
                .Click();

            //Check arrow icon appears on Literature type
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-4-12.ng-scope .list--buttons .ng-scope .button-list.ng-binding.button-list--selected"))
                .Displayed.ShouldBeTrue();
        }

        [When(@"I select on (.*) Literature")]
        public void ISelectOnLiterature(string AvailableLiterature)
        {
            //Click on Available Literature
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-4-12.ng-scope .list--buttons .ng-scope a:contains('" + AvailableLiterature + "')"))
                .Click();

            //Check arrow icon appears on available literature
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-4-12.ng-scope .list--buttons .ng-scope .button-list.ng-binding.button-list--selected"))
                .Displayed.ShouldBeTrue();
        }

        [Given(@"I enter plan start date (.*) (.*) (.*)")]
        public void IEnterPlanStartDate(string day, string month, string year)
        {
            WebDriver
                .FindElement(By.Id("day"))
                .ClearAndContinue()
                .SendKeys(day);

            WebDriver
                .FindElement(By.Id("month"))
                .ClearAndContinue()
                .SendKeys(month);

            WebDriver
                .FindElement(By.Id("year"))
                .ClearAndContinue()
                .SendKeys(year);
        }

        [When(@"click on the submit button")]
        public void ClickOnTheSubmitButton()
        {
            WebDriver
                .FindElement(By.XPath("//input[@value='Submit']"))
                .Click();
        }


        [When(@"I click on literature library card snippet (.*) link")]
        public void WhenIClickOnLiteratureLibraryCardSnippetLink(string cardsnippetlink)
        {
            //check cards snipper generic image appears
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-4-12.tablet-and-up .spotlight__list-item.spotlight__standalone .spotlight-item__top-content .spotlight-item__intro-image.burst img"))
                .Displayed.ShouldBeTrue();

            //Clicks on link in the card snippet - not included string and left it generic
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-4-12.tablet-and-up .spotlight__list-item.spotlight__standalone .spotlight-item__cta a"))
                .Click();
        }

    }
}
