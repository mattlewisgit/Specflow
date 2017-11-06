Feature: AccountNumber
	In order to validation the account number field
	As a quote and apply user
	I want to be able to check the account number field

    @QuoteAndApply
Scenario: Payment Details - Account Number - Check account number field
    Given I am on presales /dev/quote-payment-details
    When I go to the accountNumber field and enter 12345678
    Then I don't see the accountNumber field error

	@QuoteAndApply
Scenario: Payment Details - Account Number - Check incorrect account number error message
    Given I am on presales /dev/quote-payment-details
    When I go to the accountNumber field and enter 1234567
    Then I see the accountNumber field error text Please enter your account number

    @QuoteAndApply
Scenario: Payment Details - Account Number - Check account number masking
    Given I am on presales /dev/quote-payment-details
    When I go to the accountNumber field and enter letterss
    Then I see the accountNumber field error text Please enter your account number
