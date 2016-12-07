namespace Vitality.Website.IntegrationTests.Steps
{
    using System;

    using Selenium.WebDriver.Extensions.JQuery;

    using Shouldly;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;
    using Vitality.Website.IntegrationTests.PageObjects;
    using Vitality.Website.IntegrationTests.Utilities;
    using OpenQA.Selenium;
    using System.Linq;
    using OpenQA.Selenium.Interactions;
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
            //this.presalesPage.MainNavigation.ClickNavigationSectionLink("business");
            //WebDriver.FindElement(By.LinkText("business")).Click();
            WebDriver
            .FindElements(new JQuerySelector(Button.SITE_NAV))
            .Single(e => e.Text.Equals("Business", StringComparison.InvariantCultureIgnoreCase))
            .Click();

        }


        [When(@"I click on the advisers section link")]
        public void WhenIClickOnTheAdvisersSectionLink()
        {
            WebDriver
            .FindElements(new JQuerySelector(Button.SITE_NAV))
            .Single(e => e.Text.Equals("Advisers", StringComparison.InvariantCultureIgnoreCase))
            .Click();

        }

        [When(@"I click on the personal section link")]
        public void WhenIClickOnThePersonalSectionLink()
        {
            WebDriver
            .FindElements(new JQuerySelector(Button.SITE_NAV))
            .Single(e => e.Text.Equals("Personal", StringComparison.InvariantCultureIgnoreCase))
            .Click();
        }


        [When(@"I click on the navigation logo")]
        public void WhenIClickOnTheNavigationLogo()
        {
            //this.presalesPage.MainNavigation.Logo.Click();

            WebDriver
            .FindElement(new JQuerySelector(Button.NAV_LOGO))
            .Click();
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
            Browser.Resize(320, 800).Wait(TimeSpan.FromMilliseconds(300));
        }

        [Then(@"I expect the hamburger to be visible")]
        public void ThenIExpectTheHamburgerToBeVisible()
        {
            WebDriver
            .FindElement(new JQuerySelector(Button.BURGER_MENU))
            .Displayed
            .ShouldBeTrue();
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
            .FindElement(new JQuerySelector(Button.BURGER_MENU))
            .Displayed
            .ShouldBeFalse();
        }


        //[When(@"I click on the Login button")]
        //public void WhenIClickOnTheLoginButton()
        //{
        //   //  this.presalesPage.MainNavigation.LogIn.Click();

        //    WebDriver
        //    .FindElement(new JQuerySelector(Button.LOGIN_LARGE))
        //    .Click();
        //}



        [When(@"I click on the Login \(small\) button")]
        public void WhenIClickOnTheLoginSmallButton()
        {
              WebDriver
             .FindElement(new JQuerySelector(Button.LOGIN_SMALL))
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
            //this.presalesPage.MainNavigation.MemberZoneButton.Displayed.ShouldBeTrue();

            WebDriver
            .FindElement(OpenQA.Selenium.By.LinkText("Member Zone"))
            .Displayed
            .ShouldBeTrue();

        }

        

        [Then(@"I expect the Health Advisers button to be visible")]
        public void ThenIExpectTheHealthAdvisersButtonToBeVisible()
        {
            //this.presalesPage.MainNavigation.HealthAdvisersButton.Displayed.ShouldBeTrue();

            WebDriver
            .FindElement(OpenQA.Selenium.By.LinkText("Health Advisers"))
            .Displayed
            .ShouldBeTrue();
        }


        [Then(@"I expect the Life Advisers button to be visible")]
        public void ThenIExpectTheLifeAdvisersButtonToBeVisible()
        {
            //this.presalesPage.MainNavigation.LifeAdvisersButton.Displayed.ShouldBeTrue();

            WebDriver
            .FindElement(OpenQA.Selenium.By.LinkText("Life Advisers"))
            .Displayed
            .ShouldBeTrue();

        }

        [When(@"I click on the footer button")]
        public void WhenIClickOnTheFooterButton()
        {
            WebDriver
            .FindElement(new JQuerySelector(Button.FOOTER))
            .Click(); ;
        }


        [Then(@"I expect the Health insurance quote button to be visible")]
        public void ThenIExpectTheHealthInsuranceQuoteButtonToBeVisible()
        {
            //this.presalesPage.MainNavigation.HealthQuoteButton.Displayed.ShouldBeTrue();
            WebDriver
            .FindElement(OpenQA.Selenium.By.LinkText("Health insurance quote"))
            .Displayed
            .ShouldBeTrue();

        }

        [Then(@"I expect the Life insurance quote button to be visible")]
        public void ThenIExpectTheLifeInsuranceQuoteButtonToBeVisible()
        {
            //this.presalesPage.MainNavigation.LifeQuoteButton.Displayed.ShouldBeTrue();
            WebDriver
            .FindElement(OpenQA.Selenium.By.LinkText("Life insurance quote"))
            .Displayed
            .ShouldBeTrue();

        }

        [Then(@"I expect the footer to be invisible")]
        public void ThenIExpectTheFooterToBeInvisible()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I hover over (.*) and click on (.*)")]
        public void WhenIHoverOver(string hoverLink, string clickLink)
        {
            var sectionLink = WebDriver.FindElement(new JQuerySelector(".section-nav .section-nav__item--megamenu:contains('" + hoverLink + "')"));

            // Hover over the menu.
            new Actions(WebDriver).MoveToElement(sectionLink).Perform();

            // Wait for the submenu to appear.
            WebDriver.WaitForElement(OpenQA.Selenium.By.ClassName("megamenu"));

            // Find and click the subsection.
            WebDriver
                .FindElement(new JQuerySelector(".megamenu a:contains('" + clickLink + "')"))
                .Click();
        }
    }
}
