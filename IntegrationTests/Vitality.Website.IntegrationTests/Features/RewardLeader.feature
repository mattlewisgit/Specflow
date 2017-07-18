Feature: RewardLeader
	In order to avoid silly mistakes
	As a Reward leader user
	I want to be able to view the Reward Leader


	@SIT
Scenario: Check Reward leader display in full view
	Given I am on presales /dev/rewards-leader
	When I resize to full-screen view
	Then I expect the correct CSS Reward Leader blue values to appear in full view

	@SIT
Scenario: Check Reward leader display in mobile view
	Given I am on presales /dev/rewards-leader
	When I resize to mobile view
	Then I expect the correct CSS Reward Leader blue values to appear in mobile view

	@SIT
Scenario: Check Reward leader cta button works
	Given I am on presales /dev/rewards-leader
	When I click on rewards leader background colour blue button Learn about rewards
	Then I expect the presales / to open

	@SIT
Scenario: Check Reward leader partner image button works in full view
	Given I am on presales /dev/rewards-leader
	When I click on rewards leader background colour blue with partner logo cineworld
	Then I expect the presales / to open

	@SIT
Scenario: Check Reward leader partner image button works in mobile view
	Given I am on presales /dev/rewards-leader
	And I resize to mobile view
	When I click on rewards leader background colour blue with partner logo virgin
	Then I expect the presales / to open

