﻿namespace Vitality.Website.IntegrationTests.Steps
{
    using System;

    using Selenium.WebDriver.Extensions.JQuery;

    using Shouldly;

    using TechTalk.SpecFlow;

    using Vitality.Website.IntegrationTests.Extensions;
    using Vitality.Website.IntegrationTests.PageObjects;
    using Vitality.Website.IntegrationTests.Utilities;
    using OpenQA.Selenium;

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
                .FindElement(new JQuerySelector(Button.BUSINESS))
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
            Browser.Resize(320, 800).Wait(TimeSpan.FromMilliseconds(50));
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


        [When(@"I click on the Login button")]
        public void WhenIClickOnTheLoginButton()
        {
           //  this.presalesPage.MainNavigation.LogIn.Click();

            WebDriver
            .FindElement(new JQuerySelector(Button.LOGIN))
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


    }
}
