namespace Vitality.Website.IntegrationTests.PageObjects
{
    using OpenQA.Selenium;

    using Vitality.Website.IntegrationTests.PageComponents.Navigation;

    public class PresalesPage
    {
        private readonly IWebDriver webDriver;

        public PresalesPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MainNavigation MainNavigation
        {
            get
            {
                return new MainNavigation(this.webDriver);
            }
        }
    }
}
