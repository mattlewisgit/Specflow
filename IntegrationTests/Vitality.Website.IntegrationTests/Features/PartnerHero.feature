Feature: PartnerHero
	In order to check the parner hero component
	As a partner hero User
	I want to be able to the check the partner hero component

	@SIT
Scenario: Check Partner Hero Message in full view
	Given I am on presales /dev/partner-hero/
	When I resize to full-screen view
	Then I expect the correct CSS Partner Hero light font values and without card snippet to appear
	And I expect the correct CSS Partner Hero dark font values and with card snippet to appear

	@SIT
Scenario: Check Partner Hero Message in mobile view
	Given I am on presales /dev/partner-hero/
	When I resize to mobile view
	Then I expect the correct CSS Partner Hero light font values and without card snippet to appear
