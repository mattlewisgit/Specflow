Feature: EndToEnd
	In order to validation the end to end process
	As a quote and apply user
	I want to be able to check the end to end process

	@QuoteAndApply
    Scenario: Basic field entry test for Quote and Apply
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose no claims
    And I go to the dateOfBirth field and enter 01/01/1970
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    And I go to the noOfChildren field and choose kid's
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the postcode field and enter BH1 1JD
    And I go to the marketingPermission field and choose Agreed
    Then I don't see any field errors