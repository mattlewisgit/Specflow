Feature: Award Leader
	In order to avoid silly mistakes
	As a Award Leader user
	I want to be able to see that Award Leader works


	@SIT
Scenario: Check Award Leader full screen view
	Given I am on presales /dev/faq-leader
	When I resize to full-screen view
	Then I expect the correct CSS FAQ Leader values to appear

	@SIT
Scenario: Check Award Leader mobile view
	Given I am on presales /dev/faq-leader
	When I resize to mobile view
	Then I expect the correct CSS FAQ Leader values to appear

	@SIT
Scenario: Check Award Leader paragraph anchor link works
	Given I am on presales /dev/faq-leader
	When I click on FAQ Leader paragraph anchor Read more link
	Then I expect the presales / to open

	@SIT
Scenario: Check Award Leader bottom button works
	Given I am on presales /dev/faq-leader
	When I click on FAQ Leader bottom button Layback skate key link
	Then I expect the presales / to open
