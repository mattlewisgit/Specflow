Feature: PolicyStartDateField
	In order to validation the policy start date field
	As a quote and apply user
	I want to be able to check the policy start date field

	@QuoteAndApply
    Scenario: Policy Start Date - Check the Policy Start Date allows today
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the coverStartDate field and make the date today plus 0 days
    Then I don't see the coverStartDate field error

	@QuoteAndApply
    Scenario: Policy Start Date - Check the Policy Start Date allows 30 days from now
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the coverStartDate field and make the date today plus 30 days
    Then I don't see the coverStartDate field error

	@QuoteAndApply
    Scenario: Policy Start Date - Check the Policy Start Date does not allow 31 days from now
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the coverStartDate field and make the date today plus 31 days
    Then I see the coverStartDate field error text Please enter valid date

	@QuoteAndApply
    Scenario: Policy Start Date - Check the Policy Start Date does not allow dates in the past
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the coverStartDate field and make the date today minus 1 days
    Then I see the coverStartDate field error text Please enter valid date