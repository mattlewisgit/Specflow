Feature: Redirects
	In order validate redirects correctly work
	As a redirect user
	I want to be redirected to a different page

@Presales Redirects SIT
Scenario: Check redirects (cricket) work on Presales
	Given I am on presales /cricket/
    Then I expect the presales /community/sponsorship/ to open

@Presales Redirects SIT
Scenario: Check redirects (fitbug) work on Advisers
	Given I am on advisers /rewards/partners/activity-tracking/fitbug/
    Then I expect the advisers /rewards/partners/activity-tracking/ to open
