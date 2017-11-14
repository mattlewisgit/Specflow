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
    public partial class PostalAddressFeature : Xunit.IClassFixture<PostalAddressFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PostalAddress.feature"
#line hidden
        
        public PostalAddressFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PostalAddress", "\tIn order to validation the Direct Debit Postal Address Field\r\n\tAs a quote and ap" +
                    "ply user\r\n\tI want to be able to check the Direct Debit Postal Address Field", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void SetFixture(PostalAddressFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Postal Address - Check Postcode Field does not have errors")]
        [Xunit.TraitAttribute("FeatureTitle", "PostalAddress")]
        [Xunit.TraitAttribute("Description", "Payment Details - Postal Address - Check Postcode Field does not have errors")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_PostalAddress_CheckPostcodeFieldDoesNotHaveErrors()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Postal Address - Check Postcode Field does not have errors", new string[] {
                        "QuoteAndApply"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I am on presales /dev/quote-payment-details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.When("I go to the billingPostcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
    testRunner.Then("I don\'t see the billingPostcode field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Postal Address - Check Billing Address Returns Vitality Address" +
            "")]
        [Xunit.TraitAttribute("FeatureTitle", "PostalAddress")]
        [Xunit.TraitAttribute("Description", "Payment Details - Postal Address - Check Billing Address Returns Vitality Address" +
            "")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_PostalAddress_CheckBillingAddressReturnsVitalityAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Postal Address - Check Billing Address Returns Vitality Address" +
                    "", new string[] {
                        "QuoteAndApply"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
    testRunner.Given("I am on presales /dev/quote-payment-details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
    testRunner.When("I go to the billingPostcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
    testRunner.And("I go to the button field and click on the button Find Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
    testRunner.And("I go to the selectBillingAddress field and I choose the dropdown MARSHALL POINT, " +
                    "4 RICHMOND GARDENS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
    testRunner.Then("I don\'t see the billingPostcode field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Postal Address - Check manual address fields appear")]
        [Xunit.TraitAttribute("FeatureTitle", "PostalAddress")]
        [Xunit.TraitAttribute("Description", "Payment Details - Postal Address - Check manual address fields appear")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_PostalAddress_CheckManualAddressFieldsAppear()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Postal Address - Check manual address fields appear", new string[] {
                        "QuoteAndApply"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am on presales /dev/quote-payment-details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.When("I go to the billingPostcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
    testRunner.And("I go to the button field and click on the button Find Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.And("I enter the postal address manually and click on click here", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.Then("I expect the postal address address1 to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
    testRunner.And("I expect the postal address address2 to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
    testRunner.And("I expect the postal address address3 to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
    testRunner.And("I expect the postal address test to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
    testRunner.And("I expect the postal address postcode to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Postal Address - Manually entering an address")]
        [Xunit.TraitAttribute("FeatureTitle", "PostalAddress")]
        [Xunit.TraitAttribute("Description", "Payment Details - Postal Address - Manually entering an address")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_PostalAddress_ManuallyEnteringAnAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Postal Address - Manually entering an address", new string[] {
                        "QuoteAndApply"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
    testRunner.Given("I am on presales /dev/quote-payment-details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
    testRunner.When("I go to the billingPostcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
    testRunner.And("I go to the button field and click on the button Find Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
    testRunner.And("I enter the postal address manually and click on click here", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
    testRunner.And("I go to the address1 field and enter MARSHALL POINT", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
    testRunner.And("I go to the address2 field and enter 4 RICHMOND GARDENS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
    testRunner.And("I go to the address3 field and enter BOURNEMOUTH", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
    testRunner.And("I go to the address4 field and enter DORSET", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
    testRunner.And("I go to the postcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
    testRunner.Then("I don\'t see the billingPostcode field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Payment Details - Postal Address - Check postcode is autopopulated")]
        [Xunit.TraitAttribute("FeatureTitle", "PostalAddress")]
        [Xunit.TraitAttribute("Description", "Payment Details - Postal Address - Check postcode is autopopulated")]
        [Xunit.TraitAttribute("Category", "QuoteAndApply")]
        public virtual void PaymentDetails_PostalAddress_CheckPostcodeIsAutopopulated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Payment Details - Postal Address - Check postcode is autopopulated", new string[] {
                        "QuoteAndApply"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
    testRunner.Given("I am on presales /dev/quote-and-apply", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
    testRunner.And("I see the Quote And Apply page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
    testRunner.And("I go to the title field and choose Mrs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
    testRunner.And("I go to the firstName field and enter Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
    testRunner.And("I go to the lastName field and enter User", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I go to the dateOfBirth field and enter 01/01/1970", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
    testRunner.And("I go to the phoneNumber field and enter 01202 223344", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
    testRunner.And("I go to the emailAddress field and enter test.user@gmail.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I go to the postcode field and enter BH1 1JD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
    testRunner.And("I go to the insuredStatus field and choose currently insured", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
    testRunner.And("I go to the noOfClaimFreeYears field and choose 1 year", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
    testRunner.And("I go to the noOfClaims field and choose no claims", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
    testRunner.And("I go to the coverStartDate field and make the date today plus 0 days", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
    testRunner.And("I go to the membersToInsure field and choose just me", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
    testRunner.And("I go to the Discounted gym membership checkbox field and select the value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
    testRunner.And("I go to the marketingPermission field and choose Agreed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I see that the Progress Bar is not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
    testRunner.And("I see that the quote and apply Apply button is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I click on the quote and apply Apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
    testRunner.And("I see the Quote Results page feed load has completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.Then("I expect the presales /dev/quote-result to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
    testRunner.When("I click on the quote result BUY ONLINE button link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
    testRunner.Then("I expect the presales /dev/quote-payment-details to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
    testRunner.Then("I expect the billingPostcode field to autopopulate with the correct information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
    testRunner.Then("I don\'t see the billingPostcode field error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                PostalAddressFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PostalAddressFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
