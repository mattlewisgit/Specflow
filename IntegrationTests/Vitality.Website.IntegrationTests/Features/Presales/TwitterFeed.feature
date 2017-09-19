Feature: TwitterFeed
	In order view the vitality twitter feed
	As a Twitter user
	I want to be able to view the twitter feed


@Presales twitter SIT
Scenario: Check the twitter feed correctly renders
	Given I am on presales /dev/twitter
	Then I expect the twitter feed to open
