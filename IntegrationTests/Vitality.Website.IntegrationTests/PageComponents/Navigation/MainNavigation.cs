namespace Vitality.Website.IntegrationTests.PageComponents.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using OpenQA.Selenium;

    using Selenium.WebDriver.Extensions.JQuery;

    public class MainNavigation
    {
        private readonly IWebElement webElement;
        private readonly IWebDriver webDriver;

        public MainNavigation(IWebElement webElement, IWebDriver webDriver)
        {
            this.webElement = webElement;
            this.webDriver = webDriver;
        }

        public MobileNavigation MobileNavigation
        {
            get
            {
                return new MobileNavigation(this.webDriver.FindElement(new JQuerySelector(".top-bar--small")), this.webDriver);
            }
        }

        public IEnumerable<NavigationSection> NavigationSections
        {
            get
            {
                return this.webDriver.FindElements(new JQuerySelector(".site-nav__item")).Select(e => new NavigationSection(e, this.webDriver));
            }
        }

        public IWebElement Logo
        {
            get
            {
                return this.webDriver.FindElement(new JQuerySelector(".section-nav__item--home a"));
            }
        }

        public IWebElement MemberZone
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

        public IWebElement LogInButton
        {
            get
            {
                return this.webDriver.FindElement(new JQuerySelector(".log-in__links a.box-button--secondary"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                return this.webDriver.FindElements(new JQuerySelector(".log-in--large a")).ElementAt(1);
            }
        }

        public IWebElement ForgottenDetailsButton
        {
            get
            {
                return this.webDriver.FindElement(new JQuerySelector(".log-in__forgotten a"));
            }
        }
    }
}
