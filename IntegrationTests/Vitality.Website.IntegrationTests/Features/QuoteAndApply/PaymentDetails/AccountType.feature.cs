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
namespace Vitality.Website.IntegrationTests.Features.QuoteAndApply.PaymentDetails
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AccountTypeFeature : Xunit.IClassFixture<AccountTypeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AccountType.feature"
#line hidden
        
        public AccountTypeFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AccountType", "\tIn order to validation the account type field\r\n\tAs a quote and apply user\r\n\tI wa" +
                    "nt to be able to check the account type field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(AccountTypeFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Account type - Joint account holder name")]
        [Xunit.TraitAttribute("FeatureTitle", "AccountType")]
        [Xunit.TraitAttribute("Description", "Payment Details - Account type - Joint account holder name")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_AccountType_JointAccountHolderName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Account type - Joint account holder name", new string[] {
                        "QuoteAndApply"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
    testRunner.Given("I am on presales /dev/quote-payment-details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
    testRunner.When("I go to the accountType field and choose a joint account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then("I don\'t see the accountType field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Account type - An individual account holder name")]
        [Xunit.TraitAttribute("FeatureTitle", "AccountType")]
        [Xunit.TraitAttribute("Description", "Payment Details - Account type - An individual account holder name")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_AccountType_AnIndividualAccountHolderName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Account type - An individual account holder name", new string[] {
                        "QuoteAndApply"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("I am on presales /dev/quote-payment-details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.When("I go to the accountType field and choose an individual account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
    testRunner.Then("I don\'t see the accountType field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AccountTypeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AccountTypeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
