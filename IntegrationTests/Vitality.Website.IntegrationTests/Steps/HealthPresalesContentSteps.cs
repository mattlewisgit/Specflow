namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using TechTalk.SpecFlow;
    using OpenQA.Selenium;
    using Xunit;
    using OpenQA.Selenium.Interactions;
    using System.Drawing;
    using By = OpenQA.Selenium.By;
    using Extensions;
    using Shouldly;
    using System.Threading;

    [Binding]
    public class HealthPresalesContentSteps : BaseSteps
    {

        [When(@"I go to the (.*) feature block and I click on the (.*) page link")]
        public void WhenIGoToTheFeatureBlockAndIClickOnThePageLink(string featureName, string linkName)
        {
            WebDriver
                .FindElement(new JQuerySelector(".feature-block__content:has(h2:contains('" + featureName + "'))"));
                    
            WebDriver
                .FindElement(new JQuerySelector(".feature-block__content:has(h2:contains('" + featureName + "')) a:contains('" + linkName + "')"))
                .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

            actions
                .SendKeys(Keys.Enter)
                .Perform();
        }


        [When(@"I go to the (.*) cards stacked and I click on the (.*) page link")]
        public void WhenIGoToTheCardsStackedAndIClickOnThePageLink(string cardStackedName, string linkName)
        {
            WebDriver
                .FindElement(new JQuerySelector(".cards-stacked .spotlight__list-item:has(h3:contains('" + cardStackedName + "'))"));

            WebDriver
                .FindElement(new JQuerySelector(".cards-stacked .spotlight__list-item:has(h3:contains('" + cardStackedName + "')) a:contains('" + linkName + "')"))
                .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

            actions
                .SendKeys(Keys.Enter)
                .Perform();
        }


        [When(@"I go to the (.*) cta and I click on the (.*) page link")]
        public void WhenIGoToTheCtaAndIClickOnThePageLink(string ctaName, string linkName)
        {
            WebDriver
               .FindElement(new JQuerySelector(".cta .grid-module:contains('" + ctaName + "')"));

            WebDriver
               .FindElement(new JQuerySelector(".cta .grid-module:contains('" + ctaName + "') a:contains('" + linkName + "')"))
               .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

            actions
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }


        [When(@"I go to the (.*) Cards Tabbed and I click on the (.*) page link")]
        public void WhenIGoToTheCardsTabbedAndIClickOnThePageLink(string CardsTabbed, string linkName)
        {
            WebDriver
   .FindElement(new JQuerySelector(".cards-tabbed .spotlight__list-item:contains('" + CardsTabbed + "')"));

            WebDriver
               .FindElement(new JQuerySelector(".cards-tabbed .spotlight__list-item:contains('" + CardsTabbed + "') a:contains('" + linkName + "')"))
               .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

            actions
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }


        [Then(@"I go to the (.*) Rich Text and I click on the (.*) page link")]
        public void ThenIGoToTheRichTextAndIClickOnThePageLink(string richtext, string text)
        {
            WebDriver
                .FindElement(By.LinkText(text))
                .Click();
        }




        [When(@"I go to the (.*) product component and I click on the (.*) page link")]
        public void WhenIGoToTheProductComponentAndIClickOnThePageLink(string ProductComponent, string LinkName)
        {
            WebDriver
               .FindElement(new JQuerySelector(".products-component .products-component--panel:contains('" + ProductComponent + "')"));

            WebDriver
               .FindElement(new JQuerySelector(".products-component .products-component--panel:contains('" + ProductComponent + "') a:contains('" + LinkName + "')"))
               .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

            actions
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }




        [When(@"I go to the global footer (.*) and I click on the (.*) page link")]
        public void WhenIGoToTheGlobalFooterAndIClickOnThePageLink(string GlobalFooter, string LinkName)
        {
            WebDriver
               .FindElement(new JQuerySelector(".page-footer__quote:contains('" + GlobalFooter + "')"));

            WebDriver
               .FindElement(new JQuerySelector(".page-footer__quote:contains('" + GlobalFooter + "') a:contains('" + LinkName + "')"))
               .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

            actions
                .SendKeys(Keys.Enter)
                .Perform();

            WebDriver.WaitForPageLoad();
        }




        [When(@"I click on the (.*) page link")]
        public void WhenIClickOnThePageLink(string linkName)
        {
            // Force a scroll to by using the Keys.Space in case the object is not visible
            WebDriver
                .FindElement(By.LinkText(linkName))
                .SendKeys(Keys.Space);

            Actions actions = new Actions(WebDriver);

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
            //Assert.StartsWith(pageName, WebDriver.Url);

            WebDriver
              .WaitForPageLoad()
              .Url
              .StartsWith(pageName);
        }
    }
}
