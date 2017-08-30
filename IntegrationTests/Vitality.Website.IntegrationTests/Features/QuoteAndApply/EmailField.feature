Feature: EmailField
	In order to validation the email field
	As a quote and apply user
	I want to be able to check the email field

	@QuoteAndApply
    Scenario: Check error message when email format incorrect
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 222222
    When I go to the emailAddress field and enter test.user@gmail
    Then I see the emailAddress field error text Please enter valid email address