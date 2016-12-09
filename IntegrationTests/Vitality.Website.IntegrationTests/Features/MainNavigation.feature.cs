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
    public partial class MainNavigationFeature : Xunit.IClassFixture<MainNavigationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MainNavigation.feature"
#line hidden
        
        public MainNavigationFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Main Navigation", "    In order to test that the Main Navigation works\r\n    As a Tester\r\n    I want " +
                    "to perform basic navigation tests", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(MainNavigationFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Test Navigation to Business")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Test Navigation to Business")]
        public virtual void TestNavigationToBusiness()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Navigation to Business", ((string[])(null)));
#line 6
    this.ScenarioSetup(scenarioInfo);
#line 7
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
    testRunner.When("I click on the Business section link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
    testRunner.Then("I expect the /business/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Test Navigation to Advisers")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Test Navigation to Advisers")]
        public virtual void TestNavigationToAdvisers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Navigation to Advisers", ((string[])(null)));
#line 11
    this.ScenarioSetup(scenarioInfo);
#line 12
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
    testRunner.When("I click on the Advisers section link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
    testRunner.Then("I expect the /advisers/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Test Navigation to Personal")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Test Navigation to Personal")]
        public virtual void TestNavigationToPersonal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Navigation to Personal", ((string[])(null)));
#line 16
    this.ScenarioSetup(scenarioInfo);
#line 17
    testRunner.Given("I am on the /business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
    testRunner.When("I click on the Personal section link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
    testRunner.Then("I expect the / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Click Navigation Logo")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Click Navigation Logo")]
        public virtual void ClickNavigationLogo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Click Navigation Logo", ((string[])(null)));
#line 21
    this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am on the /business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.When("I click on the navigation logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
    testRunner.Then("I expect the / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Resize home page to Mobile view and check for hamburger")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Resize home page to Mobile view and check for hamburger")]
        public virtual void ResizeHomePageToMobileViewAndCheckForHamburger()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resize home page to Mobile view and check for hamburger", ((string[])(null)));
#line 26
    this.ScenarioSetup(scenarioInfo);
#line 27
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
    testRunner.Then("I expect the hamburger to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Resize home page from Mobile view to Full-screen and check that hamburger invisib" +
            "le")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Resize home page from Mobile view to Full-screen and check that hamburger invisib" +
            "le")]
        public virtual void ResizeHomePageFromMobileViewToFull_ScreenAndCheckThatHamburgerInvisible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resize home page from Mobile view to Full-screen and check that hamburger invisib" +
                    "le", ((string[])(null)));
#line 31
    this.ScenarioSetup(scenarioInfo);
#line 32
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
    testRunner.And("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
    testRunner.Then("I expect the hamburger to be invisible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Member Zone login components show in Mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check Member Zone login components show in Mobile view")]
        public virtual void CheckMemberZoneLoginComponentsShowInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Member Zone login components show in Mobile view", ((string[])(null)));
#line 37
    this.ScenarioSetup(scenarioInfo);
#line 38
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
    testRunner.And("I click on the Login (small) button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
    testRunner.Then("I expect the Member Zone button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
    testRunner.And("I expect the Health Advisers button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
    testRunner.And("I expect the Life Advisers button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Member Zone login components show in Full-screen view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check Member Zone login components show in Full-screen view")]
        public virtual void CheckMemberZoneLoginComponentsShowInFull_ScreenView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Member Zone login components show in Full-screen view", ((string[])(null)));
#line 45
    this.ScenarioSetup(scenarioInfo);
#line 46
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
    testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
    testRunner.And("I click on the Login (large) button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
    testRunner.Then("I expect the Member Zone button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
    testRunner.And("I expect the Health Advisers button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
    testRunner.And("I expect the Life Advisers button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Resize home page from Mobile view to Full-screen and check that footer visible")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Resize home page from Mobile view to Full-screen and check that footer visible")]
        public virtual void ResizeHomePageFromMobileViewToFull_ScreenAndCheckThatFooterVisible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resize home page from Mobile view to Full-screen and check that footer visible", ((string[])(null)));
#line 53
    this.ScenarioSetup(scenarioInfo);
#line 54
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
    testRunner.And("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
    testRunner.Then("I expect the Health insurance quote button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
    testRunner.And("I expect the Life insurance quote button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check footer pop up component show in Mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check footer pop up component show in Mobile view")]
        public virtual void CheckFooterPopUpComponentShowInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check footer pop up component show in Mobile view", ((string[])(null)));
#line 60
    this.ScenarioSetup(scenarioInfo);
#line 61
    testRunner.Given("I am on the /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
    testRunner.And("I click on the footer button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
    testRunner.Then("I expect the Health insurance quote button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
    testRunner.And("I expect the Life insurance quote button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                MainNavigationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                MainNavigationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
