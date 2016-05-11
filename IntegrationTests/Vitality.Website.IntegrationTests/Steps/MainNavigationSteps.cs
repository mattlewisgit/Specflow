namespace Vitality.Website.IntegrationTests.Steps
{
    using Shouldly;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;
    using Vitality.Website.IntegrationTests.PageObjects;
    using Vitality.Website.IntegrationTests.Utilities;

    [Binding]
    public class MainNavigationSteps : BaseSteps
    {
        private readonly PresalesPage presalesPage;

        public MainNavigationSteps(PresalesPage presalesPage)
        {
            this.presalesPage = presalesPage;
        }

        [When(@"I click on the business section link")]
        public void WhenIClickOnTheBusinessSectionLink()
        {
            this.presalesPage.MainNavigation.ClickNavigationSectionLink("business");
        }
        
        [When(@"I click on the navigation logo")]
        public void WhenIClickOnTheNavigationLogo()
        {
            this.presalesPage.MainNavigation.Logo.Click();
        }
        
        [Then(@"I expect the (.*) to open")]
        public void ThenIExpectTheToOpen(string p0)
        {
            Browser.CurrentUrl.ShouldBe(p0);
        }

        [When(@"I resize to mobile view")]
        public void WhenIResizeToMobileView()
        {
            Browser.Resize(320, 800);
        }

        [Then(@"I expect the hamburger to be visible")]
        public void ThenIExpectTheHamburgerToBeVisible()
        {
            this.presalesPage.MainNavigation.MobileNavigation.BurgerMenu.ShouldNotBeNull();
        }
    }
}
