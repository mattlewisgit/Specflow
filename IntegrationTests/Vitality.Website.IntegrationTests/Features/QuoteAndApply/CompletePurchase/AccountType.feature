Feature: AccountType
	In order to validation the account type field
	As a quote and apply user
	I want to be able to check the account type field


	@QuoteAndApply
Scenario: Complete Purchase - Joint account holder name
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountType field and choose a joint account

    @QuoteAndApply
Scenario: Complete Purchase - An individual account holder name
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountType field and choose a joint account
