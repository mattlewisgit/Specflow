Feature: PostalAddress
	In order to validation the Direct Debit Postal Address Field
	As a quote and apply user
	I want to be able to check the Direct Debit Postal Address Field

    @QuoteAndApply
Scenario: Payment Details - Postal Address - Check Postcode Field does not have errors
    Given I am on presales /dev/quote-payment-details
    When I go to the billingPostcode field and enter BH1 1JD
    Then I don't see the billingPostcode field error

    @QuoteAndApply
Scenario: Payment Details - Postal Address - Check Billing Address Returns Vitality Address
    Given I am on presales /dev/quote-payment-details
    When I go to the billingPostcode field and enter BH1 1JD
    And I go to the button field and click on the button Find Address
    And I go to the selectBillingAddress field and I choose the dropdown MARSHALL POINT, 4 RICHMOND GARDENS
    Then I don't see the billingPostcode field error
