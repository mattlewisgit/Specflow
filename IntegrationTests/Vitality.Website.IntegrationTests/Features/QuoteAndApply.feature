Feature: QuoteAndApply
    In order to test that Vitality can join new Members
	As a prospective Member
	I want to Quote and Apply for Health insurance cover

    Scenario: Basic field entry test for Quote and Apply
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose no claims
    And I go to the dateOfBirth field and enter 01/01/1970
    And I go to the coverStartDate field and enter 20/06/2017
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    And I go to the noOfKids field and choose kid's
    And I go to the kid1DateOfBirth field and enter 01/01/2005

    Scenario: Check error message when phone number too short
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    When I go to the phoneNumber field and enter 01202 22334
    Then I see the phoneNumber field error text Please enter a valid phone number

    Scenario: Check error message when phone number too long
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    When I go to the phoneNumber field and enter 01202 2233445
    Then I see the phoneNumber field error text Please enter a valid phone number

    Scenario: Check error message when phone number not numeric
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    When I go to the phoneNumber field and enter 01202 eeeeee
    Then I see the phoneNumber field error text Please enter a valid phone number

    Scenario: Hide the fields relating to current insurance
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    When I go to the insuredStatus field and choose not currently insured
    Then the noOfClaimFreeYears field is not displayed
    And the noOfClaims field is not displayed


    Scenario: Hide the fields relating to Partner and Children
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the membersToInsure field and choose just me
    Then the partnerDateOfBirth field is not displayed
    And the noOfKids field is not displayed
    And the kid1DateOfBirth field is not displayed

    Scenario: Hide the fields relating to Partner
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the membersToInsure field and choose me and my kids
    Then the partnerDateOfBirth field is not displayed
    And the noOfKids field is displayed
    And the kid1DateOfBirth field is displayed

    Scenario: Hide the fields relating to Kids
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the membersToInsure field and choose me and my partner
    Then the partnerDateOfBirth field is displayed
    And the noOfKids field is not displayed
    And the kid1DateOfBirth field is not displayed

    Scenario: Show all fields relating to Partner and Kids
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the membersToInsure field and choose me, my partner and kids
    Then the partnerDateOfBirth field is displayed
    And the noOfKids field is displayed
    And the kid1DateOfBirth field is displayed