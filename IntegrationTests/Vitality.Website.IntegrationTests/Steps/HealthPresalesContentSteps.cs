namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using Shouldly;
    using Selenium.WebDriver.Extensions.JQuery;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public class HealthPresalesContentSteps : BaseSteps
    {
        [When(@"I go to the (.*) feature block and I click on the (.*) page link")]
        public void WhenIGoToTheFeatureBlockAndIClickOnThePageLink(string featureName, string linkName)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $".feature-block__content:has(h2:contains('{featureName}')) a:contains('{linkName}')"))
                .SendKeys(Keys.Space);

            new Actions(WebDriver)
                .SendKeys(Keys.Enter)
                .Perform();
        }

        [When(@"I go to the (.*) cards stacked and I click on the (.*) page link")]
        public void WhenIGoToTheCardsStackedAndIClickOnThePageLink
            (string cardStackedName, string linkName)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $".cards-stacked li:has(h3:contains('{cardStackedName}')) a:contains('{linkName}')"))
                .SendKeys(Keys.Space);

            new Actions(WebDriver)
                .SendKeys(Keys.Enter)
                .Perform();
        }

        [When(@"I go to the (.*) cta and I click on the (.*) page link")]
        public void WhenIGoToTheCtaAndIClickOnThePageLink(string ctaName, string linkName)
        {
            WebDriver
                .FindElement(new JQuerySelector
                    ($".cta .grid-module:contains('{ctaName}') a:contains('{linkName}')"))
                .SendKeys(Keys.Space);

            new Actions(WebDriver)
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }

        [When(@"I go to the (.*) Cards Tabbed and I click on the (.*) page link")]
        public void WhenIGoToTheCardsTabbedAndIClickOnThePageLink(string cardsTabbed, string linkName)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $".cards-tabbed .spotlight__list-item:contains(${cardsTabbed}') a:contains('{linkName}')"))
                .SendKeys(Keys.Space);

            new Actions(WebDriver)
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }

        [Then(@"I go to the (.*) Rich Text and I click on the (.*) page link")]
        public void ThenIGoToTheRichTextAndIClickOnThePageLink(string richText, string text)
        {
            WebDriver
                .FindElement(By.LinkText(text))
                .Click();
        }

        [When(@"I go to the (.*) product component and I click on the (.*) page link")]
        public void WhenIGoToTheProductComponentAndIClickOnThePageLink
            (string productComponent, string linkName)
        {
            WebDriver.FindElement(new JQuerySelector
                ($".products-component .products-component--panel:contains('${productComponent}')"));

            WebDriver
                .FindElement(new JQuerySelector($".products-component .products-component--panel:contains('${productComponent}') a:contains('${linkName}')"))
                .SendKeys(Keys.Space);

            new Actions(WebDriver)
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }

        [When(@"I go to the global footer (.*) and I click on the (.*) page link")]
        public void WhenIGoToTheGlobalFooterAndIClickOnThePageLink(string globalFooter, string linkName)
        {
            WebDriver.FindElement(new JQuerySelector
                (".page-footer__quote:contains('" + globalFooter + "')"));

            WebDriver
                .FindElement(new JQuerySelector
                    (".page-footer__quote:contains('" + globalFooter + "') a:contains('" + linkName + "')"))
                .SendKeys(Keys.Space);

            new Actions(WebDriver)
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }

        [When(@"I click on the (.*) page link")]
        public void WhenIClickOnThePageLink(string linkName)
        {
            // Force a scroll to by using the Keys.Space in case the object is not visible.
            WebDriver
                .FindElement(By.LinkText(linkName))
                .SendKeys(Keys.Space);

            var actions = new Actions(WebDriver);

            // As it is in focus, send Enter rather than click...
            actions
                .SendKeys(Keys.Enter)
                .Perform();

            // Pause for page to load....
            Thread.Sleep(1000);
        }

        [Then(@"I see the (.*) page")]
        public void ThenISeeThePage(string pageName)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .Contains(pageName)
                .ShouldBeTrue();
        }
    }
}
