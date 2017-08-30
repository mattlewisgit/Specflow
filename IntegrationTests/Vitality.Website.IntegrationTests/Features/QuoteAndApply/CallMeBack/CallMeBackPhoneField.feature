Feature: CallMeBackPhoneField
	In order to validation the callmeback phone number field
	As a quote and apply user
	I want to be able to check the callmeback phone number field

	@QuoteAndApply
    Scenario: PhoneNumber - Check that phone number formats are allowed #1
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the phoneNumber field and enter +44 1202 667788
    Then I don't see the phoneNumber field error

	@QuoteAndApply
    Scenario: PhoneNumber - Check that phone number formats are allowed #2
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the phoneNumber field and enter +44 1202 66 77 88
    Then I don't see the phoneNumber field error

	@QuoteAndApply
    Scenario: PhoneNumber - Check that phone number formats are allowed #3
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the phoneNumber field and enter +44 1202 667 788
    Then I don't see the phoneNumber field error

	@QuoteAndApply
    Scenario: PhoneNumber - Check error message when phone number too short
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the phoneNumber field and enter 01202 22334
    Then I see the phoneNumber field error text Please enter valid phone number

	@QuoteAndApply
    Scenario: PhoneNumber - Check error message when phone number too long
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the phoneNumber field and enter 01202 2233445
    Then I see the phoneNumber field error text Please enter valid phone number

	@QuoteAndApply
    Scenario: PhoneNumber - Check error message when phone number not numeric
    Given I am on presales /dev/call-me-back
    And I see the Quote And Apply page feed load has completed
    When I go to the phoneNumber field and enter 01202 eeeeee
    Then I see the phoneNumber field error text Please enter valid phone number
