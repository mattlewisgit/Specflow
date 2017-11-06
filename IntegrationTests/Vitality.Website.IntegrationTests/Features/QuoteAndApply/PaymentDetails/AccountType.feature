﻿Feature: AccountType
	In order to validation the account type field
	As a quote and apply user
	I want to be able to check the account type field


	@QuoteAndApply
Scenario: Payment Details - Account type - Joint account holder name
    Given I am on presales /dev/quote-payment-details
    When I go to the accountType field and choose a joint account
    Then I don't see the accountType field error

    @QuoteAndApply
Scenario: Payment Details - Account type - An individual account holder name
    Given I am on presales /dev/quote-payment-details
    When I go to the accountType field and choose an individual account
    Then I don't see the accountType field error
