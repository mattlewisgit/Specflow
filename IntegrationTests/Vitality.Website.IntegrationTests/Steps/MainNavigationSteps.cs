namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Utilities;
    using Vitality.Extensions.Selenium;
    using By = OpenQA.Selenium.By;

    [Binding]
    public class MainNavigationSteps : BaseSteps
    {
        private string buttonsize;

        [When(@"I click on the (.*) section link")]
        public void WhenIClickOnTheSectionLink(string link)
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.SITE_NAV + ":contains('" + link + "')"))
                .Click();

            WebDriver
                .WaitForPageLoad();
        }

        [When(@"I click on the navigation logo")]
        public void WhenIClickOnTheNavigationLogo()
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.NAV_LOGO))
                .Click();

            WebDriver
                .WaitForPageLoad();
        }

        [Then(@"I expect the presales (.*) to open")]
        public void ThenIExpectThePresalesToOpen(string link)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityPresalesUrl + link);
        }

        [Then(@"I expect the production presales (.*) to open")]
        public void ThenIExpectTheProductionPresalesToOpen(string link)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityPresalesProductionUrl + link);
        }

        [Then(@"I expect the advisers (.*) to open")]
        public void ThenIExpectTheAdvisersToOpen(string link)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityAdvisersUrl + link);
        }

        [Then(@"I expect the production advisers (.*) to open")]
        public void ThenIExpectTheProductionAdvisersToOpen(string link)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityAdvisersProductionUrl+ link);
        }

        [Given(@"I resize to mobile view")]
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


        [When(@"I click on Login (.*) button")]
        public void WhenIClickOnLoginButton(string button)
        {
            //If string equal 'large', then pass large button size
            if (button.Equals("large"))
            {
                buttonsize = Button.LOGIN_LARGE;
            }
            //If string equal 'small', then pass small button size
            if (button.Equals("small"))
            {
                buttonsize = Button.LOGIN_SMALL;
            }
            
            //Button size small or large
            WebDriver
                .WaitForElement(new JQuerySelector(buttonsize))
                .Click();

        }


        [Then(@"I expect the Navigation Login button (.*) to be visible")]
        public void ThenIExpectTheNavigationLoginButtonToBeVisible(string Buttonname)
        {
            WebDriver
                .WaitForElement(By.LinkText(Buttonname))
                .Displayed
                .ShouldBeTrue();
        }


        [When(@"I hover over (.*) and click on (.*)")]
        public void WhenIHoverOver(string hoverLink, string clickLink)
        {
            // At this time we will assume that this call always relates to items on the Section Navigation bar ...
            var sectionNav = WebDriver.FindElement(new JQuerySelector(Button.SECTION_NAV));

            // Setup new Actions attribute to simulate mouseover events
            var actions = new Actions(WebDriver);

            // Find element called "hoverLink" and then perform a hover over
            var mainMenu = WebDriver.FindElement(By.LinkText(hoverLink));
            actions.MoveToElement(mainMenu).Perform();

            // Having some problems with this bit, need to revisit with a better solution....
            Thread.Sleep(1000);

            // Find element called "clickLink", perform a hover over, and then click it
            var subMenu = WebDriver.FindElement(By.LinkText(clickLink));
            actions.MoveToElement(subMenu).Perform();
            actions.Click().Perform();

            // Having some problems with this bit, need to revisit with a better solution....
            Thread.Sleep(1000);
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
                .WaitForElement(By.LinkText("Health insurance quote"))
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

        [When(@"I expand the mobile footer section (.*)")]
        public void IExpandTheMobileFooterSection(string footerSection)
        {
            // Move down the page first.
            WebDriver
                .WaitForElement(new JQuerySelector(".page-footer .expander a:contains('" + footerSection + "')"))
                .SendKeys(Keys.Space);

            WebDriver.WaitForPageLoad();
        }

        [When(@"I click on the footer mobile link (.*)")]
        public void WhenIClickOnTheFooterMobileLink(string linkName)
        {
            WebDriver
                .WaitForElement(new JQuerySelector
                    (".page-footer .expander__content.is-active ul li a:contains('" + linkName + "')"))
                .Click();
        }

        [When(@"I click on the (.*) quote footer button")]
        public void WhenIClickOnTheQuoteFooterButton(string p0)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(".button-cta" + ":contains('" + p0 + "')"))
                .Click();
        }

        [Then(@"I should not see any console logs")]
        public void ThenIShouldNotSeeAnyConsoleLogs()
        {
            // Ensure there no console errors, other than JavaScript
            // deprecation warnings, and GTM-loaded tags, which we cannot control...
            WebDriver
                .Manage()
                .Logs
                .GetLog(LogType.Browser)
                .Where(l =>
                    !l.Message.Contains("cloudfront") &&
                    !l.Message.Contains("deprecated"))
                .ShouldBeEmpty();
        }
    }
}
