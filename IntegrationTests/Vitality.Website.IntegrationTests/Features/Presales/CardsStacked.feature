Feature: CardsStacked
	In order to avoid silly mistakes
	As a CardsStacked user
	I want to be able to check cards stacked works


@Presales Cardsstacked SIT
Scenario: Check Cards Stacked full screen view
	Given I am on presales /dev/cards-stacked
	When I resize to full-screen view
	Then I expect the correct CSS values to appear for full-screen view
	
@Presales Cardsstacked SIT
Scenario: Check Cards Stacked mobile view
	Given I am on presales /dev/cards-stacked
	When I resize to mobile view
	Then I expect the correct CSS values to appear for mobile view

@Presales Cardsstacked SIT
Scenario: Check Cards Stacked internal link
	Given I am on presales /dev/cards-stacked
	When I go to the Internal Link cards stacked and I click on the Click Internal Link page link
	Then I see the /dev page

@Presales Cardsstacked SIT
Scenario: Check Cards Stacked external link
	Given I am on presales /dev/cards-stacked
	When I go to the External Link cards stacked and I click on the External Link page link
	Then I see the www.google.co.uk page