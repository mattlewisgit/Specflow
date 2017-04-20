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
    using System.Threading;
    using OpenQA.Selenium;

    [Binding]
    public sealed class FeemaximaSteps : BaseSteps
    {

        [When(@"I search for feemaxima (.*) data")]
        public void WhenISearchForFeemaximaData(string feemaximasearch)
        {
            WebDriver
                .FindElement(new JQuerySelector(".tt-input"))
                .Clear();

            WebDriver
                .FindElement(new JQuerySelector(".tt-input"))
                .SendKeys(feemaximasearch);

            Thread.Sleep(1000);

            WebDriver
                .FindElement(new JQuerySelector("strong.tt-highlight:contains('" + feemaximasearch + "')"))
                .Click();
        }

        [Then(@"I expect the feemaxima table to contain (.*) search results")]
        public void ThenIExpectTheFeemaximaTableToContainSearchResults(string feemaximasearch)
        {
            //var resultstable = WebDriver
            //    .FindElement(new JQuerySelector("ng-scope:contains('" + feemaximasearch + "')"));

            //string result = resultstable.Text;

            //result.Contains(feemaximasearch);

            WebDriver
                .FindElement(new JQuerySelector("tr.ng-scope:contains('" + feemaximasearch + "')"))
                .Displayed
                .ShouldBeTrue();


        }

        [Then(@"I click on the feemaxima (.*) button")]
        public void ThenIClickOnTheFeemaximaButton(string backbutton)
        {
            WebDriver
                .FindElement(By.LinkText(backbutton))
                .Click();


        }

        [Then(@"I expect the feemaxima home table to be displayed")]
        public void ThenIExpectTheFeemaximaHomeTableToBeDisplayed()
        {
            WebDriver
                .FindElement(new JQuerySelector("div.ng-scope"))
                .Displayed
                .ShouldBeTrue();
        }


        [When(@"I click on feemaxima (.*) and select on subcolumn (.*)")]
        public void WhenIClickOnFeemaximaAndSelectOnSubcolumn(string UIcolumn, string UIsubcolumn)
        {


            //variable chapter
            //var column1 = WebDriver
            //    .FindElement(new JQuerySelector("div.grid-col-2-12.chapter.ng-binding:contains('" + UIcolumn + "')"));

            //variable name
            //var column2 = WebDriver
            //    .FindElement(new JQuerySelector("div.grid-col-10-12.name.ng-binding:contains('" + UIcolumn + "')"));

            //if (column1.Count() !=0)
            //{
            //    column1.Click();
            //
            //else if (column2.Count() != 0)
            //{
            //    column2.Click();
            //}


            //wait for data feed to load
            //WebDriver
            //    .FindElement(new JQuerySelector(".example .ng-scope .loader")).Displayed.should
            //    .Click();

            WebDriver
                .WaitForElement(new JQuerySelector(".expanding-list.js-expander-is-accordion.expander--init.expander--collapsible"))
                .Displayed
                .ShouldBeTrue();


            //If chapter or name contains string UIColumn, then click on it
            if (WebDriver.FindElements(new JQuerySelector("div.grid-col-2-12.chapter.ng-binding:contains('" + UIcolumn + "')")).Count != 0)
            {
                WebDriver
                .FindElement(new JQuerySelector("div.grid-col-2-12.chapter.ng-binding:contains('" + UIcolumn + "')"))
                .Click();
            }
            else if (WebDriver.FindElements(new JQuerySelector("div.grid-col-10-12.name.ng-binding:contains('" + UIcolumn + "')")).Count != 0)
            {
                WebDriver
                .FindElement(new JQuerySelector("div.grid-col-10-12.name.ng-binding:contains('" + UIcolumn + "')"))
                .Click();
            }



            //If subchapter or subname contains string UIsubcolumn, then click on it
            if (WebDriver.FindElements(new JQuerySelector("div.grid-col-2-12.subchapter.ng-binding:contains('" + UIsubcolumn + "')")).Count != 0)
            {
                WebDriver
                .FindElement(new JQuerySelector("div.grid-col-2-12.subchapter.ng-binding:contains('" + UIsubcolumn + "')"))
                .Click();
            }
            else if (WebDriver.FindElements(new JQuerySelector("div.grid-col-8-12.name.ng-binding:contains('" + UIsubcolumn + "')")).Count != 0)
            {
                WebDriver
                .FindElement(new JQuerySelector("div.grid-col-8-12.name.ng-binding:contains('" + UIsubcolumn + "')"))
                .Click();
            }

        }




    }
}
