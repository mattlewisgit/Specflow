using Selenium.WebDriver.Extensions.JQuery;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Vitality.Extensions.Selenium;

namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public sealed class CardsTabbedSteps : BaseSteps
    {
        [Then(@"I expect the correct CSS cards tabbed values to appear")]
        public void ThenIExpectTheCorrectCSSCardsTabbedValuesToAppear()
        {
            //Heading H2
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .spotlight__heading"))
                .Displayed
                .ShouldBeTrue();

            //Heading paragraph
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .spotlight__intro"))
                .Displayed
                .ShouldBeTrue();

            //Menu Bar
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .filter-list.js-filter-options .filter-list__item.js-filter-options__item.js-filter-options__item--default .js-focus"))
                .Displayed
                .ShouldBeTrue();

            //Cards background image
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content .spotlight-item__intro-image.burst"))
                .Displayed
                .ShouldBeTrue();

            //Cards logo image
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content .spotlight-item__logo a img"))
                .Displayed
                .ShouldBeTrue();

            //Cards H3
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content h3"))
                .Displayed
                .ShouldBeTrue();

            //Cards description
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content .spotlight-item__content"))
                .Displayed
                .ShouldBeTrue();

            //Cards CTA button
            WebDriver
                .FindElement(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__cta a"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I click on cards tabbed navigation menu (.*)")]
        public void WhenIClickOnCardsTabbedNavigationMenu(string navmenuname)
        {
            // Send a "scroll" to navigation menu containing ALL
            WebDriver
                .ScrollToElement(".cards-tabbed.spotlight .filter-list.js-filter-options .filter-list__item.js-filter-options__item.js-filter-options__item--default .js-focus");
            
            //Menu Bar - click on menu bar containing string.
            WebDriver
                .FindElement(new JQuerySelector(
                    $".cards-tabbed.spotlight .filter-list.js-filter-options .filter-list__item.js-filter-options__item a:contains('{navmenuname}')"))
                .Click();

        }

        [Then(@"I expect the cards tabbed partner (.*) to be displayed")]
        public void ThenIExpectTheCardsTabbedPartnerToBeDisplayed(string cardspartner)
        {
            // Send a "scroll" (required in mobile view as panels stack)
            WebDriver
                .ScrollToElement($@".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content:has(h3:contains(""{cardspartner}""))");

            // Find the H3 containing the text...
            var cardsTabbed = WebDriver
                .FindElements(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content h3"))
                .FirstOrDefault(e => e.Text.Equals(cardspartner));

            //Confirm that H3 contains partner card name
            cardsTabbed.Displayed.ShouldBeTrue();

        }

        [When(@"I click on the cards tabbed (.*) partner (.*) button link")]
        public void WhenIClickOnTheCardsTabbedPartnerButtonLink(string cardsPartner, string button)
        {
            // Send a "scroll" (required in mobile view as panels stack)
            WebDriver
                .ScrollToElement($@".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content:has(h3:contains(""{cardsPartner}""))");

            // Find the H3 containing the text...
            var cardsTabbedPartner = WebDriver
                .FindElements(new JQuerySelector(".cards-tabbed.spotlight .js-filtered-container .js-filtered-container__item .spotlight-item__top-content h3"))
                .FirstOrDefault(e => e.Text.Equals(cardsPartner));

            //Click on H3 partner cards parent.
            cardsTabbedPartner.GetParent()
                .Click();

        }

    }
}
