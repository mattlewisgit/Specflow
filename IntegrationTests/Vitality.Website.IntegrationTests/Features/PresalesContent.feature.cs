// ------------------------------------------------------------------------------
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
    public partial class HealthPresalesContentFeature : Xunit.IClassFixture<HealthPresalesContentFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PresalesContent.feature"
#line hidden
        
        public HealthPresalesContentFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Health Presales Content", "\tIn order to test that the Vitality Health Presales site is correct\r\n\tAs a Tester" +
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
        
        public virtual void SetFixture(HealthPresalesContentFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Health Insurance Menu, Get a Quote")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Health Insurance Menu, Get a Quote")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToHealthInsuranceMenuGetAQuote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Health Insurance Menu, Get a Quote", new string[] {
                        "Production"});
#line 7
 this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I hover over Health Insurance and click on Get a quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Health Insurance Menu, Health insurance quote page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Health Insurance Menu, Health insurance quote page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToHealthInsuranceMenuHealthInsuranceQuotePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Health Insurance Menu, Health insurance quote page", new string[] {
                        "Production"});
#line 13
 this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.When("I hover over Health Insurance and click on Health insurance quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("I expect the production presales /health-insurance/quote/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Core Cover, Awards page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Core Cover, Awards page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToCoreCoverAwardsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Core Cover, Awards page", new string[] {
                        "Production"});
#line 19
 this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.When("I hover over Health Insurance and click on Core Cover", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And("I go to the Award-winning cover feature block and I click on the Learn more page " +
                    "link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("I expect the production presales /about/awards/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Cover Options, Get a quote page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Cover Options, Get a quote page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToCoverOptionsGetAQuotePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Cover Options, Get a quote page", new string[] {
                        "Production"});
#line 26
 this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("I hover over Health Insurance and click on Cover Options", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.And("I click on the Get a quote page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Switch to Vitality link to anchored text on another page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Switch to Vitality link to anchored text on another page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToSwitchToVitalityLinkToAnchoredTextOnAnotherPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Switch to Vitality link to anchored text on another page", new string[] {
                        "Production"});
#line 33
 this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.When("I hover over Health Insurance and click on Switch to Vitality", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.And("I go to the A Full Cover Promise feature block and I click on the Read more page " +
                    "link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.Then("I expect the production presales /health-insurance/core-cover/in-patient/#anchor_" +
                    "1470237471794 to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Switch to Vitality, Rewards page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Switch to Vitality, Rewards page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToSwitchToVitalityRewardsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Switch to Vitality, Rewards page", new string[] {
                        "Production"});
#line 40
 this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.When("I hover over Health Insurance and click on Switch to Vitality", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.And("I go to the Rewards for a healthy lifestyle feature block and I click on the Lear" +
                    "n more page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("I expect the production presales /rewards/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Vitality GP, Get a Quote page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Vitality GP, Get a Quote page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToVitalityGPGetAQuotePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Vitality GP, Get a Quote page", new string[] {
                        "Production"});
#line 47
 this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.When("I hover over Health Insurance and click on Vitality GP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.And("I go to the Ready to apply online cta and I click on the Get a quote page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Vitality GP, Hospitals page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Vitality GP, Hospitals page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToVitalityGPHospitalsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Vitality GP, Hospitals page", new string[] {
                        "Production"});
#line 54
 this.ScenarioSetup(scenarioInfo);
#line 55
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
 testRunner.When("I hover over Health Insurance and click on Vitality GP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.And("I go to the Choose your treatment pathway cards stacked and I click on the Learn " +
                    "more page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("I expect the production presales /health-insurance/hospitals/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Vitality GP, Extended Cancer Cover page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Vitality GP, Extended Cancer Cover page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToVitalityGPExtendedCancerCoverPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Vitality GP, Extended Cancer Cover page", new string[] {
                        "Production"});
#line 61
 this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.When("I hover over Health Insurance and click on Vitality GP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.And("I go to the Extended Cancer Cover cards stacked and I click on the Learn more pag" +
                    "e link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("I expect the production presales /health-insurance/core-cover/cancer/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Vitality GP, Full Cover Promise page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Vitality GP, Full Cover Promise page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToVitalityGPFullCoverPromisePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Vitality GP, Full Cover Promise page", new string[] {
                        "Production"});
#line 68
 this.ScenarioSetup(scenarioInfo);
#line 69
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
 testRunner.When("I hover over Health Insurance and click on Vitality GP", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.And("I go to the Full Cover Promise cards stacked and I click on the Learn more page l" +
                    "ink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.Then("I expect the production presales /health-insurance/core-cover/in-patient/ to open" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigated to Life insurance menu, Get a quote")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigated to Life insurance menu, Get a quote")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigatedToLifeInsuranceMenuGetAQuote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigated to Life insurance menu, Get a quote", new string[] {
                        "Production"});
#line 75
 this.ScenarioSetup(scenarioInfo);
#line 76
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
 testRunner.When("I hover over Life Insurance and click on Life Insurance quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Life Cover product page, Get a quote")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Life Cover product page, Get a quote")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToLifeCoverProductPageGetAQuote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Life Cover product page, Get a quote", new string[] {
                        "Production"});
#line 81
 this.ScenarioSetup(scenarioInfo);
#line 82
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
 testRunner.When("I hover over Life Insurance and click on Life Cover", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.And("I click on the Life insurance quote quote footer button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.Then("I see the https://join.vitality.co.uk/life/online/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigation to the Income Protection product page, Get a quote")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigation to the Income Protection product page, Get a quote")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigationToTheIncomeProtectionProductPageGetAQuote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigation to the Income Protection product page, Get a quote", new string[] {
                        "Production"});
#line 88
 this.ScenarioSetup(scenarioInfo);
#line 89
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.When("I hover over Life Insurance and click on Income Protection Cover", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.And("I go to the Get a quote cta and I click on the Get a quote page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.Then("I see the https://join.vitality.co.uk/life/online/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigation to the Life insurance landing page, request a callback")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigation to the Life insurance landing page, request a callback")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigationToTheLifeInsuranceLandingPageRequestACallback()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigation to the Life insurance landing page, request a callback", new string[] {
                        "Production"});
#line 95
 this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
 testRunner.When("I go to the Explore Life Insurance product component and I click on the Explore L" +
                    "ife Insurance page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.And("I go to the Get a quote cta and I click on the Get a quote page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.Then("I see the https://join.vitality.co.uk/life/online/callback page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigation to the Serious Illness Cover product page, request a callback")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigation to the Serious Illness Cover product page, request a callback")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigationToTheSeriousIllnessCoverProductPageRequestACallback()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigation to the Serious Illness Cover product page, request a callback", new string[] {
                        "Production"});
#line 102
 this.ScenarioSetup(scenarioInfo);
#line 103
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 104
 testRunner.When("I hover over Life Insurance and click on Serious Illness Cover", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
 testRunner.And("I click on the Request a Life callback quote footer button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.Then("I see the https://join.vitality.co.uk/life/online/callback page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Rewards menu, view all partners and rewards, view apple watch partner" +
            "")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Rewards menu, view all partners and rewards, view apple watch partner" +
            "")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToRewardsMenuViewAllPartnersAndRewardsViewAppleWatchPartner()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Rewards menu, view all partners and rewards, view apple watch partner" +
                    "", new string[] {
                        "Production"});
#line 109
 this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.When("I hover over Rewards and click on View all partners and rewards", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.And("I go to the Apple Watch Cards Tabbed and I click on the Explore Apple Watch page " +
                    "link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.Then("I expect the production presales /rewards/partners/active-rewards/apple-watch/ to" +
                    " open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Rewards menu, view Virgin Active partner, get a health insurance quot" +
            "e")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Rewards menu, view Virgin Active partner, get a health insurance quot" +
            "e")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToRewardsMenuViewVirginActivePartnerGetAHealthInsuranceQuote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Rewards menu, view Virgin Active partner, get a health insurance quot" +
                    "e", new string[] {
                        "Production"});
#line 116
 this.ScenarioSetup(scenarioInfo);
#line 117
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
 testRunner.When("I hover over Rewards and click on Virgin Active", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
 testRunner.And("I click on the Health insurance quote quote footer button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Rewards menu, view Starbucks partner, get a life insurance quote")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Rewards menu, view Starbucks partner, get a life insurance quote")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToRewardsMenuViewStarbucksPartnerGetALifeInsuranceQuote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Rewards menu, view Starbucks partner, get a life insurance quote", new string[] {
                        "Production"});
#line 123
 this.ScenarioSetup(scenarioInfo);
#line 124
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 125
 testRunner.When("I hover over Rewards and click on Starbucks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
 testRunner.And("I click on the Life insurance quote quote footer button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.Then("I see the https://www.vitality.co.uk/health-insurance/quote/ page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Legal page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Legal page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToLegalPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Legal page", new string[] {
                        "Production"});
#line 130
 this.ScenarioSetup(scenarioInfo);
#line 131
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 132
 testRunner.When("I go to the global footer Helpful links and I click on the Legal page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
 testRunner.Then("I expect the production presales /legal/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Cookies page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Cookies page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToCookiesPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Cookies page", new string[] {
                        "Production"});
#line 136
 this.ScenarioSetup(scenarioInfo);
#line 137
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 138
 testRunner.When("I go to the global footer Helpful links and I click on the Cookies page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
 testRunner.Then("I expect the production presales /accessibility/cookies/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigate to Complaints, View Complaints Data page")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigate to Complaints, View Complaints Data page")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigateToComplaintsViewComplaintsDataPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to Complaints, View Complaints Data page", new string[] {
                        "Production"});
#line 142
 this.ScenarioSetup(scenarioInfo);
#line 143
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 144
 testRunner.When("I go to the global footer Helpful links and I click on the Complaints page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
 testRunner.Then("I go to the How to contact us Rich Text and I click on the View VitalityHealth an" +
                    "d VitalityLife complaints data page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
 testRunner.Then("I expect the production presales /legal/complaints/data/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Navigation to Contact Us")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Navigation to Contact Us")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void NavigationToContactUs()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigation to Contact Us", new string[] {
                        "Production"});
#line 149
 this.ScenarioSetup(scenarioInfo);
#line 150
 testRunner.Given("I am on production presales /", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 151
 testRunner.When("I go to the global footer Helpful links and I click on the Contact us page link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
 testRunner.Then("I expect the production presales /contact/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Searching Presales Content")]
        [Xunit.TraitAttribute("FeatureTitle", "Health Presales Content")]
        [Xunit.TraitAttribute("Description", "Searching Presales Content")]
        [Xunit.TraitAttribute("Category", "Production")]
        public virtual void SearchingPresalesContent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Searching Presales Content", new string[] {
                        "Production"});
#line 156
 this.ScenarioSetup(scenarioInfo);
#line 157
    testRunner.Given("I am on production presales /search/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 158
    testRunner.When("I search content contact us", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 159
 testRunner.Then("I expect search contents Contact Us For Health & Life Insurance Quotes - Vitality" +
                    " to be visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
 testRunner.And("then I click on the Contact Us For Health & Life Insurance Quotes - Vitality resu" +
                    "lts page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.Then("I expect the production presales /contact/ to open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                HealthPresalesContentFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                HealthPresalesContentFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
