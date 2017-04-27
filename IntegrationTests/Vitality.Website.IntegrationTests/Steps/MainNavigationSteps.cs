namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Drawing;

    using Selenium.WebDriver.Extensions.JQuery;

    using Shouldly;

    using TechTalk.SpecFlow;

    using System.Threading;

    using Extensions;
    using Utilities;

    using OpenQA.Selenium.Interactions;
    using By = OpenQA.Selenium.By;
    using OpenQA.Selenium;
    using System.Linq;

    [Binding]
    public class MainNavigationSteps : BaseSteps
    {
        [When(@"I click on the (.*) section link")]
        public void WhenIClickOnTheSectionLink(string p0)
        {
            WebDriver
                .FindElement(new JQuerySelector(Button.SITE_NAV + ":contains('" + p0 + "')"))
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
        public void ThenIExpectThePresalesToOpen(string p0)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityPresalesUrl + p0);
        }


        [Then(@"I expect the production presales (.*) to open")]
        public void ThenIExpectTheProductionPresalesToOpen(string p0)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityPresalesProductionUrl + p0);
        }


        [Then(@"I expect the advisers (.*) to open")]
        public void ThenIExpectTheAdvisersToOpen(string p0)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityAdvisersUrl + p0);
        }


        [Then(@"I expect the production advisers (.*) to open")]
        public void ThenIExpectTheProductionAdvisersToOpen(string p0)
        {
            WebDriver
                .WaitForPageLoad()
                .Url
                .ShouldBe(AppSettings.Links.VitalityAdvisersProductionUrl+ p0);
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
                .FindElement(By.LinkText("Health Advisers"))
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


        [When(@"I hover over (.*) and click on (.*)")]
        public void WhenIHoverOver(string hoverLink, string clickLink)
        {
            // At this time we will assume that this call always relates to items on the Section Navigation bar ...
            var sectionNav = WebDriver.FindElement(new JQuerySelector(Button.SECTION_NAV));

            // Setup new Actions attribute to simulate mouseover events
            Actions actions = new Actions(WebDriver);
            
            // Find element called "hoverLink" and then perform a hover over
            var mainMenu = WebDriver.FindElement(OpenQA.Selenium.By.LinkText(hoverLink));
            actions.MoveToElement(mainMenu).Perform();
            
            // Having some problems with this bit, need to revisit with a better solution....
            Thread.Sleep(1000);

            // Find element called "clickLink", perform a hover over, and then click it
            var subMenu = WebDriver.FindElement(OpenQA.Selenium.By.LinkText(clickLink));
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


            //Move down the page first
            WebDriver
                .WaitForElement(new JQuerySelector(".page-footer .expander a:contains('" + footerSection + "')"))
                .SendKeys(Keys.Space);

            //Actions actions = new Actions(WebDriver);

            //actions
            //    .SendKeys(Keys.Enter)
            //    .Perform();

            WebDriver.WaitForPageLoad();

        }


        [When(@"I click on the footer mobile link (.*)")]
        public void WhenIClickOnTheFooterMobileLink(string linkName)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(".page-footer .expander__content.is-active ul li a:contains('" + linkName + "')"))
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
