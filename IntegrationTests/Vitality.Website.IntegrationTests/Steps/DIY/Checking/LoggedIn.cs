using System.Diagnostics.Eventing.Reader;
using Kingfisher.Website.IntegrationTests.Steps;

namespace Vitality.Website.IntegrationTests.Steps.DIY.Checking
{
    using Kingfisher.Website.IntegrationTests.Extensions;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using System;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class LoggedIn : BaseSteps
    {


        [Then(@"I expect (.*) account to be logged in")]
        public void ThenIExpectAccountToBeLoggedIn(string username)
        {

                var loggedInUser = WebDriver
                    .WaitForElement(new JQuerySelector(".wrapper .header-nav.header-nav-login ul li span"))
                    .GetAttribute("innerText");

                try
                {
                    loggedInUser.ShouldContain(username);
                }
                catch
                {
                    throw new Exception("Expected username: " + username + " does not contain logged in username: " + loggedInUser + "");
                }
            
        }

    }
}
