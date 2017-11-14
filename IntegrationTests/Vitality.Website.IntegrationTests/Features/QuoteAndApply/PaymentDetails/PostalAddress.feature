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

    @QuoteAndApply
Scenario: Payment Details - Postal Address - Check manual address fields appear
    Given I am on presales /dev/quote-payment-details
    When I go to the billingPostcode field and enter BH1 1JD
    And I go to the button field and click on the button Find Address
    And I enter the postal address manually and click on click here
    Then I expect the postal address address1 to be visible
    And I expect the postal address address2 to be visible
    And I expect the postal address address3 to be visible
    And I expect the postal address test to be visible
    And I expect the postal address postcode to be visible

    @QuoteAndApply
Scenario: Payment Details - Postal Address - Manually entering an address
    Given I am on presales /dev/quote-payment-details
    When I go to the billingPostcode field and enter BH1 1JD
    And I go to the button field and click on the button Find Address
    And I enter the postal address manually and click on click here
    And I go to the address1 field and enter MARSHALL POINT
    And I go to the address2 field and enter 4 RICHMOND GARDENS
    And I go to the address3 field and enter BOURNEMOUTH
    And I go to the address4 field and enter DORSET
    And I go to the postcode field and enter BH1 1JD
    Then I don't see the billingPostcode field error

    @QuoteAndApply
Scenario: Payment Details - Postal Address - Check postcode is autopopulated
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
	And I go to the dateOfBirth field and enter 01/01/1970
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
	And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose no claims
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
	And I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed
	And I click on the quote and apply Apply button
    And I see the Quote Results page feed load has completed
	Then I expect the presales /dev/quote-result to open
    When I click on the quote result BUY ONLINE button link
    Then I expect the presales /dev/quote-payment-details to open
    Then I expect the billingPostcode field to autopopulate with the correct information
    Then I don't see the billingPostcode field error
