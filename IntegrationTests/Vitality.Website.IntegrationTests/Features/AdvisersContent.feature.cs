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
    public partial class HealthAdvisersContentFeature : Xunit.IClassFixture<HealthAdvisersContentFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AdvisersContent.feature"
#line hidden
        
        public HealthAdvisersContentFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Health Advisers Content", "\tIn order to test that the Vitality Health Advisers site is correct\r\n\tAs a Tester" +
                    "\r\n\tI want to perform basic navigation and content tests", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(HealthAdvisersContentFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to the Life Insurance landing page, Login to Adviser Hub")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to the Life Insurance landing page, Login to Adviser Hub")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToTheLifeInsuranceLandingPageLoginToAdviserHub()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to the Life Insurance landing page, Login to Adviser Hub", new string[] {
                        "Production"});
#line 7
 this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on production advisers /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I hover over Life Insurance and click on Life Insurance Home", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I go to the Adviser Hub cta and I click on the Login page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then("I see the https://adviser.vitality.co.uk/life/online/manualLogin page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to the Personal Protection landing page, view Life Cover product page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to the Personal Protection landing page, view Life Cover product page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToThePersonalProtectionLandingPageViewLifeCoverProductPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to the Personal Protection landing page, view Life Cover product page", new string[] {
                        "Production"});
#line 14
 this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("I am on production advisers /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I hover over Life Insurance and click on Personal Protection Home", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.And("I go to the Life Cover cards stacked and I click on the Learn more page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.Then("I expect the production advisers /life-insurance/personal/life-cover/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to the Business Protection landing page, view Relevant Life Cover produc" +
            "t page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to the Business Protection landing page, view Relevant Life Cover produc" +
            "t page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToTheBusinessProtectionLandingPageViewRelevantLifeCoverProductPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to the Business Protection landing page, view Relevant Life Cover produc" +
                    "t page", new string[] {
                        "Production"});
#line 21
 this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am on production advisers /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("I hover over Life Insurance and click on Business Protection Home", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.And("I go to the Relevant Life Cover cards stacked and I click on the Find out more pa" +
                    "ge link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("I expect the production advisers /life-insurance/business/relevant-life-cover/ to" +
                    " open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to the Health Insurance landing page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to the Health Insurance landing page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToTheHealthInsuranceLandingPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to the Health Insurance landing page", new string[] {
                        "Production"});
#line 28
 this.ScenarioSetup(scenarioInfo);
#line 29
    testRunner.Given("I am on production advisers /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.When("I hover over Health Insurance and click on Health insurance overview", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("I expect the production advisers /health-insurance/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to the Personal Health Insurance landing page, Login to Adviser Services" +
            "")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to the Personal Health Insurance landing page, Login to Adviser Services" +
            "")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToThePersonalHealthInsuranceLandingPageLoginToAdviserServices()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to the Personal Health Insurance landing page, Login to Adviser Services" +
                    "", new string[] {
                        "Production"});
#line 34
 this.ScenarioSetup(scenarioInfo);
#line 35
    testRunner.Given("I am on production advisers /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.When("I hover over Health Insurance and click on Personal Health Insurance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.And("I go to the Login and get a quote cta and I click on the Get a quote page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.Then("I see the https://login.vitality.co.uk/medical/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Health Sales Literature, Lit tool displays")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Health Sales Literature, Lit tool displays")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToHealthSalesLiteratureLitToolDisplays()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Health Sales Literature, Lit tool displays", new string[] {
                        "Production"});
#line 41
 this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.Given("I am on production advisers /resources/literature/health-insurance-sales-literatu" +
                    "re/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
 testRunner.When("I search for Personal Healthcare document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("I expect the Personal Healthcare document to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.And("I expect the download and email  buttons to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Health Member Literature, Lit tool displays")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Advisers Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Health Member Literature, Lit tool displays")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToHealthMemberLiteratureLitToolDisplays()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Health Member Literature, Lit tool displays", new string[] {
                        "Production"});
#line 48
 this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("I am on production advisers /resources/literature/health-insurance-member-literat" +
                    "ure/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("I enter plan start date 1 12 2016", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.When("click on the submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.And("I select on Personal Healthcare Plan terms and conditions Literature", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("I expect the Personal Healthcare Plan terms and conditions document to be visible" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("I expect the download and email  buttons to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                HealthAdvisersContentFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                HealthAdvisersContentFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
