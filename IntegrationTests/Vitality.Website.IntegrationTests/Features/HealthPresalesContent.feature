Feature: Health Presales Content
	In order to test that the Vitality Health Presales site is correct
	As a Tester
	I want to perform basic navigation and content tests
	
	@Production
	Scenario: Navigate to Health Insurance Menu, Get a Quote
    Given I am on presales /
	When I hover over Health Insurance and click on Get a quote
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	@Production
	Scenario: Navigate to Health Insurance Menu, Health insurance quote page
    Given I am on presales /
	When I hover over Health Insurance and click on Health insurance quote
	Then I expect the presales /health-insurance/quote/ to open

	@Production
	Scenario: Navigate to Core Cover, Awards page
    Given I am on presales /
	When I hover over Health Insurance and click on Core Cover
	And I go to the Award-winning cover feature block and I click on the Learn more page link
	Then I expect the presales /about/awards/ to open

	@Production
	Scenario: Navigate to Cover Options, Get a quote page
    Given I am on presales /
	When I hover over Health Insurance and click on Cover Options
	And I click on the Get a quote page link
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	@Production
	Scenario: Navigate to Switch to Vitality link to anchored text on another page
    Given I am on presales /
	When I hover over Health Insurance and click on Switch to Vitality
	And I go to the A Full Cover Promise feature block and I click on the Read more page link
	Then I expect the presales /health-insurance/core-cover/in-patient/#anchor_1470237471794 to open

	@Production
	Scenario: Navigate to Switch to Vitality, Rewards page
    Given I am on presales /
	When I hover over Health Insurance and click on Switch to Vitality
	And I go to the Rewards for a healthy lifestyle feature block and I click on the Learn more page link
	Then I expect the presales /rewards/ to open

	@Production
	Scenario: Navigate to Vitality GP, Get a Quote page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Ready to apply online cta and I click on the Get a quote page link
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	@Production
	Scenario: Navigate to Vitality GP, Hospitals page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Choose your treatment pathway cards stacked and I click on the Learn more page link
	Then I expect the presales /health-insurance/hospitals/ to open

	@Production
	Scenario: Navigate to Vitality GP, Extended Cancer Cover page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Extended Cancer Cover cards stacked and I click on the Learn more page link
	Then I expect the presales /health-insurance/core-cover/cancer/ to open

	@Production
	Scenario: Navigate to Vitality GP, Full Cover Promise page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Full Cover Promise cards stacked and I click on the Learn more page link
	Then I expect the presales /health-insurance/core-cover/in-patient/ to open









	@Production
	Scenario: 01) Navigated to Life insurance menu, Get a quote
    Given I am on presales /
	When I hover over Life Insurance and click on Life Insurance quote
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	@Production
	Scenario: 02) Navigate to Life Cover product page, Get a quote
	Given I am on presales /
	When I hover over Life Insurance and click on Life Cover
	And I click on the Life insurance quote quote footer button
	Then I see the https://join.vitality.co.uk/life/online/quote/ page

	@Production
	Scenario: 03) Navigation to the Income Protection product page, Get a quote
	Given I am on presales /
	When I hover over Life Insurance and click on Income Protection Cover
	And I go to the Get a quote cta and I click on the Get a quote page link
	Then I see the https://join.vitality.co.uk/life/online/quote/ page

	@Production
	Scenario: 04) Navigation to the Life insurance landing page, request a callback
	Given I am on presales /
	When I go to the Explore Life Insurance product component and I click on the Explore Life Insurance page link
	And I go to the Get a quote cta and I click on the Get a quote page link
	Then I see the https://join.vitality.co.uk/life/online/callback page

	@Production
	Scenario: 05) Navigation to the Serious Illness Cover product page, request a callback
	Given I am on presales /
	When I hover over Life Insurance and click on Serious Illness Cover
	And I click on the Request a Life callback quote footer button
	Then I see the https://join.vitality.co.uk/life/online/callback page

	@Production
	Scenario: 06) Navigate to Rewards menu, view all partners and rewards, view apple watch partner
	Given I am on presales /
	When I hover over Rewards and click on View all partners and rewards
	And I go to the Apple Watch Cards Tabbed and I click on the Explore Apple Watch page link
	Then I expect the presales /rewards/partners/active-rewards/apple-watch/ to open

	@Production
	Scenario: 07) Navigate to Rewards menu, view Virgin Active partner, get a health insurance quote
	Given I am on presales /
	When I hover over Rewards and click on Virgin Active
	And I click on the Health insurance quote quote footer button
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	@Production
	Scenario: 08) Navigate to Rewards menu, view Starbucks partner, get a life insurance quote
	Given I am on presales /
	When I hover over Rewards and click on Starbucks
	And I click on the Life insurance quote quote footer button
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	@Production
	Scenario: 09) Navigate to Legal page
	Given I am on presales /
	When I go to the global footer Helpful links and I click on the Legal page link
	Then I expect the presales /legal/ to open

	@Production
	Scenario: 10) Navigate to Cookies page
	Given I am on presales /
	When I go to the global footer Helpful links and I click on the Cookies page link
	Then I expect the presales /accessibility/cookies/ to open

	@Production
	Scenario: 11) Navigate to Complaints, View Complaints Data page
	Given I am on presales /
	When I go to the global footer Helpful links and I click on the Complaints page link
	Then I expect the presales /legal/complaints/ to open

	@Production
	Scenario: 12) Navigation to Contact Us 
	Given I am on presales /
	When I go to the global footer Helpful links and I click on the Contact us page link
	Then I expect the presales /contact/ to open
