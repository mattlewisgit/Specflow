Feature: LiteratureLibrary
	In order to download adviser documents
	As an adviser
	I want to be able to download documents

@ignore
Scenario: Literature library
	Given I am on the /
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
