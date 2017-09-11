Feature: CallMeBackEmailField
	In order to validation the callmeback email field
	As a quote and apply user
	I want to be able to check the callmeback email field

	@QuoteAndApply
    Scenario: CallMeBack - Email - Check error message when email format incorrect #1
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the emailAddress field and enter test.user@gmail
    Then I see the emailAddress field error text Please enter valid email address

	@QuoteAndApply
    Scenario: CallMeBack - Email - Check error message when email format incorrect #2
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the emailAddress field and enter @gmail.com
    Then I see the emailAddress field error text Please enter valid email address

	@QuoteAndApply
    Scenario: CallMeBack - Email - User enters a valid email address
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the emailAddress field and enter test.user@gmail.co.uk
    Then I don't see the emailAddress field error
