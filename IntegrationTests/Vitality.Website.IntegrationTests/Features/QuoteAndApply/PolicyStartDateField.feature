Feature: PolicyStartDateField
	In order to validation the policy start date field
	As a quote and apply user
	I want to be able to check the policy start date field

	@QuoteAndApply
    Scenario: Check the Policy Start Date allows today
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    Then I don't see the coverStartDate field error

	@QuoteAndApply
    Scenario: Check the Policy Start Date allows 30 days from now
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 30 days
    Then I don't see the coverStartDate field error

	@QuoteAndApply
    Scenario: Check the Policy Start Date does not allow 31 days from now
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 31 days
    Then I see the coverStartDate field error text Please enter valid date

	@QuoteAndApply
    Scenario: Check the Policy Start Date does not allow dates in the past
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today minus 1 days
    Then I see the coverStartDate field error text Please enter valid date