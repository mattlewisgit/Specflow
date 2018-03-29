using Kingfisher.Website.IntegrationTests.Extensions;

namespace Vitality.Website.IntegrationTests.Steps.DIY.Fields
{
    using Kingfisher.Website.IntegrationTests.Steps;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using Selenium.WebDriver.Extensions.JQuery;
    using System;
    using System.Threading;
    using TechTalk.SpecFlow;
    using By = OpenQA.Selenium.By;

    [Binding]
    public sealed class MainNavigation : BaseSteps
    {

        [When(@"I hover over the main navigation (.*) and click on (.*)")]
        public void WhenIHoverOverTheMainNavigationAndClickOn(string hoverLink, string clickLink)
        {
            Thread.Sleep(3000);

            try
            {
                // Setup new Actions for mouseover events
                var actions = new Actions(WebDriver);

                // Find element called "hoverLink" and then perform a hover over
                var mainMenu = WebDriver.FindElement(By.LinkText(hoverLink));
                actions.MoveToElement(mainMenu).Perform();

                Thread.Sleep(3000);

                // Find element called "clickLink", perform a hover over, and then click it
                var subMenu = WebDriver.FindElement(By.LinkText(clickLink));
                actions.MoveToElement(subMenu).Perform();
                actions.Click().Perform();

            }
            catch (NoSuchElementException)
            {
                return;
            }
            catch (Exception)
            {
                throw new Exception("Unable to find navigation menu " + hoverLink + " or " + clickLink + "");
            }


        }

    }
}
