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
    public partial class PolicyStartDateFieldFeature : Xunit.IClassFixture<PolicyStartDateFieldFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PolicyStartDateField.feature"
#line hidden
        
        public PolicyStartDateFieldFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PolicyStartDateField", "\tIn order to validation the policy start date field\r\n\tAs a quote and apply user\r\n" +
                    "\tI want to be able to check the policy start date field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(PolicyStartDateFieldFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Policy Start Date - Check the Policy Start Date allows today")]
        [Xunit.TraitAttribute("FeatureTitle", "PolicyStartDateField")]
        [Xunit.TraitAttribute("Description", "Policy Start Date - Check the Policy Start Date allows today")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PolicyStartDate_CheckThePolicyStartDateAllowsToday()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Policy Start Date - Check the Policy Start Date allows today", new string[] {
                        "QuoteAndApply"});
#line 7
    this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
    testRunner.When("I go to the coverStartDate field and make the date today plus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then("I don\'t see the coverStartDate field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Policy Start Date - Check the Policy Start Date allows 30 days from now")]
        [Xunit.TraitAttribute("FeatureTitle", "PolicyStartDateField")]
        [Xunit.TraitAttribute("Description", "Policy Start Date - Check the Policy Start Date allows 30 days from now")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PolicyStartDate_CheckThePolicyStartDateAllows30DaysFromNow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Policy Start Date - Check the Policy Start Date allows 30 days from now", new string[] {
                        "QuoteAndApply"});
#line 14
    this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
    testRunner.When("I go to the coverStartDate field and make the date today plus 30 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
    testRunner.Then("I don\'t see the coverStartDate field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Policy Start Date - Check the Policy Start Date does not allow 31 days from now")]
        [Xunit.TraitAttribute("FeatureTitle", "PolicyStartDateField")]
        [Xunit.TraitAttribute("Description", "Policy Start Date - Check the Policy Start Date does not allow 31 days from now")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PolicyStartDate_CheckThePolicyStartDateDoesNotAllow31DaysFromNow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Policy Start Date - Check the Policy Start Date does not allow 31 days from now", new string[] {
                        "QuoteAndApply"});
#line 21
    this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
    testRunner.When("I go to the coverStartDate field and make the date today plus 31 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.Then("I see the coverStartDate field error text Please enter valid date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Policy Start Date - Check the Policy Start Date does not allow dates in the past")]
        [Xunit.TraitAttribute("FeatureTitle", "PolicyStartDateField")]
        [Xunit.TraitAttribute("Description", "Policy Start Date - Check the Policy Start Date does not allow dates in the past")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PolicyStartDate_CheckThePolicyStartDateDoesNotAllowDatesInThePast()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Policy Start Date - Check the Policy Start Date does not allow dates in the past", new string[] {
                        "QuoteAndApply"});
#line 28
    this.ScenarioSetup(scenarioInfo);
#line 29
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
    testRunner.When("I go to the coverStartDate field and make the date today minus 1 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
    testRunner.Then("I see the coverStartDate field error text Please enter valid date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                PolicyStartDateFieldFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PolicyStartDateFieldFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
