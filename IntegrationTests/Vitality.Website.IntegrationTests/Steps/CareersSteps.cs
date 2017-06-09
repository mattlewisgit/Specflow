namespace Vitality.Website.IntegrationTests.Steps
{
    using System.Linq;
    using Selenium.WebDriver.Extensions.JQuery;
    using Shouldly;
    using TechTalk.SpecFlow;
    using Vitality.Extensions.Selenium;

    [Binding]
    public sealed class CareersSteps : BaseSteps
    {
        [When(@"I check the Locations dropdown")]
        public void ICheckTheLocationsDropdown()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see the location (.*)")]
        public void ISeeTheLocation(string location)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $"vacancy-list #locationsDropDown option[value='{location}']"))
                .Displayed
                .ShouldBeTrue();
        }

        [Then(@"I see the department (.*)")]
        public void ISeeTheDepartment(string department)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $"vacancy-list #departmentsDropDown option[value='{department}']"))
                .Displayed
                .ShouldBeTrue();
        }

        [When(@"I select the location (.*)")]
        public void ISelectTheLocation(string location)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $"vacancy-list #locationsDropDown option[value='{location}']"))
                .Click();
        }

        [Then(@"I see all the jobs belonging to location (.*)")]
        public void ISeeAllTheJobsBelongingToLocation(string location)
        {
            WebDriver
                .FindElements(new JQuerySelector("vacancy-list .vacancyList .vacancy li:first-child"))
                .Select(el => el.Text.Split(':')[1].Trim())
                .ToList()
                .ForEach(jobLocation => jobLocation.ShouldBe(location));
        }

        [When(@"I select the department (.*)")]
        [Then(@"I select the department (.*)")]
        public void ISelectTheDepartment(string department)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $"vacancy-list #departmentsDropDown option[value='{department}']"))
                .Click();
        }

        [Then(@"I see all the jobs belonging to department (.*)")]
        public void ISeeAllTheJobsBelongingToDepartment(string department)
        {
            WebDriver
                .FindElements(new JQuerySelector("vacancy-list .vacancyList .vacancy li:first-child"))
                .Select(el => el.Text.Split(':')[1].Trim())
                .ToList()
                .ForEach(jobDepartment => jobDepartment.ShouldBe(department));
        }

        [When(@"I see the Vacancies page feed load has completed")]
        [Given(@"I see the Vacancies page feed load has completed")]
        [Then(@"I see the Vacancies page feed load has completed")]
        public void ISeeTheVacanciesPageFeedLoadHasCompleted()
        {
            // Check for the presence of options loaded in the Locations dropdown.
            // If there are options, then the form has finished loading.
            // This is the most reliable way of checking there is data in the form!!
            WebDriver
                .WaitForElement(new JQuerySelector("#locationsDropDown option"))
                .ShouldNotBeNull();
        }

        [When(@"I see the Vacancies page feed is loading with a message (.*)")]
        public void ISeeTheVacanciesPageFeedIsLoadingWithAMessage(string message)
        {
            WebDriver
                .FindElements(new JQuerySelector("vacancy-list"))
                .FirstOrDefault(e => e.Text.Equals(message))
                .ShouldNotBeNull();
        }

        [Then(@"I see there are no Vacancies available")]
        public void ISeeThereAreNoVacanciesAvailable()
        {
            // vacancyList is the element where the loaded jobs appear
            WebDriver
                .WaitForElement(new JQuerySelector(".vacancyList .novacancies"))
                .ShouldNotBeNull();
        }

        [Then(@"I click the link for the job (.*)")]
        public void IClickTheLinkForTheJob(string jobTitle)
        {
            WebDriver
                .FindElement(new JQuerySelector(
                    $"vacancy-list .vacancyList .vacancy:has(h3:contains('{jobTitle}')) .emphasis-link"))
                .Click();
        }

        [Then(@"I see the Vacancy page feed is loading with a message (.*)")]
        public void ISeeTheVacancyPageFeedIsLoadingWithAMessage(string message)
        {
            WebDriver
                .FindElements(new JQuerySelector("vacancy-details"))
                .FirstOrDefault(e => e.Text.Equals(message))
                .ShouldNotBeNull();
        }

        [Then(@"I see the Vacancy page feed load has completed")]
        public void ThenISeeTheVacancyPageFeedLoadHasCompleted()
        {
            // Check for the presence of options loaded in the Locations dropdown.
            // If there are options, then the form has finished loading.
            // This is the most reliable way of checking there is data in the form!!
            WebDriver
                .WaitForElement(new JQuerySelector("vacancy-details"))
                .ShouldNotBeNull();
        }
    }
}
