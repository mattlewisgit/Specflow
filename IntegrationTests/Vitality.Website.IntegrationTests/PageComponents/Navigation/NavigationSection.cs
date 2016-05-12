namespace Vitality.Website.IntegrationTests.PageComponents.Navigation
{
    using OpenQA.Selenium;

    public class NavigationSection
    {
        private readonly IWebElement webElement;
        private readonly IWebDriver webDriver;

        public NavigationSection(IWebElement webElement, IWebDriver webDriver)
        {
            this.webElement = webElement;
            this.webDriver = webDriver;
        }

        public IWebElement SectionLink
        {
            get
            {
                return this.webElement.FindElement(By.TagName("a"));
            }
        }
    }
}
