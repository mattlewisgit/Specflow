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
    public partial class EmailFieldFeature : Xunit.IClassFixture<EmailFieldFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EmailField.feature"
#line hidden
        
        public EmailFieldFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EmailField", "\tIn order to validation the email field\r\n\tAs a quote and apply user\r\n\tI want to b" +
                    "e able to check the email field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(EmailFieldFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Email - Check error message when email format incorrect #1")]
        [Xunit.TraitAttribute("FeatureTitle", "EmailField")]
        [Xunit.TraitAttribute("Description", "Email - Check error message when email format incorrect #1")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void Email_CheckErrorMessageWhenEmailFormatIncorrect1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email - Check error message when email format incorrect #1", new string[] {
                        "QuoteAndApply"});
#line 7
    this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
    testRunner.When("I go to the emailAddress field and enter test.user@gmail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then("I see the emailAddress field error text Please enter valid email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Email - Check error message when email format incorrect #2")]
        [Xunit.TraitAttribute("FeatureTitle", "EmailField")]
        [Xunit.TraitAttribute("Description", "Email - Check error message when email format incorrect #2")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void Email_CheckErrorMessageWhenEmailFormatIncorrect2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email - Check error message when email format incorrect #2", new string[] {
                        "QuoteAndApply"});
#line 14
    this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
    testRunner.When("I go to the emailAddress field and enter @gmail.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
    testRunner.Then("I see the emailAddress field error text Please enter valid email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Email - User enters a valid email address")]
        [Xunit.TraitAttribute("FeatureTitle", "EmailField")]
        [Xunit.TraitAttribute("Description", "Email - User enters a valid email address")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void Email_UserEntersAValidEmailAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email - User enters a valid email address", new string[] {
                        "QuoteAndApply"});
#line 21
    this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
    testRunner.When("I go to the emailAddress field and enter test.user@gmail.co.uk", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.Then("I don\'t see the emailAddress field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                EmailFieldFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                EmailFieldFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
