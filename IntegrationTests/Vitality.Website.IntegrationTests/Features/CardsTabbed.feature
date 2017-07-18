Feature: CardsTabbed
	In order to avoid silly mistakes
	As a Cards Tabbed user
	I want to be able to check cards tabbed works


	@SIT
Scenario: Check cards tabbed in full screen view
	Given I am on presales /dev/cards-tabbed
	When I resize to full-screen view
	Then I expect the correct CSS cards tabbed values to appear
	And I expect the cards tabbed partner Garmin to be displayed

	@SIT
Scenario: Check cards tabbed in mobile view
	Given I am on presales /dev/cards-tabbed
	When I resize to mobile view
	Then I expect the correct CSS cards tabbed values to appear
	And I expect the cards tabbed partner Garmin to be displayed

	@SIT
Scenario: Check cards tabbed navigation menu searches for partner
	Given I am on presales /dev/cards-tabbed
	And I resize to mobile view
	When I click on cards tabbed navigation menu Active Rewards
	Then I expect the cards tabbed partner Starbucks to be displayed

	@SIT
Scenario: Check cards tabbed call to action button works
	Given I am on presales /dev/cards-tabbed
	And I resize to mobile view
	When I click on cards tabbed navigation menu Active Rewards
	And I click on the cards tabbed Starbucks partner Learn more button link
	Then I expect the presales /rewards/partners/active-rewards/starbucks/ to open