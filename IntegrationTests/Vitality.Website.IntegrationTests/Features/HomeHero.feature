Feature: HomeHero
	In order to check the home hero component works
	As a Home Hero User
	I want to be able to view the Home hero


	@SIT
Scenario: Check Home hero on full size 
	Given I am on presales /dev/home-hero
	When I resize to full-screen view
	Then I expect the correct CSS home hero values to appear

	@SIT
Scenario: Check Home hero on mobile view
	Given I am on presales /dev/home-hero
	When I resize to mobile view
	Then I expect the correct CSS home hero values to appear in mobile view

	@SIT
Scenario: Home Hero click play on video
	Given I am on presales /dev/home-hero
	When I click on home hero play button
	Then I expect the home hero video to play

	@SIT
Scenario: Home Hero click play and pause video
	Given I am on presales /dev/home-hero
	When I click on home hero play button
	And I pause the home hero video
	Then I expect the correct CSS home hero values to appear
