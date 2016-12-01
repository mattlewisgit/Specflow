namespace Vitality.Website.IntegrationTests.PageComponents.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using OpenQA.Selenium;

    using Selenium.WebDriver.Extensions.JQuery;

    public class MainNavigation
    {
        private readonly IWebDriver webDriver;

        public MainNavigation(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MobileNavigation MobileNavigation
        {
            get
            {
                return new MobileNavigation(this.webDriver);
            }
        }

        public IEnumerable<NavigationSection> NavigationSections
        {
            get
            {
                return this.webDriver.FindElements(new JQuerySelector(".site-nav__item")).Select(e => new NavigationSection(e));
            }
        }

        public IWebElement Logo
        {
            get
            {
                return this.webDriver.FindElement(new JQuerySelector(".section-nav__item--home a"));
            }
        }



        public IWebElement LogIn
        {
            get
            {

                return this.webDriver.FindElement(new JQuerySelector(".top-bar--large .utility-nav__item--log-in"));
            }
        }


        public IEnumerable<IWebElement> LogInPanelLinks
        {
            get
            {
                return this.webDriver.FindElements(new JQuerySelector(".log-in--large a"));
            }
        }


        public IWebElement MemberZoneButton
        {
            get
            {
                return this.webDriver.FindElement(OpenQA.Selenium.By.LinkText("Member Zone"));
            }
        }


        public IWebElement HealthAdvisersButton
        {
            get
            {
                return this.webDriver.FindElement(OpenQA.Selenium.By.LinkText("Health Advisers"));
            }
        }

        public IWebElement LifeAdvisersButton
        {
            get
            {
                return this.webDriver.FindElement(OpenQA.Selenium.By.LinkText("Life Advisers"));
            }
        }

    }
}
