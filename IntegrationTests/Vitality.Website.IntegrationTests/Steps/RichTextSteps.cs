namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class RichTextSteps :BaseSteps
    {
        [When(@"I click on the rich text dialog (.*) link")]
        public void WhenIClickOnTheRichTextDialogLink(string DialogLink)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(".grid-col-12-12 a:contains('" + DialogLink + "')"))
                .Click();
        }

        [Then(@"I expect the dialog pop up box to appear")]
        public void ThenIExpectTheDialogPopUpBoxToAppear()
        {
            //Check lightbox is visible
            WebDriver
                .WaitForElement(new JQuerySelector
                    (".featherlight-content .hidden-dialogue-box-content.featherlight-inner"))
                .Displayed
                .ShouldBeTrue();

            // Check close icon is visible.
            WebDriver
                .WaitForElement(new JQuerySelector("span.featherlight-close-icon.featherlight-close"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I click on the close dialog box")]
        public void ThenIClickOnTheCloseDialogBox()
        {
            WebDriver
                .WaitForElement(new JQuerySelector("span.featherlight-close-icon.featherlight-close"))
                .Click();
        }


        [Then(@"I expect the correct CSS Card Snippet values to appear")]
        public void ThenIExpectTheCorrectCSSCardSnippetValuesToAppear()
        {
            //Card snippet.

            //Card snippet image.
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 .grid-col-4-12.text-center .spotlight .spotlight__list-item.spotlight__standalone .spotlight-item .spotlight-item__top-content .spotlight-item__intro-image.burst img"))
                .Displayed
                .ShouldBeTrue();

            //Card snippet heading.
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 .grid-col-4-12.text-center .spotlight .spotlight__list-item.spotlight__standalone .spotlight-item .spotlight-item__top-content .spotlight-item__heading"))
                .Displayed
                .ShouldBeTrue();

            //Card snippet paragraph.
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 .grid-col-4-12.text-center .spotlight .spotlight__list-item.spotlight__standalone .spotlight-item .spotlight-item__top-content .spotlight-item__content p"))
                .Displayed
                .ShouldBeTrue();

            //Card snippet 
            WebDriver
                .WaitForElement(new JQuerySelector(".grid .grid-col-12-12 .grid-col-4-12.text-center .spotlight .spotlight__list-item.spotlight__standalone .spotlight-item .spotlight-item__cta a"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I click on the rich text card snippet (.*) link")]
        public void WhenIClickOnTheRichTextCardSnippetLink(string button)
        {
            //Send scroll to button
            WebDriver
                .ScrollToElement($@".grid .grid-col-12-12 .grid-col-4-12.text-center .spotlight .spotlight__list-item.spotlight__standalone .spotlight-item .spotlight-item__cta:has(a:contains(""{button}""))");
            
            //Identify button
            var buttonSelector = new JQuerySelector($".grid .grid-col-12-12 .grid-col-4-12.text-center .spotlight .spotlight__list-item.spotlight__standalone .spotlight-item .spotlight-item__cta a:contains('{button}')");

            //Click on button.
            WebDriver
                .WaitForElement(buttonSelector)
                .Click();
        }

    }
}
