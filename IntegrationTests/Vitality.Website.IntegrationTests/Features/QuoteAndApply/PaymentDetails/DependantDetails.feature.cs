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
    public partial class DependantDetailsFeature : Xunit.IClassFixture<DependantDetailsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DependantDetails.feature"
#line hidden
        
        public DependantDetailsFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DependantDetails", "\tIn order to validation the dependant details field\r\n\tAs a quote and apply user\r\n" +
                    "\tI want to be able to check the dependant details field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(DependantDetailsFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Dependant Details - Check Partner DOB is autopopulated")]
        [Xunit.TraitAttribute("FeatureTitle", "DependantDetails")]
        [Xunit.TraitAttribute("Description", "Payment Details - Dependant Details - Check Partner DOB is autopopulated")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_DependantDetails_CheckPartnerDOBIsAutopopulated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Dependant Details - Check Partner DOB is autopopulated", new string[] {
                        "QuoteAndApply"});
#line 8
    this.ScenarioSetup(scenarioInfo);
#line 9
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
    testRunner.And("I go to the title field and choose Mrs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
    testRunner.And("I go to the firstName field and enter Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
    testRunner.And("I go to the lastName field and enter User", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I go to the dateOfBirth field and enter 01/01/1970", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
    testRunner.And("I go to the phoneNumber field and enter 01202 223344", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
    testRunner.And("I go to the emailAddress field and enter test.user@gmail.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I go to the postcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
    testRunner.And("I go to the insuredStatus field and choose currently insured", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
    testRunner.And("I go to the noOfClaimFreeYears field and choose 1 year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
    testRunner.And("I go to the noOfClaims field and choose no claims", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
    testRunner.And("I go to the coverStartDate field and make the date today plus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
    testRunner.And("I go to the membersToInsure field and choose me and my partner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
    testRunner.And("I go to the partnerDateOfBirth field and enter 20/01/1990", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
    testRunner.And("I go to the Discounted gym membership checkbox field and select the value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.And("I go to the marketingPermission field and choose Agreed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I see that the Progress Bar is not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
    testRunner.And("I see that the quote and apply Apply button is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I click on the quote and apply Apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
    testRunner.And("I see the Quote Results page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("I expect the presales /dev/quote-result to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
    testRunner.When("I click on the quote result BUY ONLINE button link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
    testRunner.Then("I expect the presales /dev/quote-payment-details to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
    testRunner.Then("I expect the partnerDateOfBirth field to autopopulate with the correct informatio" +
                    "n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
    testRunner.Then("I don\'t see the partnerDateOfBirth field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Dependant Details - Check Child 1 DOB is autopopulated")]
        [Xunit.TraitAttribute("FeatureTitle", "DependantDetails")]
        [Xunit.TraitAttribute("Description", "Payment Details - Dependant Details - Check Child 1 DOB is autopopulated")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_DependantDetails_CheckChild1DOBIsAutopopulated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Dependant Details - Check Child 1 DOB is autopopulated", new string[] {
                        "QuoteAndApply"});
#line 37
    this.ScenarioSetup(scenarioInfo);
#line 38
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
    testRunner.And("I go to the title field and choose Mrs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
    testRunner.And("I go to the firstName field and enter Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
    testRunner.And("I go to the lastName field and enter User", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I go to the dateOfBirth field and enter 01/01/1970", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
    testRunner.And("I go to the phoneNumber field and enter 01202 223344", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
    testRunner.And("I go to the emailAddress field and enter test.user@gmail.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I go to the postcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
    testRunner.And("I go to the insuredStatus field and choose currently insured", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
    testRunner.And("I go to the noOfClaimFreeYears field and choose 1 year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
    testRunner.And("I go to the noOfClaims field and choose no claims", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
    testRunner.And("I go to the coverStartDate field and make the date today plus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
    testRunner.And("I go to the membersToInsure field and choose me and my kids", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
    testRunner.And("I go to the noOfChildren field and choose kid\'s", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
    testRunner.And("I go to the childDob1 field and enter 01/01/2010", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
    testRunner.And("I go to the Discounted gym membership checkbox field and select the value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
    testRunner.And("I go to the marketingPermission field and choose Agreed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I see that the Progress Bar is not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
    testRunner.And("I see that the quote and apply Apply button is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I click on the quote and apply Apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
    testRunner.And("I see the Quote Results page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("I expect the presales /dev/quote-result to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
    testRunner.When("I click on the quote result BUY ONLINE button link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
    testRunner.Then("I expect the presales /dev/quote-payment-details to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
    testRunner.Then("I expect the childDob1 field to autopopulate with the correct information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
    testRunner.Then("I don\'t see the partnerDateOfBirth field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Dependant Details - Check Partner and 4 children DOB is autopop" +
            "ulated")]
        [Xunit.TraitAttribute("FeatureTitle", "DependantDetails")]
        [Xunit.TraitAttribute("Description", "Payment Details - Dependant Details - Check Partner and 4 children DOB is autopop" +
            "ulated")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_DependantDetails_CheckPartnerAnd4ChildrenDOBIsAutopopulated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Dependant Details - Check Partner and 4 children DOB is autopop" +
                    "ulated", new string[] {
                        "QuoteAndApply"});
#line 67
    this.ScenarioSetup(scenarioInfo);
#line 68
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
    testRunner.And("I go to the title field and choose Mrs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
    testRunner.And("I go to the firstName field and enter Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
    testRunner.And("I go to the lastName field and enter User", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("I go to the dateOfBirth field and enter 01/01/1970", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
    testRunner.And("I go to the phoneNumber field and enter 01202 223344", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
    testRunner.And("I go to the emailAddress field and enter test.user@gmail.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I go to the postcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.And("I go to the insuredStatus field and choose currently insured", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
    testRunner.And("I go to the noOfClaimFreeYears field and choose 1 year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
    testRunner.And("I go to the noOfClaims field and choose no claims", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
    testRunner.And("I go to the coverStartDate field and make the date today plus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
    testRunner.And("I go to the membersToInsure field and choose me, my partner and kids", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
    testRunner.And("I go to the partnerDateOfBirth field and enter 20/01/1990", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
    testRunner.And("I go to the noOfChildren field and choose 4 kids\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
    testRunner.And("I go to the childDob1 field and enter 01/01/2010", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
    testRunner.And("I go to the childDob2 field and enter 01/01/2011", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
    testRunner.And("I go to the childDob3 field and enter 01/01/2012", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
    testRunner.And("I go to the childDob4 field and enter 01/01/2013", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
    testRunner.And("I go to the Discounted gym membership checkbox field and select the value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
    testRunner.And("I go to the marketingPermission field and choose Agreed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("I see that the Progress Bar is not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
    testRunner.And("I see that the quote and apply Apply button is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I click on the quote and apply Apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
    testRunner.And("I see the Quote Results page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.Then("I expect the presales /dev/quote-result to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
    testRunner.When("I click on the quote result BUY ONLINE button link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
    testRunner.Then("I expect the presales /dev/quote-payment-details to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
    testRunner.And("I expect the partnerDateOfBirth field to autopopulate with the correct informatio" +
                    "n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
    testRunner.And("I expect the child1Dob field to autopopulate with the correct information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
    testRunner.And("I expect the child2Dob field to autopopulate with the correct information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
    testRunner.And("I expect the child3Dob field to autopopulate with the correct information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
    testRunner.And("I expect the child4Dob field to autopopulate with the correct information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                DependantDetailsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DependantDetailsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
