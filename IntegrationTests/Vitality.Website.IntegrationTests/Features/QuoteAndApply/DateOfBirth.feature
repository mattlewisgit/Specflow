Feature: DateOfBirth
	In order to validation the date of birth field
	As a quote and apply user
	I want to be able to check the date of birth field

	@QuoteAndApply
    Scenario: DOB - Check error message when dateOfBirth date format incorrect
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the dateOfBirth field and enter 01/01/197
    Then I see the dateOfBirth field error text Please enter valid birth date


	@QuoteAndApply
    Scenario: DOB - Check error message when dateOfBirth makes Member too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the dateOfBirth field and make the age 80 plus 0 days
    Then I see the dateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: DOB - Check error message when dateOfBirth makes Member too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the dateOfBirth field and make the age 18 minus 1 days
    Then I see the dateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: DOB - Check error message does not appear when dateOfBirth makes Member almost too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the dateOfBirth field and make the age 80 minus 1 days
    Then I don't see the dateOfBirth field error

	@QuoteAndApply
    Scenario: DOB - Check error message does not appear when dateOfBirth makes Member almost too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the dateOfBirth field and make the age 18 minus 0 days
    Then I don't see the dateOfBirth field error