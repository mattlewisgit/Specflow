﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Vitality.Website.IntegrationTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CareersFeature : Xunit.IClassFixture<CareersFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Careers.feature"
#line hidden
        
        public CareersFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Careers", "\tIn order to recuit the very best\r\n\tAs an HR employee\r\n\tI want to be able show po" +
                    "tential candidates a list of current positions", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(CareersFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that the page loading information is shown")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that the page loading information is shown")]
        public virtual void CheckThatThePageLoadingInformationIsShown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that the page loading information is shown", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
    testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("I see the Vacancies page feed is loading with a message Loading Vacancies...", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
    testRunner.Then("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that all business Locations exist in dropdown")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that all business Locations exist in dropdown")]
        public virtual void CheckThatAllBusinessLocationsExistInDropdown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that all business Locations exist in dropdown", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I see the location All Locations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
    testRunner.And("I see the location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
    testRunner.And("I see the location Croydon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
    testRunner.And("I see the location London", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
    testRunner.And("I see the location Stockport", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that all business Departments exist in dropdown")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that all business Departments exist in dropdown")]
        public virtual void CheckThatAllBusinessDepartmentsExistInDropdown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that all business Departments exist in dropdown", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("I see the department All Departments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
    testRunner.And("I see the department Actuary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.And("I see the department Digital", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.And("I see the department Finance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
    testRunner.And("I see the department IT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
    testRunner.And("I see the department Marketing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
    testRunner.And("I see the department Sales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that all filtering works for Bournemouth")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that all filtering works for Bournemouth")]
        public virtual void CheckThatAllFilteringWorksForBournemouth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that all filtering works for Bournemouth", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
    testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("I select the location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("I see all the jobs belonging to location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that all filtering works for Digital", Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that all filtering works for Digital")]
        public virtual void CheckThatAllFilteringWorksForDigital()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that all filtering works for Digital", new string[] {
                        "ignore"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
    testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("I select the department Digital", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("I see all the jobs belonging to department Digital", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that there are no jobs available in Croydon")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that there are no jobs available in Croydon")]
        public virtual void CheckThatThereAreNoJobsAvailableInCroydon()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that there are no jobs available in Croydon", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
    testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I select the location Croydon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("I see there are no Vacancies available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that filtering refreshes page display when repeatedly changed")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that filtering refreshes page display when repeatedly changed")]
        public virtual void CheckThatFilteringRefreshesPageDisplayWhenRepeatedlyChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that filtering refreshes page display when repeatedly changed", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
    testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I select the location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
    testRunner.And("I select the department All Departments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then("I see all the jobs belonging to location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
    testRunner.And("I select the department Actuary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
    testRunner.And("I see there are no Vacancies available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check that we can follow the link to the Job page")]
        [Xunit.TraitAttribute("FeatureTitle", "Careers")]
        [Xunit.TraitAttribute("Description", "Check that we can follow the link to the Job page")]
        public virtual void CheckThatWeCanFollowTheLinkToTheJobPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that we can follow the link to the Job page", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
    testRunner.Given("I am on presales /careers/vacancies/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
    testRunner.And("I see the Vacancies page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When("I select the location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
    testRunner.And("I select the department All Departments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.Then("I see all the jobs belonging to location Bournemouth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
    testRunner.And("I click the link for the job .Net Developer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
    testRunner.And("I expect the presales /careers/vacancies/13654/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
    testRunner.And("I see the Vacancy page feed is loading with a message Retrieving job details...", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
    testRunner.Then("I see the Vacancy page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CareersFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CareersFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
