﻿namespace Vitality.Website.IntegrationTests.Steps
{

    using System.Drawing;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Extensions;
    using Utilities;
    using OpenQA.Selenium.Interactions;
    using By = OpenQA.Selenium.By;
    using OpenQA.Selenium.Support.UI;
    using System;
    using OpenQA.Selenium;
    using System.Linq;
    using Xunit;

    [Binding]
    public sealed class AwardLeaderSteps : BaseSteps
    {

        [Then(@"I expect the correct CSS Award Leader values to appear")]
        public void ThenIExpectTheCorrectCSSAwardLeaderValuesToAppear()
        {
            //Award Leader Intro panel (lhs) is present
            WebDriver
                .FindElement(new JQuerySelector(".award-leader .award-leader--intro"))
                .Displayed
                .ShouldBeTrue();

            //Award Leader Intro panel (lhs) is present Heading contains H2
            var els = WebDriver
                .FindElements(new JQuerySelector(".award-leader .award-leader--intro h2"));

            var header = els
                .FirstOrDefault(e => e.Text.Equals("Choose confidently with award-winning health insurance cover from vitality"));

            Assert.NotNull(header);

            header.Displayed
                .ShouldBeTrue();

            //Award Leader Articles panel (rhs) is present
            WebDriver
                .FindElement(new JQuerySelector(".award-leader .award-leader--articles"))
                .Displayed
                .ShouldBeTrue();

            //Award Leader Intro panel contains the 4 Defaqto images
            WebDriver
                .FindElement(new JQuerySelector(".award-leader .award-leader--intro img[src*='defaqto-2017-pmi.png']"))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(new JQuerySelector(".award-leader .award-leader--intro img[src*='defaqto-2017-la.png']"))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(new JQuerySelector(".award-leader .award-leader--intro img[src*='defaqto-2017-cic.png']"))
                .Displayed
                .ShouldBeTrue();

            WebDriver
                .FindElement(new JQuerySelector(".award-leader .award-leader--intro img[src*='defaqto-2017-ip.png']"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I click on the Award Leader (.*) link")]
        public void IClickOnTheAwardLeaderLink(string memberStory)
        {
            // Find the header containing the text...
            var memberStoryArticle = WebDriver
                .FindElements(new JQuerySelector(".award-leader .award-leader--articles .article-snippet h3"))
                .FirstOrDefault(e => e.Text.Equals(memberStory));

            // Get the parent anchor and send a "scroll" (required in mobile view as panels stack)
            memberStoryArticle
                .GetParent()
                .SendKeys(Keys.Space);

            memberStoryArticle.Click();

        }


    }
}
