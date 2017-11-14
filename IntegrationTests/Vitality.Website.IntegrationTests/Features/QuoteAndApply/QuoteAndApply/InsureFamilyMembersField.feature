Feature: InsureFamilyMembersField
	In order to validation the Insure Family Members field
	As a quote and apply user
	I want to be able to check the Insure Family Members field

	@QuoteAndApply
    Scenario: InsuredMember - Hide the fields relating to Partner and Children
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the membersToInsure field and choose just me
    Then the partnerDateOfBirth field is not displayed
    And the noOfChildren field is not displayed
    And the child1Dob field is not displayed

	@QuoteAndApply
    Scenario: InsuredMember - Hide the fields relating to Partner
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the membersToInsure field and choose me and my kids
    Then the partnerDateOfBirth field is not displayed
    And the noOfChildren field is displayed
    And the child1Dob field is not displayed

	@QuoteAndApply
    Scenario: InsuredMember - Hide the fields relating to Kids
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the membersToInsure field and choose me and my partner
    Then the partnerDateOfBirth field is displayed
    And the noOfChildren field is not displayed
    And the child1Dob field is not displayed

	@QuoteAndApply
    Scenario: InsuredMember - Show all fields relating to Partner and Kids
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the membersToInsure field and choose me, my partner and kids
    Then the partnerDateOfBirth field is displayed
    And the noOfChildren field is displayed

	@QuoteAndApply
    Scenario: InsuredMember - Enter two children, no partner in Quote
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me and my kids
    And the partnerDateOfBirth field is not displayed
    And I go to the noOfChildren field and choose 2 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2005
    Then I don't see any field errors

	@QuoteAndApply
    Scenario: InsuredMember - Enter five children, no partner in Quote
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me and my kids
    And the partnerDateOfBirth field is not displayed
    And I go to the noOfChildren field and choose 5 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2006
    And I go to the child3Dob field and enter 01/01/2007
    And I go to the child4Dob field and enter 01/02/2008
    And I go to the child5Dob field and enter 01/02/2009
    Then I don't see any field errors

	@QuoteAndApply
    Scenario: InsuredMember - Enter four children and partner in Quote
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 20/01/1990
    And I go to the noOfChildren field and choose 4 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2006
    And I go to the child3Dob field and enter 01/01/2007
    And I go to the child4Dob field and enter 01/02/2008
    And the child5Dob field is not displayed
    Then I don't see any field errors

	@QuoteAndApply
    Scenario: InsuredMember - Check the options that are available in Members To Insure
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the membersToInsure field and look at the options available
    Then I see that the membersToInsure options are as expected

	@QuoteAndApply
    Scenario: InsuredMember - Check the options that are available in No of Children (no Partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me and my kids
    And I set the PartnerContext as NoPartner
    When I go to the noOfChildren field and look at the options available
    Then I see that the noOfChildren options are as expected

	@QuoteAndApply
    Scenario: InsuredMember - Check the options that are available in No of Children (with Partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me, my partner and kids
    And I set the PartnerContext as WithPartner
    When I go to the noOfChildren field and look at the options available
    Then I see that the noOfChildren options are as expected


	@QuoteAndApply
    Scenario: InsuredMember - Check error message when dateOfBirth makes Partner too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 16 minus 1 days
    Then I see the partnerDateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: InsuredMember - Check error message when dateOfBirth makes Partner too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 80 plus 0 days
    Then I see the partnerDateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: InsuredMember - Check error message does not appears when dateOfBirth makes Partner almost too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 16 minus 0 days
    Then I don't see the partnerDateOfBirth field error

	@QuoteAndApply
    Scenario: InsuredMember - Check error message does not appear when dateOfBirth makes Partner almost too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 80 minus 1 days
    Then I don't see the partnerDateOfBirth field error

	@QuoteAndApply
    Scenario: InsuredMember - Check error message when dateOfBirth makes Child1 too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose kid's
    When I go to the child1Dob field and make the age 18 plus 0 days
    Then I see the child1Dob field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: InsuredMember - Check error message when dateOfBirth makes Child3 too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose 3 kids'
    When I go to the child1Dob field and make the age 12 plus 0 days
    When I go to the child2Dob field and make the age 14 plus 0 days
    When I go to the child3Dob field and make the age 18 plus 0 days
    Then I see the child3Dob field error text Please enter valid birth date
