Feature: SortCodeField
	In order to validation the sortcode field
	As a quote and apply user
	I want to be able to check the sortcode field

    @QuoteAndApply
Scenario: Complete Purchase - Check sortcode field
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountSortcode field and enter 123456


	@QuoteAndApply
Scenario: Complete Purchase - Check incorrect sortcode error message
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountSortcode field and enter 12345
    Then I see the accountSortcode field error text Please enter your sortcode

    @QuoteAndApply
Scenario: Complete Purchase - Check sortcode masking
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountSortcode field and enter LETTE
    Then I see the accountSortcode field error text Please enter your sortcode
