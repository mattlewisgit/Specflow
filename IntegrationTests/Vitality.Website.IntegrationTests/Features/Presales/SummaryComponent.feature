Feature: SummaryComponent
	In order to avoid silly mistakes
	As a Summary Component user
	I want to be able to view the Summary Component


@Presales Summarycomponent SIT
Scenario: Check Summary Component displays in full view
	Given I am on presales /dev/summary-component
	When I resize to full-screen view
	Then I expect the correct CSS summary component values to appear in full view

@Presales Summarycomponent SIT
Scenario: Check Summary Component displays in mobile view
	Given I am on presales /dev/summary-component
	When I resize to mobile view
	Then I expect the correct CSS summary component values to appear in full view

@Presales Summarycomponent SIT
Scenario: Check Summary Component button works
	Given I am on presales /dev/summary-component
	When I click on the summary component button Cheesecake
	Then I expect the presales / to open
