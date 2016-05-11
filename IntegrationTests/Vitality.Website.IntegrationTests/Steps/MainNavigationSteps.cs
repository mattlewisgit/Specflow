using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using System.Configuration;
using TechTalk.SpecFlow;
using Xunit;
using Selenium.WebDriver.Extensions.JQuery;
using By = Selenium.WebDriver.Extensions.JQuery.By;

namespace Vitality.Website.IntegrationTests
{
    [Binding]
    public class MainNavigationSteps
    {
        private FirefoxDriver driver;

        [Given(@"I am on the (.*)")]
        public void GivenIAmOnThe(string p0)
        {
            var url = ConfigurationManager.AppSettings["Links.VitalityBaseUrl"] + ConfigurationManager.AppSettings[p0];
            var ffBinary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\Firefox.exe");
            var firefoxProfile = new FirefoxProfile();

            driver = new FirefoxDriver(ffBinary, firefoxProfile);
            driver.Navigate().GoToUrl(p0);
        }

        [When(@"I click on the business section link")]
        public void WhenIClickOnTheBusinessSectionLink()
        {
            var navItems = driver.FindElements(By.JQuerySelector(".site-nav a"));
            var businessNavItem = navItems.FirstOrDefault(e => e.GetAttribute("href").Contains("business"));
            businessNavItem.Click();
        }
        
        [When(@"I click on the navigation logo")]
        public void WhenIClickOnTheNavigationLogo()
        {
            var navItem = driver.FindElement(By.JQuerySelector(".section-nav__item--home a"));
            navItem.Click();
        }
        
        [Then(@"I expect the (.*) to open")]
        public void ThenIExpectTheToOpen(string p0)
        {
            var expectedUrl = ConfigurationManager.AppSettings["Links.VitalityBaseUrl"] + ConfigurationManager.AppSettings[p0];
            Assert.Equal(p0, driver.Url);
        }

        [When(@"I resize to mobile view")]
        public void WhenIResizeToMobileView()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(320, 800);
        }

        [Then(@"I expect the hamburger to be visible")]
        public void ThenIExpectTheHamburgerToBeVisible()
        {
            var navItem = driver.FindElement(By.JQuerySelector(".burger-menu"));
            Assert.NotNull(navItem);
        }

    }
}
