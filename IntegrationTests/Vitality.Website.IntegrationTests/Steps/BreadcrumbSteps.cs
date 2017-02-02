namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using TechTalk.SpecFlow;
    using OpenQA.Selenium;
    using Xunit;
    using OpenQA.Selenium.Interactions;
    using System.Drawing;
    using By = OpenQA.Selenium.By;
    using Extensions;
    using Shouldly;
    using System.Threading;
    using Utilities;

    [Binding]
    public sealed class BreadcrumbSteps : BaseSteps
    {

        [Then(@"I expect the breadcrumb to show (.*)")]
        public void ThenIExpectTheBreadcrumbToShow(string breadcrumb)
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".breadcrumb > ol > li > a > span:contains('" + breadcrumb + "')"))
                    .Displayed.ShouldBeTrue();
        }


        [Then(@"I expect the breadcrumb to be hidden")]
        public void ThenIExpectTheBreadcrumbToBeHidden()
        {
            WebDriver
                    .WaitForElement(new JQuerySelector(".breadcrumb"))
                    .Displayed.ShouldBeFalse();
        }


        [Then(@"then I click on breadcrumbs (.*)")]
        public void ThenThenIClickOnBreadcrumbs(string breadcrumb)
        {
            WebDriver
                    .FindElement(new JQuerySelector(".breadcrumb > ol > li > a > span:contains('" + breadcrumb + "')"))                    
                    .Click();

            WebDriver.WaitForPageLoad();
        }
        
    }
}
