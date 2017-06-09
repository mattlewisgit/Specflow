namespace Vitality.Website.IntegrationTests.Steps
{
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class BreadcrumbSteps : BaseSteps
    {
        [Then(@"I expect the breadcrumb to show (.*)")]
        public void ThenIExpectTheBreadcrumbToShow(string breadcrumb)
        {
            WebDriver
                .WaitForElement(new JQuerySelector(
                    $".breadcrumb > ol > li > a > span:contains('{breadcrumb}')"))
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
                .FindElement(new JQuerySelector($".breadcrumb > ol > li > a > span:contains('{breadcrumb}')"))
                .Click();

            WebDriver.WaitForPageLoad();
        }
    }
}
