Feature: SortCodeField
	In order to validation the sortcode field
	As a quote and apply user
	I want to be able to check the sortcode field

    @QuoteAndApply
Scenario: Payment Details - Sortcode - Check sortcode field
    Given I am on presales /dev/quote-payment-details
    When I go to the accountSortcode field and enter 123456
    Then I don't see the accountSortcode field error


	@QuoteAndApply
Scenario: Payment Details - Sortcode - Check incorrect sortcode error message
    Given I am on presales /dev/quote-payment-details
    When I go to the accountSortcode field and enter 12345
    Then I see the accountSortcode field error text Please enter your sortcode

    @QuoteAndApply
Scenario: Payment Details - Sortcode - Check sortcode masking
    Given I am on presales /dev/quote-payment-details
    When I go to the accountSortcode field and enter LETTE
    Then I see the accountSortcode field error text Please enter your sortcode
