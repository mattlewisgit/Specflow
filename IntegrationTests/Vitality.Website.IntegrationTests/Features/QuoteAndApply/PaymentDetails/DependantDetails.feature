Feature: DependantDetails
	In order to validation the dependant details field
	As a quote and apply user
	I want to be able to check the dependant details field


    @QuoteAndApply
    Scenario: Payment Details - Dependant Details - Check Partner DOB is autopopulated
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
    And I go to the membersToInsure field and choose me and my partner
    And I go to the partnerDateOfBirth field and enter 20/01/1990
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
	And I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed
	And I click on the quote and apply Apply button
    And I see the Quote Results page feed load has completed
	Then I expect the presales /dev/quote-result to open
    When I click on the quote result BUY ONLINE button link
    Then I expect the presales /dev/quote-payment-details to open
    Then I expect the partnerDateOfBirth field to autopopulate with the correct information
    Then I don't see the partnerDateOfBirth field error

    @QuoteAndApply
    Scenario: Payment Details - Dependant Details - Check Child 1 DOB is autopopulated
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
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose kid's
    And I go to the childDob1 field and enter 01/01/2010
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
	And I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed
	And I click on the quote and apply Apply button
    And I see the Quote Results page feed load has completed
	Then I expect the presales /dev/quote-result to open
    When I click on the quote result BUY ONLINE button link
    Then I expect the presales /dev/quote-payment-details to open
    Then I expect the childDob1 field to autopopulate with the correct information
    Then I don't see the partnerDateOfBirth field error

    @QuoteAndApply
    Scenario: Payment Details - Dependant Details - Check Partner and 4 children DOB is autopopulated
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
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 20/01/1990
    And I go to the noOfChildren field and choose 4 kids'
    And I go to the childDob1 field and enter 01/01/2010
    And I go to the childDob2 field and enter 01/01/2011
    And I go to the childDob3 field and enter 01/01/2012
    And I go to the childDob4 field and enter 01/01/2013
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
	And I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed
	And I click on the quote and apply Apply button
    And I see the Quote Results page feed load has completed
	Then I expect the presales /dev/quote-result to open
    When I click on the quote result BUY ONLINE button link
    Then I expect the presales /dev/quote-payment-details to open
    And I expect the partnerDateOfBirth field to autopopulate with the correct information
    And I expect the child1Dob field to autopopulate with the correct information
    And I expect the child2Dob field to autopopulate with the correct information
    And I expect the child3Dob field to autopopulate with the correct information
    And I expect the child4Dob field to autopopulate with the correct information
