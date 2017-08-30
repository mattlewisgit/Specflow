Feature: PostcodeField
	In order to validation the postcode field
	As a quote and apply user
	I want to be able to check the postcode field

	@QuoteAndApply
    Scenario: Postcode - Check error message does not appears when postCode is valid #6 values
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the postcode field and enter BH1 1JD
    Then I don't see the postcode field error

	@QuoteAndApply
    Scenario: Postcode - Check error message does not appears when postCode is valid #7 values
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the postcode field and enter BH20 6HH
    Then I don't see the postcode field error

	@QuoteAndApply
    Scenario: Postcode - Check error message when postCode is invalid
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the postcode field and enter BH 1JD
    Then I see the postcode field error text Please enter valid postcode
