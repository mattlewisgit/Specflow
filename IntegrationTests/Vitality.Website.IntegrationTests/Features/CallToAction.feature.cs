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
    public partial class CallToActionFeature : Xunit.IClassFixture<CallToActionFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CallToAction.feature"
#line hidden
        
        public CallToActionFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CallToAction", "\tIn order to avoid silly mistakes\r\n\tAs a CTA user\r\n\tI want to check on the CTA co" +
                    "mponent", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(CallToActionFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Check CTA Component in full screen")]
        [Xunit.TraitAttribute("FeatureTitle", "CallToAction")]
        [Xunit.TraitAttribute("Description", "Check CTA Component in full screen")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckCTAComponentInFullScreen()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check CTA Component in full screen", new string[] {
                        "SIT"});
#line 8
 this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I am on presales /dev/call-to-action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("I expect the correct CTA CSS values to appear for mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check CTA Component in mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "CallToAction")]
        [Xunit.TraitAttribute("Description", "Check CTA Component in mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckCTAComponentInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check CTA Component in mobile view", new string[] {
                        "SIT"});
#line 14
 this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I am on presales /dev/call-to-action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("I expect the correct CTA CSS values to appear for mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check CTA Component button links internally")]
        [Xunit.TraitAttribute("FeatureTitle", "CallToAction")]
        [Xunit.TraitAttribute("Description", "Check CTA Component button links internally")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckCTAComponentButtonLinksInternally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check CTA Component button links internally", new string[] {
                        "SIT"});
#line 20
 this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am on presales /dev/call-to-action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.When("I click on CTA Internal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("I expect the presales / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check CTA Component button links externally")]
        [Xunit.TraitAttribute("FeatureTitle", "CallToAction")]
        [Xunit.TraitAttribute("Description", "Check CTA Component button links externally")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckCTAComponentButtonLinksExternally()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check CTA Component button links externally", new string[] {
                        "SIT"});
#line 26
 this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I am on presales /dev/call-to-action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("I click on CTA External button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I see the http://www.bbc.co.uk/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CallToActionFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CallToActionFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
