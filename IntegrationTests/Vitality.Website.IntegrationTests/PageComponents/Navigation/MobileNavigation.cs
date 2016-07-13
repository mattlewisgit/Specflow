namespace Vitality.Website.IntegrationTests.PageComponents.Navigation
{
    using OpenQA.Selenium;

    using Selenium.WebDriver.Extensions.JQuery;

    public class MobileNavigation
    {
        private readonly IWebElement webElement;
        private readonly IWebDriver webDriver;

        public MobileNavigation(IWebElement webElement, IWebDriver webDriver)
        {
            this.webElement = webElement;
            this.webDriver = webDriver;
        }

        public IWebElement BurgerMenu
        {
            get
            {
                return this.webDriver.FindElement(new JQuerySelector(".burger-menu"));
            }
        }
    }
}
