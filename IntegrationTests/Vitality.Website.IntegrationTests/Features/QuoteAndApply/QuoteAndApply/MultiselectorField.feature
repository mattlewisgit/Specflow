Feature: MultiselectorField
	In order to validation the email field
	As a quote and apply user
	I want to be able to check the email field

	@QuoteAndApply
	Scenario: Multiselector - Select one value
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
	When I go to the Discounted gym membership checkbox field and select the value
    Then I don't see any field errors

    @QuoteAndApply
	Scenario: Multiselector - Select three values
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
	When I go to the Discounted gym membership checkbox field and select the value
    And I go to the Mental wellbeing checkbox field and select the value
    And I go to the Apple watch checkbox field and select the value
    Then I don't see any field errors

    @QuoteAndApply
	Scenario: Multiselector - Unable to exceed maximum amount of selections (max 3)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
	When I go to the Discounted gym membership checkbox field and select the value
    And I go to the Mental wellbeing checkbox field and select the value
    And I go to the Apple watch checkbox field and select the value
    Then I expect the Fast private GP access and diagnosis checkbox field to be disabled
    And I don't see any field errors
