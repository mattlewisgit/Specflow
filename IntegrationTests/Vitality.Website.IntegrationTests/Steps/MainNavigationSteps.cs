namespace Vitality.Website.IntegrationTests.Steps
{
    using System;

    using Selenium.WebDriver.Extensions.JQuery;

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
            var expected = AppSettings.Links.VitalityBaseUrl + p0;
            Browser.CurrentUrl.ShouldBe(expected);
        }

        [When(@"I resize to mobile view")]
        public void WhenIResizeToMobileView()
        {
            Browser.Resize(320, 800).Wait(TimeSpan.FromMilliseconds(50));
        }

        [Then(@"I expect the hamburger to be visible")]
        public void ThenIExpectTheHamburgerToBeVisible()
        {
            WebDriver
                .FindElement(new JQuerySelector(".site-nav__item .burger-menu"))
                .Displayed
                .ShouldBeTrue();

            this.presalesPage.MainNavigation.MobileNavigation.BurgerMenu.Displayed.ShouldBeTrue();
        }

        [When(@"I resize to full-screen view")]
        public void WhenIResizeToFull_ScreenView()
        {
            Browser.Maximise();
        }

        [Then(@"I expect the hamburger to be invisible")]
        public void ThenIExpectTheHamburgerToBeInvisible()
        {
            WebDriver
                .FindElement(new JQuerySelector(".site-nav__item .burger-menu"))
                .Displayed
                .ShouldBeFalse();
        }

        [When(@"I click the Member Zone button")]
        public void WhenIClickTheMemberZoneButton()
        {
            this.presalesPage.MainNavigation.MemberZone.Click();
        }

        [Then(@"I expect the Login button to be visible")]
        public void ThenIExpectTheLoginButtonToBeVisible()
        {
            this.presalesPage.MainNavigation.LogInButton.Displayed.ShouldBeTrue();
        }

        [Then(@"I expect the Register button to be visible")]
        public void ThenIExpectTheRegisterButtonToBeVisible()
        {
            this.presalesPage.MainNavigation.RegisterButton.Displayed.ShouldBeTrue();
        }

        [Then(@"I expect the Forgotten button to be visible")]
        public void ThenIExpectTheForgottenButtonToBeVisible()
        {
            this.presalesPage.MainNavigation.ForgottenDetailsButton.Displayed.ShouldBeTrue();
        }
    }
}
