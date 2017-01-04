Feature: Health Presales Content
	In order to test that the Vitality Health Presales site is correct
	As a Tester
	I want to perform basic navigation and content tests
	

	Scenario: Navigate to Health Insurance Menu, Get a Quote
    Given I am on presales /
	When I hover over Health Insurance and click on Get a quote
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page


	Scenario: Navigate to Health Insurance Menu, Health insurance quote page
    Given I am on presales /
	When I hover over Health Insurance and click on Health Insurance quote
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page
	

	Scenario: Navigate to Core Cover, Awards page
    Given I am on presales /
	When I hover over Health Insurance and click on Core Cover
	And I go to the Award-winning cover feature block and I click on the Learn more page link
	Then I expect the presales /about/awards/ to open

	
	Scenario: Navigate to Cover Options, Get a quote page
    Given I am on presales /
	When I hover over Health Insurance and click on Cover Options
	And I click on the Get a quote page link
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page

	
	Scenario: Navigate to Switch to Vitality link to anchored text on another page
    Given I am on presales /
	When I hover over Health Insurance and click on Switch to Vitality
	And I go to the A Full Cover Promise feature block and I click on the Read more page link
	Then I expect the presales /health-insurance/core-cover/in-patient/#anchor_1470237471794 to open


	Scenario: Navigate to Switch to Vitality, Rewards page
    Given I am on presales /
	When I hover over Health Insurance and click on Switch to Vitality
	And I go to the And rewards for a healthy lifestyle feature block and I click on the Learn more page link
	Then I expect the presales /rewards/ to open

	Scenario: Navigate to Vitality GP, Get a Quote page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Ready to apply online cta and I click on the Get a quote page link
	Then I see the https://www.vitality.co.uk/health-insurance/quote/ page


	Scenario: Navigate to Vitality GP, Hospitals page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Choose where you cards stacked and I click on the Learn more page link
	Then I expect the presales /health-insurance/hospitals/ to open


	Scenario: Navigate to Vitality GP, Extended Cancer Cover page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Extended Cancer Cover cards stacked and I click on the Learn more page link
	Then I expect the presales /health-insurance/core-cover/cancer/ to open


	Scenario: Navigate to Vitality GP, Full Cover Promise page
    Given I am on presales /
	When I hover over Health Insurance and click on Vitality GP
	And I go to the Full Cover Promise cards stacked and I click on the Learn more page link
	Then I expect the presales /health-insurance/core-cover/in-patient/ to open

	
