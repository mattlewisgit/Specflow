namespace Kingfisher.Website.IntegrationTests.Steps.Riversand
{
    using TechTalk.SpecFlow;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using Utilities;
    using By = OpenQA.Selenium.By;


    [Binding]
    public sealed class RSLoginSteps: BaseSteps
    {

        [When(@"I enter username (.*) and password (.*)")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            //Username
            try
            {
                WebDriver
                    .FindElement(By.Id("login"))
                    .SendKeys(username);
            }
            catch
            {
            }

            //Password
            try
            {
                WebDriver
                    .FindElement(By.Id("password"))
                    .SendKeys(password);
            }
            catch
            {
            }


        }


        [When(@"click on the (.*) button")]
        public void WhenClickOnTheButton(string button)
        {
            WebDriver
                .FindElement(By.Id("btnlogin"))
                .Click();
        }


    }
}
