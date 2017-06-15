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
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void TestNavigationToBusiness()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Navigation to Business", new string[] {
                        "SIT"});
#line 7
    this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.When("I click on the Business section link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I expect the presales /business/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Test Navigation to Advisers")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Test Navigation to Advisers")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void TestNavigationToAdvisers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Navigation to Advisers", new string[] {
                        "SIT"});
#line 13
    this.ScenarioSetup(scenarioInfo);
#line 14
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
    testRunner.When("I click on the Advisers section link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("I expect the presales /advisers/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Test Navigation to Personal")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Test Navigation to Personal")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void TestNavigationToPersonal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Navigation to Personal", new string[] {
                        "SIT"});
#line 19
    this.ScenarioSetup(scenarioInfo);
#line 20
    testRunner.Given("I am on presales /business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
    testRunner.When("I click on the Personal section link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("I expect the presales / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Click Navigation Logo")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Click Navigation Logo")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void ClickNavigationLogo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Click Navigation Logo", new string[] {
                        "SIT"});
#line 25
 this.ScenarioSetup(scenarioInfo);
#line 26
    testRunner.Given("I am on presales /business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
    testRunner.When("I click on the navigation logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("I expect the presales / to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Resize home page to Mobile view and check for hamburger")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Resize home page to Mobile view and check for hamburger")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void ResizeHomePageToMobileViewAndCheckForHamburger()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resize home page to Mobile view and check for hamburger", new string[] {
                        "SIT"});
#line 31
    this.ScenarioSetup(scenarioInfo);
#line 32
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
    testRunner.Then("I expect the hamburger to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Resize home page from Mobile view to Full-screen and check that hamburger invisib" +
            "le")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Resize home page from Mobile view to Full-screen and check that hamburger invisib" +
            "le")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void ResizeHomePageFromMobileViewToFull_ScreenAndCheckThatHamburgerInvisible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resize home page from Mobile view to Full-screen and check that hamburger invisib" +
                    "le", new string[] {
                        "SIT"});
#line 37
    this.ScenarioSetup(scenarioInfo);
#line 38
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
    testRunner.And("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
    testRunner.Then("I expect the hamburger to be invisible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Member Zone login components show in Mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check Member Zone login components show in Mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckMemberZoneLoginComponentsShowInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Member Zone login components show in Mobile view", new string[] {
                        "SIT"});
#line 44
    this.ScenarioSetup(scenarioInfo);
#line 45
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
    testRunner.And("I click on the Login (small) button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.Then("I expect the Navigation Login button Member Zone to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.And("I expect the Navigation Login button Health Advisers to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Member Zone login components show in Full-screen view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check Member Zone login components show in Full-screen view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckMemberZoneLoginComponentsShowInFull_ScreenView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Member Zone login components show in Full-screen view", new string[] {
                        "SIT"});
#line 52
    this.ScenarioSetup(scenarioInfo);
#line 53
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
    testRunner.When("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
    testRunner.And("I click on the Login (large) button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then("I expect the Navigation Login button Member Zone to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("I expect the Navigation Login button Health Advisers to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Resize home page from Mobile view to Full-screen and check that footer visible")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Resize home page from Mobile view to Full-screen and check that footer visible")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void ResizeHomePageFromMobileViewToFull_ScreenAndCheckThatFooterVisible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resize home page from Mobile view to Full-screen and check that footer visible", new string[] {
                        "SIT"});
#line 60
    this.ScenarioSetup(scenarioInfo);
#line 61
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
    testRunner.And("I resize to full-screen view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
    testRunner.Then("I expect the Health insurance quote button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
    testRunner.And("I expect the Life insurance quote button to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="resize home page Mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "resize home page Mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void ResizeHomePageMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("resize home page Mobile view", new string[] {
                        "SIT"});
#line 68
    this.ScenarioSetup(scenarioInfo);
#line 69
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check Footer links work in Mobile view")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check Footer links work in Mobile view")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckFooterLinksWorkInMobileView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Footer links work in Mobile view", new string[] {
                        "SIT"});
#line 73
    this.ScenarioSetup(scenarioInfo);
#line 74
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
    testRunner.When("I resize to mobile view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
    testRunner.And("I expand the mobile footer section Get a quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.And("I click on the footer mobile link Health insurance quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check console logs on presales")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check console logs on presales")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckConsoleLogsOnPresales()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check console logs on presales", new string[] {
                        "SIT"});
#line 81
    this.ScenarioSetup(scenarioInfo);
#line 82
    testRunner.Given("I am on presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
 testRunner.Then("I should not see any console logs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Check console logs on advisers")]
        [Xunit.TraitAttribute("FeatureTitle", "Main Navigation")]
        [Xunit.TraitAttribute("Description", "Check console logs on advisers")]
        [Xunit.TraitAttribute("Category", "SIT")]
        public virtual void CheckConsoleLogsOnAdvisers()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check console logs on advisers", new string[] {
                        "SIT"});
#line 86
    this.ScenarioSetup(scenarioInfo);
#line 87
    testRunner.Given("I am on advisers /dev", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
 testRunner.Then("I should not see any console logs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
