Feature: MarketingPermissions
	In order to validation the marketing permissions field
	As a quote and apply user
	I want to be able to check the marketing permissions field

	@QuoteAndApply
    Scenario: Marketing Permission - Check the options that are available in Marketing Permission
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the marketingPermission field and look at the options available
    Then I see that the marketingPermission options are as expected
