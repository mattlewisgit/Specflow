namespace Vitality.Website.IntegrationTests.PageComponents.Navigation
{
    using OpenQA.Selenium;

    public class NavigationSection
    {
        private readonly IWebElement webElement;

        public NavigationSection(IWebElement webElement)
        {
            this.webElement = webElement;
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
