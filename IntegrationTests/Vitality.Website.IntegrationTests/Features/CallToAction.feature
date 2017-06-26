Feature: CallToAction
	In order to avoid silly mistakes
	As a CTA user
	I want to check on the CTA component


	@SIT
	Scenario: Check CTA Component in full screen
	Given I am on presales /dev/call-to-action
	When I resize to full-screen view
	Then I expect the correct CTA CSS values to appear for mobile view

	@SIT
	Scenario: Check CTA Component in mobile view
	Given I am on presales /dev/call-to-action
	When I resize to mobile view
	Then I expect the correct CTA CSS values to appear for mobile view

	@SIT
	Scenario: Check CTA Component button links internally
	Given I am on presales /dev/call-to-action
	When I click on CTA Internal button 
	Then I expect the presales / to open

	@SIT
	Scenario: Check CTA Component button links externally
	Given I am on presales /dev/call-to-action
	When I click on CTA External button 
	Then I see the http://www.bbc.co.uk/ page
