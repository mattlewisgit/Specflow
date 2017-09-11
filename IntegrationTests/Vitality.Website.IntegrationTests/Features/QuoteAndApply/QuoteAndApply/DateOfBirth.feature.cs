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
namespace Vitality.Website.IntegrationTests.Features.QuoteAndApply.QuoteAndApply
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class DateOfBirthFeature : Xunit.IClassFixture<DateOfBirthFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DateOfBirth.feature"
#line hidden
        
        public DateOfBirthFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DateOfBirth", "\tIn order to validation the date of birth field\r\n\tAs a quote and apply user\r\n\tI w" +
                    "ant to be able to check the date of birth field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(DateOfBirthFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="DOB - Check error message when dateOfBirth date format incorrect")]
        [Xunit.TraitAttribute("FeatureTitle", "DateOfBirth")]
        [Xunit.TraitAttribute("Description", "DOB - Check error message when dateOfBirth date format incorrect")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void DOB_CheckErrorMessageWhenDateOfBirthDateFormatIncorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DOB - Check error message when dateOfBirth date format incorrect", new string[] {
                        "QuoteAndApply"});
#line 7
    this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
    testRunner.When("I go to the dateOfBirth field and enter 01/01/197", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then("I see the dateOfBirth field error text Please enter valid birth date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="DOB - Check error message when dateOfBirth makes Member too old")]
        [Xunit.TraitAttribute("FeatureTitle", "DateOfBirth")]
        [Xunit.TraitAttribute("Description", "DOB - Check error message when dateOfBirth makes Member too old")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void DOB_CheckErrorMessageWhenDateOfBirthMakesMemberTooOld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DOB - Check error message when dateOfBirth makes Member too old", new string[] {
                        "QuoteAndApply"});
#line 15
    this.ScenarioSetup(scenarioInfo);
#line 16
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
    testRunner.When("I go to the dateOfBirth field and make the age 80 plus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
    testRunner.Then("I see the dateOfBirth field error text Please enter valid birth date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="DOB - Check error message when dateOfBirth makes Member too young")]
        [Xunit.TraitAttribute("FeatureTitle", "DateOfBirth")]
        [Xunit.TraitAttribute("Description", "DOB - Check error message when dateOfBirth makes Member too young")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void DOB_CheckErrorMessageWhenDateOfBirthMakesMemberTooYoung()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DOB - Check error message when dateOfBirth makes Member too young", new string[] {
                        "QuoteAndApply"});
#line 22
    this.ScenarioSetup(scenarioInfo);
#line 23
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.When("I go to the dateOfBirth field and make the age 18 minus 1 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
    testRunner.Then("I see the dateOfBirth field error text Please enter valid birth date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="DOB - Check error message does not appear when dateOfBirth makes Member almost to" +
            "o old")]
        [Xunit.TraitAttribute("FeatureTitle", "DateOfBirth")]
        [Xunit.TraitAttribute("Description", "DOB - Check error message does not appear when dateOfBirth makes Member almost to" +
            "o old")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void DOB_CheckErrorMessageDoesNotAppearWhenDateOfBirthMakesMemberAlmostTooOld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DOB - Check error message does not appear when dateOfBirth makes Member almost to" +
                    "o old", new string[] {
                        "QuoteAndApply"});
#line 29
    this.ScenarioSetup(scenarioInfo);
#line 30
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
    testRunner.When("I go to the dateOfBirth field and make the age 80 minus 1 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
    testRunner.Then("I don\'t see the dateOfBirth field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="DOB - Check error message does not appear when dateOfBirth makes Member almost to" +
            "o young")]
        [Xunit.TraitAttribute("FeatureTitle", "DateOfBirth")]
        [Xunit.TraitAttribute("Description", "DOB - Check error message does not appear when dateOfBirth makes Member almost to" +
            "o young")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void DOB_CheckErrorMessageDoesNotAppearWhenDateOfBirthMakesMemberAlmostTooYoung()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DOB - Check error message does not appear when dateOfBirth makes Member almost to" +
                    "o young", new string[] {
                        "QuoteAndApply"});
#line 36
    this.ScenarioSetup(scenarioInfo);
#line 37
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
    testRunner.When("I go to the dateOfBirth field and make the age 18 minus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
    testRunner.Then("I don\'t see the dateOfBirth field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                DateOfBirthFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DateOfBirthFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
