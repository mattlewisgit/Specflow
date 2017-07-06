using OpenQA.Selenium;
using Selenium.WebDriver.Extensions.JQuery;
using Shouldly;
using System.Linq;
using TechTalk.SpecFlow;
using Vitality.Extensions.Selenium;

namespace Vitality.Website.IntegrationTests.Steps
{
    [Binding]
    public sealed class RewardLeaderSteps : BaseSteps
    {
        private string bgcolour;
        private string bgcolourvalue;
        private string fontsize;

        [Then(@"I expect the correct CSS Reward Leader (.*) values to appear in (.*)")]
        public void ThenIExpectTheCorrectCSSRewardLeaderValuesToAppearIn(string colour, string screensize)
        {
            //If string equal 'blue', then pass dark JQuery selector value
            if (colour.Equals("blue"))
            {
                bgcolour = "dark";
                bgcolourvalue = "rgb(79, 115, 138)";
            }
            //If string equal 'purple', then pass tertiary JQuery selector value
            if (colour.Equals("purple"))
            {
                bgcolour = "tertiary";
                bgcolourvalue = "rgb(110, 82, 126)";
            }

            //If string equal 'full view', then pass font size value
            if (screensize.Equals("full view"))
            {
                fontsize = "35px";
            }
            //If string equal 'mobile view', then pass font size value
            if (screensize.Equals("mobile view"))
            {
                fontsize = "25px";
            }

            //Blue(Dar k#4f738a) purple-(tertiary #6e527e)

            //Background colour.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader"))
                .GetCssValue("background")
                .ShouldContain(bgcolourvalue);

            //Background 
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader"))
                .GetCssValue("text-align")
                .ShouldBe("center");

            //Background border.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader"))
                .GetCssValue("border")
                .ShouldContain("20px solid");

            //H2 font colour.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content h2"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            //H2 font size.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content h2"))
                .GetCssValue("font-size")
                .ShouldBe(fontsize);

            //Description.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .feature-block__content--body"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");


            //Reward images.
            WebDriver
                .WaitForElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .feature-block__image-list div a .lazyloaded"))
                .GetCssValue("max-height")
                .ShouldBe("80px");

            //Button font colour.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .box-button.box-button--light.box-button--rounded"))
                .GetCssValue("color")
                .ShouldBe("rgba(255, 255, 255, 1)");

            //Button border colour.
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .box-button.box-button--light.box-button--rounded"))
                .GetCssValue("border-color")
                .ShouldBe("rgb(255, 255, 255)");
        }

        [When(@"I click on rewards leader button (.*)")]
        public void WhenIClickOnRewardsLeaderButton(string button)
        {
            WebDriver
                .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .box-button.box-button--light.box-button--rounded"))
                .Click();
        }

        [When(@"I click on rewards leader background colour (.*) button (.*)")]
        public void WhenIClickOnRewardsLeaderBackgroundColourButton(string colour, string button)
        {
            //If string equal 'blue', then pass dark JQuery selector value
            if (colour.Equals("blue"))
            {
                bgcolour = "dark";
            }
            //If string equal 'purple', then pass tertiary JQuery selector value
            if (colour.Equals("purple"))
            {
                bgcolour = "tertiary";
            }

            //WebDriver
            //    .FindElement(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .box-button.box-button--light.box-button--rounded:contains('" + button + "')"))
            //    .Click();


            // Find the button containing the text...
            var RewardLeaderArticle = WebDriver
                .FindElements(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .box-button.box-button--light.box-button--rounded"))
                .FirstOrDefault(e => e.Text.Equals(button));

            // Send a "scroll" (required if object is not in view)
            RewardLeaderArticle
                .SendKeys(Keys.Space);

            RewardLeaderArticle.Click();


        }


        [When(@"I click on rewards leader background colour (.*) with partner logo (.*)")]
        public void WhenIClickOnRewardsLeaderBackgroundColourWithPartnerLogo(string colour, string logolink)
        {
            //If string equal 'blue', then pass dark JQuery selector value
            if (colour.Equals("blue"))
            {
                bgcolour = "dark";
            }
            //If string equal 'purple', then pass tertiary JQuery selector value
            if (colour.Equals("purple"))
            {
                bgcolour = "tertiary";
            }
            // Send a "scroll" to rewards leader component
            WebDriver
                .ScrollToElement($@".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .feature-block__image-list div a img");

            //Find Logo containing 'LogoLink'
            var Logo = WebDriver
                .FindElements(new JQuerySelector(".feature-block.feature-block--" + bgcolour + ".rewards_leader .feature-block__content .feature-block__image-list div a .lazyloaded"))
                .FirstOrDefault(e => e.InnerElement.GetAttribute("data-src").Contains(logolink));

            //Click on logo
            Logo.Click();

        }

    }
}
