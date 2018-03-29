using Kingfisher.Website.IntegrationTests.Extensions;

namespace Vitality.Website.IntegrationTests.Steps.DIY.Fields
{
    using Kingfisher.Website.IntegrationTests.Steps;
    using Selenium.WebDriver.Extensions.JQuery;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class TopNavigation : BaseSteps
    {
        private string selector;

        [When(@"I click on the top (.*) navigation (.*) link")]
        public void WhenIClickOnTheTopNavigationLink(string location, string linkName)
        {
            if (location.LooseEquals("Left"))
            {
                selector = ".site-header .header-nav-wrapper .wrapper .header-nav.header-nav-secondary ul li a";
            }

            if (location.LooseEquals("Right"))
            {
                selector = ".site-header .header-nav-wrapper .wrapper .header-nav ul .sign-in-link a";
            }

            if (location.LooseEquals("Bottom"))
            {
                selector = ".categories .grid .grid-item .list-stacked li a";
            }

            WebDriver
                .FindElement(new JQuerySelector
                    (selector + ":contains('" + linkName + "')"))
                .Click();
        }


    }
}
