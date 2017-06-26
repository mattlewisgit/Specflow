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
    using System.Linq;
    using Xunit;
    using Vitality.Extensions.Selenium;
    using System.Threading;

    [Binding]
    public sealed class HomeHeroSteps : BaseSteps
    {
        [Then(@"I expect the correct CSS home hero values to appear")]
        public void ThenIExpectTheCorrectCSSHomeHeroValuesToAppear()
        {
            //Heading H1
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .header.animated h1"))
                .Displayed
                .ShouldBeTrue();

            //Play button
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .home-hero--static__button.svg-svg--button-video-play"))
                .Displayed
                .ShouldBeTrue();

            //Description
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .animated"))
                .Displayed
                .ShouldBeTrue();

            //Background image
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static"))
                .GetCssValue("background-image")
                .Contains(AppSettings.Links.VitalityPresalesUrl);
        }


        [Then(@"I expect the correct CSS home hero values to appear in mobile view")]
        public void ThenIExpectTheCorrectCSSHomeHeroValuesToAppearInMobileView()
        {
            //Heading H1
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .header.animated h1"))
                .Displayed
                .ShouldBeTrue();

            //Play button
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .home-hero--static__button"))
                .Displayed
                .ShouldBeFalse();

            //Description
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .animated"))
                .Displayed
                .ShouldBeTrue();

            //Background image
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static"))
                .GetCssValue("background-image")
                .Contains(AppSettings.Links.VitalityPresalesUrl);
        }




        [When(@"I click on home hero play button")]
        public void WhenIClickOnHomeHeroPlayButton()
        {
            //Play button
            WebDriver
                .FindElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .home-hero--static__button.animated.svg-svg--button-video-play"))
                .Click();
        }

        [Then(@"I expect the home hero video to play")]
        public void ThenIExpectTheHomeHeroVideoToPlay()
        {
            //Video playing but pause button not visible 
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .home-hero--static__button.animated.svg-svg--button-video-pause"))
                .Displayed
                .ShouldBeFalse();

            //Background image not visible
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static"))
                .GetCssValue("background-image")
                .ShouldBe("none");

            //Heading H1 not visible
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .header.animated h1"))
                .Displayed
                .ShouldBeFalse();

            //Description not visible
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .animated"))
                .Displayed
                .ShouldBeFalse();
        }

        [When(@"I click on the home hero pause button")]
        public void WhenIClickOnTheHomeHeroPauseButton()
        {
            //Video playing but pause button not visible 
            WebDriver
                .WaitForElement(new JQuerySelector(".home-hero.home-hero--video .home-hero--static .home-hero--static__container .home-hero--static__button.animated.svg-svg--button-video-pause"))
                .Displayed
                .ShouldBeFalse();

            //Need to wait for video from Youtube to play - Not ideal so need to look into later
            Thread.Sleep(10000);

            WebDriver
                .FindElement(new JQuerySelector(".home-hero--static.background-position-middle-left.text-dark.lazyloaded"))
                .Click();

            //Need to wait for video from youtube to Pause - Not ideal so need to look into this later
            Thread.Sleep(10000);


        }


    }
}
