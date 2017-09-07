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
    public partial class PostcodeFieldFeature : Xunit.IClassFixture<PostcodeFieldFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PostcodeField.feature"
#line hidden
        
        public PostcodeFieldFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PostcodeField", "\tIn order to validation the postcode field\r\n\tAs a quote and apply user\r\n\tI want t" +
                    "o be able to check the postcode field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(PostcodeFieldFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Postcode - Check error message does not appears when postCode is valid #6 values")]
        [Xunit.TraitAttribute("FeatureTitle", "PostcodeField")]
        [Xunit.TraitAttribute("Description", "Postcode - Check error message does not appears when postCode is valid #6 values")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void Postcode_CheckErrorMessageDoesNotAppearsWhenPostCodeIsValid6Values()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Postcode - Check error message does not appears when postCode is valid #6 values", new string[] {
                        "QuoteAndApply"});
#line 7
    this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
    testRunner.When("I go to the postcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then("I don\'t see the postcode field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Postcode - Check error message does not appears when postCode is valid #7 values")]
        [Xunit.TraitAttribute("FeatureTitle", "PostcodeField")]
        [Xunit.TraitAttribute("Description", "Postcode - Check error message does not appears when postCode is valid #7 values")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void Postcode_CheckErrorMessageDoesNotAppearsWhenPostCodeIsValid7Values()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Postcode - Check error message does not appears when postCode is valid #7 values", new string[] {
                        "QuoteAndApply"});
#line 14
    this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
    testRunner.When("I go to the postcode field and enter BH20 6HH", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
    testRunner.Then("I don\'t see the postcode field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Postcode - Check error message when postCode is invalid")]
        [Xunit.TraitAttribute("FeatureTitle", "PostcodeField")]
        [Xunit.TraitAttribute("Description", "Postcode - Check error message when postCode is invalid")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void Postcode_CheckErrorMessageWhenPostCodeIsInvalid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Postcode - Check error message when postCode is invalid", new string[] {
                        "QuoteAndApply"});
#line 21
    this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
    testRunner.When("I go to the postcode field and enter BH 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.Then("I see the postcode field error text Please enter valid postcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                PostcodeFieldFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PostcodeFieldFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion