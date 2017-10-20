Feature: AccountNumber
	In order to validation the account number field
	As a quote and apply user
	I want to be able to check the account number field

    @QuoteAndApply
Scenario: Complete Purchase - Check account number field
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountNumber field and enter 12345678


	@QuoteAndApply
Scenario: Complete Purchase - Check incorrect account number error message
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountNumber field and enter 1234567
    Then I see the accountNumber field error text Please enter your account number

    @QuoteAndApply
Scenario: Complete Purchase - Check account number masking
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountNumber field and enter letters
    Then I see the accountNumber field error text Please enter your account number
