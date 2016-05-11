Feature: Main Navigation
	In order to test that the Main Navigation works
	As a Tester
	I want to perform basic navigation tests
	
	Scenario: Test Navigation
	Given I am on the http://dev.vitality.co.uk/
	When I click on the business section link
	Then I expect the http://dev.vitality.co.uk/business to open

	Scenario: Click Navigation Logo
	Given I am on the http://dev.vitality.co.uk/business
	When I click on the navigation logo
	Then I expect the http://dev.vitality.co.uk/ to open

	Scenario: Resize home page to Mobile view and check for hamburger
	Given I am on the http://dev.vitality.co.uk/
	When I resize to mobile view
	Then I expect the hamburger to be visible