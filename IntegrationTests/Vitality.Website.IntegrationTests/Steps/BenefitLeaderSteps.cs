namespace Vitality.Website.IntegrationTests.Steps
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


    [Binding]
    public sealed class BenefitLeaderSteps : BaseSteps
    {
        private string BenefitLeader;
        private string Gradient;


        [Then(@"I expect the Benefit Leader (.*) alignment CSS values to appear")]
        public void ThenIExpectTheBenefitLeaderAlignmentCSSValuesToAppear(string BenefitLeaderAlignment)
        {
            //If string equal 'Left', then pass Left alignment JQuery Selector Value
            if (BenefitLeaderAlignment.Equals("Left"))
            {
                BenefitLeader = ".feature-block.feature-block--secondary.feature-block--";
                Gradient = "";
            }
            //If string equal 'Right', then pass right alignment JQuery Selector Value
            if (BenefitLeaderAlignment.Equals("Right"))
            {
                BenefitLeader = ".feature-block.feature-block--secondary.feature-block--right";
                Gradient = "";
            }
            //If string equal 'Gradient', then pass gradient JQuery Selector Value
            if (BenefitLeaderAlignment.Equals("Gradient"))
            {
                BenefitLeader = ".feature-block-gradient.feature-block-gradient--secondary.feature-block-gradient--";
                Gradient = "-gradient";
            }




            //BENEFIT LEADER
            //Check Benefit Leader Image Is Displayed
            WebDriver
                    .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__image.background-position-top-left.lazyloaded"))
                    .Displayed
                    .ShouldBeTrue();

            //Check Benefit leader Content Paragraph is Displayed
            WebDriver
                    .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__content-container .feature-block" + Gradient + "__content p"))
                    .Displayed
                    .ShouldBeTrue();

            //Check Benefit leader Content H2 is Displayed //25px in mobile view
            WebDriver
                    .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__content-container .feature-block" + Gradient + "__content h2"))
                    .Displayed
                    .ShouldBeTrue();

            //Check Benefit leader Content Body is Displayed (White text)
            WebDriver
                    .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__content-container .feature-block" + Gradient + "__content .feature-block__content--body"))
                    .GetCssValue("color")
                    .ShouldBe("rgba(255, 255, 255, 1)");


            //Check Benefit leader Button is rounded button and white
            WebDriver
                .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__content-container a"))
                    .GetCssValue("border-radius")
                    .ShouldBe("5px");

            WebDriver
                    .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__content-container a"))
                    .GetCssValue("border-color")
                    .ShouldBe("rgb(255, 255, 255)");
        }






        [When(@"I click on benefit leader (.*) alignment button (.*)")]
        public void WhenIClickOnBenefitLeaderAlignmentButton(string BenefitLeaderAlignment, string ButtonName)
        {
            //If string equal 'Left', then pass Left alignment JQuery Selector Value
            if (BenefitLeaderAlignment.Equals("Left"))
            {
                BenefitLeader = ".feature-block.feature-block--secondary.feature-block--";
                Gradient = "";
            }
            //If string equal 'Right', then pass right alignment JQuery Selector Value
            if (BenefitLeaderAlignment.Equals("Right"))
            {
                BenefitLeader = ".feature-block.feature-block--secondary.feature-block--right";
                Gradient = "";
            }
            //If string equal 'Gradient', then pass gradient JQuery Selector Value
            if (BenefitLeaderAlignment.Equals("Gradient"))
            {
                BenefitLeader = ".feature-block-gradient.feature-block-gradient--secondary.feature-block-gradient--";
                Gradient = "-gradient";
            }


            //Click on String button
            WebDriver
                    .FindElement(new JQuerySelector(BenefitLeader + " .feature-block" + Gradient + "__content-container .box-button.box-button--rounded:contains('" + ButtonName + "')"))
                    .Click();
        }


    }


}
