Feature: Redirects
	In order validate redirects correctly work
	As a redirect user
	I want to be redirected to a different page

@Presales Redirects SIT
Scenario: Check redirects (cricket) works on Presales
	Given I am on presales /cricket/
    Then I expect the presales /community/sponsorship/ to open

@Presales Redirects SIT
Scenario: Check redirects (youtube) works on Presales
	Given I am on presales /usingmemberzone/
	Then I see the webpage https://www.youtube.com/watch?v=MaS5qoh8AUQ&feature=youtu.be

@Presales Redirects SIT
Scenario: Check redirects (fitbug) works on Advisers
	Given I am on advisers /rewards/partners/activity-tracking/fitbug/
    Then I expect the advisers /rewards/partners/activity-tracking/ to open

@Presales Redirects SIT
Scenario: Check page not found works on Presales
	Given I am on presales /unknownpage
    Then I expect the page Not found to appear

@Presales Redirects SIT
Scenario: Check page not found works on Advisers
	Given I am on advisers /unknownpage
    Then I expect the page Not found to appear
