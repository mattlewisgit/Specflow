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
namespace Vitality.Website.IntegrationTests.Features.Presales
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ArticleIndexFeature : Xunit.IClassFixture<ArticleIndexFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ArticleIndex.feature"
#line hidden
        
        public ArticleIndexFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ArticleIndex", "\tIn order to avoid silly mistakes\r\n\tAs a Article Index user\r\n\tI want to be able t" +
                    "o view Article Index", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(ArticleIndexFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Article index display in full view")]
        [Xunit.TraitAttribute("FeatureTitle", "ArticleIndex")]
        [Xunit.TraitAttribute("Description", "Check Article index display in full view")]
        [Xunit.TraitAttribute("Category", "Presales")]
        [Xunit.TraitAttribute("Category", "ArticleIndex")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckArticleIndexDisplayInFullView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Article index display in full view", new string[] {
                        "Presales",
                        "ArticleIndex",
                        "SIT"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I am on presales /dev/article-index", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("I expect the correct CSS Article Index values to appear in full view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Article index display in mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "ArticleIndex")]
        [Xunit.TraitAttribute("Description", "Check Article index display in mobile view")]
        [Xunit.TraitAttribute("Category", "Presales")]
        [Xunit.TraitAttribute("Category", "ArticleIndex")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckArticleIndexDisplayInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Article index display in mobile view", new string[] {
                        "Presales",
                        "ArticleIndex",
                        "SIT"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I am on presales /dev/article-index", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("I expect the correct CSS Article Index values to appear in mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Article index card link works in full view")]
        [Xunit.TraitAttribute("FeatureTitle", "ArticleIndex")]
        [Xunit.TraitAttribute("Description", "Check Article index card link works in full view")]
        [Xunit.TraitAttribute("Category", "Presales")]
        [Xunit.TraitAttribute("Category", "ArticleIndex")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckArticleIndexCardLinkWorksInFullView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Article index card link works in full view", new string[] {
                        "Presales",
                        "ArticleIndex",
                        "SIT"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am on presales /dev/article-index", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.When("I click on Article Index Active Rewards card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I expect the presales /rewards/partners/active-rewards/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Article index card link works in  mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "ArticleIndex")]
        [Xunit.TraitAttribute("Description", "Check Article index card link works in  mobile view")]
        [Xunit.TraitAttribute("Category", "Presales")]
        [Xunit.TraitAttribute("Category", "ArticleIndex")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckArticleIndexCardLinkWorksInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Article index card link works in  mobile view", new string[] {
                        "Presales",
                        "ArticleIndex",
                        "SIT"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I am on presales /dev/article-index", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.And("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I click on Article Index The healthy food hall card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("I expect the presales /rewards/partners/healthy-eating/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ArticleIndexFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ArticleIndexFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion