Feature: Health Advisers Content
	In order to test that the Vitality Health Advisers site is correct
	As a Tester
	I want to perform basic navigation and content tests
	
	@Production
	Scenario: Navigate to the Life Insurance landing page, Login to Adviser Hub
    Given I am on production advisers /
	When I hover over Life Insurance and click on Life Insurance Home
	And I go to the Adviser Hub cta and I click on the Login page link
	Then I see the https://adviser.vitality.co.uk/life/online/manualLogin page

	@Production
	Scenario: Navigate to the Personal Protection landing page, view Life Cover product page
    Given I am on production advisers /
	When I hover over Life Insurance and click on Personal Protection Home
	And I go to the Life Cover cards stacked and I click on the Learn more page link
	Then I expect the production advisers /life-insurance/personal/life-cover/ to open

	@Production
	Scenario: Navigate to the Business Protection landing page, view Relevant Life Cover product page
    Given I am on production advisers /
	When I hover over Life Insurance and click on Business Protection Home
	And I go to the Relevant Life Cover cards stacked and I click on the Find out more page link
	Then I expect the production advisers /life-insurance/business/relevant-life-cover/ to open

	@Production
	Scenario: Navigate to the Health Insurance landing page
    Given I am on production advisers /
	When I hover over Health Insurance and click on Health insurance overview
	Then I expect the production advisers /health-insurance/ to open

	@Production
	Scenario: Navigate to the Personal Health Insurance landing page, Login to Adviser Services
    Given I am on production advisers /
	When I hover over Health Insurance and click on Personal Health Insurance
	And I go to the Login and get a quote cta and I click on the Get a quote page link
	Then I see the https://login.vitality.co.uk/medical/ page

	@Production
	Scenario: Navigate to Health Sales Literature, Lit tool displays
	Given I am on production advisers /resources/literature/health-insurance-sales-literature/
	When I search for Personal Healthcare document
	Then I expect the Personal Healthcare document to be visible
	And I expect the download and email  buttons to be visible

	@Production
	Scenario: Navigate to Health Member Literature, Lit tool displays
	Given I am on production advisers /resources/literature/health-insurance-member-literature/
	And I enter plan start date 1 12 2016
	When click on the submit button
	And I select on Personal Healthcare Plan terms and conditions Literature
	Then I expect the Personal Healthcare Plan terms and conditions document to be visible
	And I expect the download and email  buttons to be visible