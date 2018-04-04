Feature: Price feed
	In order to check the GAPI price feed
	As a price feed user
	I want to verify that the price is correct
	
@mytag
Scenario: Check Group API price feed
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
