Feature: MarketingPermissions
	In order to validation the marketing permissions field
	As a quote and apply user
	I want to be able to check the marketing permissions field

	@QuoteAndApply
    Scenario: Check the options that are available in Marketing Permission
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
    And I go to the membersToInsure field and choose just me
    And I go to the postcode field and enter BH1 1JD
    When I go to the marketingPermission field and look at the options available
    Then I see that the marketingPermission options are as expected
