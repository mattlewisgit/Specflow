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
    public partial class BenefitLeaderFeature : Xunit.IClassFixture<BenefitLeaderFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BenefitLeader.feature"
#line hidden
        
        public BenefitLeaderFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BenefitLeader", "\tIn order to avoid silly mistakes\r\n\tAs a accordion user\r\n\tI want to be expand and" +
                    " retract the accordion", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(BenefitLeaderFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Benefit Leader in mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "BenefitLeader")]
        [Xunit.TraitAttribute("Description", "Check Benefit Leader in mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckBenefitLeaderInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Benefit Leader in mobile view", new string[] {
                        "SIT"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I am on presales /dev/benefit-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("I expect the Benefit Leader Left alignment CSS values to appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.And("I expect the Benefit Leader Right alignment CSS values to appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Benefit Leader in full size view")]
        [Xunit.TraitAttribute("FeatureTitle", "BenefitLeader")]
        [Xunit.TraitAttribute("Description", "Check Benefit Leader in full size view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckBenefitLeaderInFullSizeView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Benefit Leader in full size view", new string[] {
                        "SIT"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I am on presales /dev/benefit-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I expect the Benefit Leader Left alignment CSS values to appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("I expect the Benefit Leader Right alignment CSS values to appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Benefit Leader button links internally")]
        [Xunit.TraitAttribute("FeatureTitle", "BenefitLeader")]
        [Xunit.TraitAttribute("Description", "Check Benefit Leader button links internally")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckBenefitLeaderButtonLinksInternally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Benefit Leader button links internally", new string[] {
                        "SIT"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I am on presales /dev/benefit-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When("I click on benefit leader Left alignment button Explore Vitality GP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("I expect the presales / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Benefit Leader button links externally")]
        [Xunit.TraitAttribute("FeatureTitle", "BenefitLeader")]
        [Xunit.TraitAttribute("Description", "Check Benefit Leader button links externally")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckBenefitLeaderButtonLinksExternally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Benefit Leader button links externally", new string[] {
                        "SIT"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I am on presales /dev/benefit-leader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.When("I click on benefit leader Right alignment button Explore Vitality GP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("I expect the presales / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                BenefitLeaderFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                BenefitLeaderFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
