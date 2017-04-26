Feature: Award Leader
	In order to avoid silly mistakes
	As a Award Leader user
	I want to be able to see that Award Leader works


	@SIT
Scenario: Check Award Leader full screen view
	Given I am on presales /dev/award-leader
	When I resize to full-screen view
	Then I expect the correct CSS Award Leader values to appear

	@SIT
Scenario: Check Award Leader mobile view
	Given I am on presales /dev/award-leader
	When I resize to mobile view
	Then I expect the correct CSS Award Leader values to appear

	@SIT
Scenario: Check Award Leader Member Story 1 link works
	Given I am on presales /dev/award-leader
	When I click on the Award Leader Member Stories 1 link
	Then I expect the presales /dev/home-hero/ to open

    @SIT
Scenario: Check Award Leader Member Story 2 link works
	Given I am on presales /dev/award-leader
	When I click on the Award Leader member Stories 2 link
	Then I expect the presales /dev/home-hero/ to open

	@SIT
Scenario: Check Award Leader Member Story 3 link works
	Given I am on presales /dev/award-leader
	When I click on the Award Leader Member Stories 3 link
	Then I expect the presales /dev/home-hero/ to open

    @SIT
Scenario: Check Award Leader Member Story 1 link works in mobile view
	Given I am on presales /dev/award-leader
    When I resize to mobile view
	And I click on the Award Leader Member Stories 1 link
	Then I expect the presales /dev/home-hero/ to open