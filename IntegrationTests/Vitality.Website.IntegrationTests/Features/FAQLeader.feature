Feature: FAQ Leader
	In order to avoid silly mistakes
	As a FAQ Leader user
	I want to be able to FAQ Leader works


	@SIT
Scenario: Check FAQ Leader full screen view
	Given I am on presales /dev/award-leader
	When I resize to full-screen view
	Then I expect the correct CSS FAQ Leader values to appear

	@SIT
Scenario: Check FAQ Leader mobile view
	Given I am on presales /dev/award-leader
	When I resize to mobile view
	Then I expect the correct CSS FAQ Leader values to appear

	@SIT
Scenario: Check FAQ Leader paragraph anchor link works
	Given I am on presales /dev/award-leader
	When I click on FAQ Leader paragraph anchor Read more link
	Then I expect the presales / to open

	@SIT
Scenario: Check FAQ Leader bottom button works
	Given I am on presales /dev/award-leader
	When I click on FAQ Leader bottom button Layback skate key link
	Then I expect the presales / to open