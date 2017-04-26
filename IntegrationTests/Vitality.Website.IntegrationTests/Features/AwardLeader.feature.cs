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
    public partial class AwardLeaderFeature : Xunit.IClassFixture<AwardLeaderFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AwardLeader.feature"
#line hidden
        
        public AwardLeaderFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Award Leader", "\tIn order to avoid silly mistakes\r\n\tAs a Award Leader user\r\n\tI want to be able to" +
                    " see that Award Leader works", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(AwardLeaderFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Award Leader full screen view")]
        [Xunit.TraitAttribute("FeatureTitle", "Award Leader")]
        [Xunit.TraitAttribute("Description", "Check Award Leader full screen view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckAwardLeaderFullScreenView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Award Leader full screen view", new string[] {
                        "SIT"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I am on presales /dev/award-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("I expect the correct CSS Award Leader values to appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Award Leader mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Award Leader")]
        [Xunit.TraitAttribute("Description", "Check Award Leader mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckAwardLeaderMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Award Leader mobile view", new string[] {
                        "SIT"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I am on presales /dev/award-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("I expect the correct CSS Award Leader values to appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Award Leader Member Story 1 link works")]
        [Xunit.TraitAttribute("FeatureTitle", "Award Leader")]
        [Xunit.TraitAttribute("Description", "Check Award Leader Member Story 1 link works")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckAwardLeaderMemberStory1LinkWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Award Leader Member Story 1 link works", new string[] {
                        "SIT"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am on presales /dev/award-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.When("I click on the Award Leader Member Stories 1 link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("I expect the presales /dev/home-hero/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Award Leader Member Story 2 link works")]
        [Xunit.TraitAttribute("FeatureTitle", "Award Leader")]
        [Xunit.TraitAttribute("Description", "Check Award Leader Member Story 2 link works")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckAwardLeaderMemberStory2LinkWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Award Leader Member Story 2 link works", new string[] {
                        "SIT"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I am on presales /dev/award-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("I click on the Award Leader member Stories 2 link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I expect the presales /dev/home-hero/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Award Leader Member Story 3 link works")]
        [Xunit.TraitAttribute("FeatureTitle", "Award Leader")]
        [Xunit.TraitAttribute("Description", "Check Award Leader Member Story 3 link works")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckAwardLeaderMemberStory3LinkWorks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Award Leader Member Story 3 link works", new string[] {
                        "SIT"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I am on presales /dev/award-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.When("I click on the Award Leader Member Stories 3 link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("I expect the presales /dev/home-hero/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Award Leader Member Story 1 link works in mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Award Leader")]
        [Xunit.TraitAttribute("Description", "Check Award Leader Member Story 1 link works in mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckAwardLeaderMemberStory1LinkWorksInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Award Leader Member Story 1 link works in mobile view", new string[] {
                        "SIT"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I am on presales /dev/award-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.And("I click on the Award Leader Member Stories 1 link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.Then("I expect the presales /dev/home-hero/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AwardLeaderFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AwardLeaderFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
