namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Drawing;

    using Selenium.WebDriver.Extensions.JQuery;

    using Shouldly;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;
    using Vitality.Website.IntegrationTests.Utilities;

    using OpenQA.Selenium.Interactions;
    using By = OpenQA.Selenium.By;

    [Binding]
    public class MainNavigationSteps : BaseSteps
    {
        [When(@"I click on the (.*) section link")]
        public void WhenIClickOnTheSectionLink(string p0)
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.SITE_NAV + ":contains('" + p0 + "')"))
                .Click();
        }

        [When(@"I click on the navigation logo")]
        public void WhenIClickOnTheNavigationLogo()
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.NAV_LOGO))
                .Click();
        }

        [Then(@"I expect the (.*) to open")]
        public void ThenIExpectTheToOpen(string p0)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityBaseUrl + p0);
        }

        [When(@"I resize to mobile view")]
        public void WhenIResizeToMobileView()
        {
            WebDriver.Manage().Window.Size = new Size(320, 800);
        }

        [Then(@"I expect the hamburger to be visible")]
        public void ThenIExpectTheHamburgerToBeVisible()
        {
            WebDriver
                .WaitForElement(new JQuerySelector(Button.BURGER_MENU))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I resize to full-screen view")]
        public void WhenIResizeToFull_ScreenView()
        {
            WebDriver.Manage().Window.Maximize();
        }

        [Then(@"I expect the hamburger to be invisible")]
        public void ThenIExpectTheHamburgerToBeInvisible()
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.BURGER_MENU))
                .Displayed
                .ShouldBeFalse();
        }

        [When(@"I click on the Login \(small\) button")]
        public void WhenIClickOnTheLoginSmallButton()
        {
            WebDriver
                .WaitForElement(new JQuerySelector(Button.LOGIN_SMALL))
                .Click();
        }

        [When(@"I click on the Login \(large\) button")]
        public void WhenIClickOnTheLoginLargeButton()
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.LOGIN_LARGE))
                .Click();
        }

        [Then(@"I expect the Member Zone button to be visible")]
        public void ThenIExpectTheMemberZoneButtonToBeVisible()
        {
            WebDriver
                .WaitForElement(By.LinkText("Member Zone"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I expect the Health Advisers button to be visible")]
        public void ThenIExpectTheHealthAdvisersButtonToBeVisible()
        {
            WebDriver
                .WaitForElement(By.LinkText("Health Advisers"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I expect the Life Advisers button to be visible")]
        public void ThenIExpectTheLifeAdvisersButtonToBeVisible()
        {
            WebDriver
                .WaitForElement(By.LinkText("Life Advisers"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I click on the footer button")]
        public void WhenIClickOnTheFooterButton()
        {
            WebDriver
                .WaitForElement(new JQuerySelector(Button.FOOTER))
                .Click();
        }

        [Then(@"I expect the Health insurance quote button to be visible")]
        public void ThenIExpectTheHealthInsuranceQuoteButtonToBeVisible()
        {
            WebDriver
                .FindElement(By.LinkText("Health insurance quote"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I expect the Life insurance quote button to be visible")]
        public void ThenIExpectTheLifeInsuranceQuoteButtonToBeVisible()
        {
            WebDriver
                .WaitForElement(By.LinkText("Life insurance quote"))
                .Displayed
                .ShouldBeTrue();
        }


        [When(@"I hover over (.*) and click on (.*)")]
        public void WhenIHoverOver(string hoverLink, string clickLink)
        {
            var selector = ".section-nav .section-nav__item--megamenu:contains('" + hoverLink + "')";
            var sectionLink = WebDriver.FindElement(new JQuerySelector(selector));

            // Hover over the menu.
            new Actions(WebDriver)
                .MoveToElement(sectionLink)
                .Perform();

            // Wait for the submenu to appear.
            WebDriver.WaitForElement(By.ClassName("megamenu"));

            // Find and click the subsection.
            WebDriver
                .FindElement(new JQuerySelector(".megamenu a:contains('" + clickLink + "')"))
                .Click();
        }
    }
}
