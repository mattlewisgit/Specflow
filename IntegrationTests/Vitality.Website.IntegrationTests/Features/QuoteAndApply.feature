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
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    And I go to the noOfChildren field and choose kid's
    And I go to the child1Dob field and enter 01/01/2005
    Then I don't see any field errors

    Scenario: Check that phone number formats are allowed #1
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    When I go to the phoneNumber field and enter +44 1202 667788
    Then I don't see the phoneNumber field error

    Scenario: Check that phone number formats are allowed #2
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    When I go to the phoneNumber field and enter +44 1202 66 77 88
    Then I don't see the phoneNumber field error

    Scenario: Check that phone number formats are allowed #3
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    When I go to the phoneNumber field and enter +44 1202 667 788
    Then I don't see the phoneNumber field error

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

    Scenario: Check error message when email format incorrect
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 222222
    When I go to the emailAddress field and enter sarah.nicholas@gmail
    Then I see the emailAddress field error text Please enter valid email address

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
    And the noOfChildren field is not displayed
    And the child1Dob field is not displayed

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
    And the noOfChildren field is displayed
    And the child1Dob field is displayed

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
    And the noOfChildren field is not displayed
    And the child1Dob field is not displayed

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
    And the noOfChildren field is displayed
    And the child1Dob field is displayed

    Scenario: Check error message when dateOfBirth date format incorrect
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and enter 01/01/197
    Then I see the dateOfBirth field error text Please enter valid date

    Scenario: Check error message when dateOfBirth makes Member too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 80 plus 0 days
    Then I see the dateOfBirth field error text Please enter valid date

    Scenario: Check error message when dateOfBirth makes Member too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 18 minus 1 days
    Then I see the dateOfBirth field error text Please enter valid date

    Scenario: Check error message does not appear when dateOfBirth makes Member almost too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 80 minus 1 days
    Then I don't see the dateOfBirth field error

    Scenario: Check error message does not appear when dateOfBirth makes Member almost too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 18 minus 0 days
    Then I don't see the dateOfBirth field error

    Scenario: Enter two children, no partner in Quote
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
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And the partnerDateOfBirth field is not displayed
    And I go to the noOfChildren field and choose 2 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2005
    Then I don't see any field errors

    Scenario: Enter five children, no partner in Quote
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
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And the partnerDateOfBirth field is not displayed
    And I go to the noOfChildren field and choose 5 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2006
    And I go to the child3Dob field and enter 01/01/2007
    And I go to the child4Dob field and enter 01/02/2008
    And I go to the child5Dob field and enter 01/02/2009
    Then I don't see any field errors

    Scenario: Enter four children and partner in Quote
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
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 20/01/1990
    And I go to the noOfChildren field and choose 4 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2006
    And I go to the child3Dob field and enter 01/01/2007
    And I go to the child4Dob field and enter 01/02/2008
    And the child5Dob field is not displayed
    Then I don't see any field errors

    Scenario: Check error message when dateOfBirth makes Partner too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 16 minus 1 days
    Then I see the partnerDateOfBirth field error text Please enter valid date

    Scenario: Check error message when dateOfBirth makes Partner too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 80 plus 0 days
    Then I see the partnerDateOfBirth field error text Please enter valid date

    Scenario: Check error message does not appears when dateOfBirth makes Partner almost too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 16 minus 0 days
    Then I don't see the partnerDateOfBirth field error

    Scenario: Check error message does not appear when dateOfBirth makes Partner almost too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 80 minus 1 days
    Then I don't see the partnerDateOfBirth field error

    Scenario: Check error message when dateOfBirth makes Child1 too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose kid's
    When I go to the child1Dob field and make the age 18 plus 0 days
    Then I see the child1Dob field error text Please enter valid birth date

    Scenario: Check error message when dateOfBirth makes Child3 too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose 3 kids'
    When I go to the child1Dob field and make the age 12 plus 0 days
    When I go to the child2Dob field and make the age 14 plus 0 days
    When I go to the child3Dob field and make the age 18 plus 0 days
    Then I see the child3Dob field error text Please enter valid birth date


    Scenario: Check error message does not appears when postCode is valid
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    When I go to the postcode field and enter BH1 1JD
    Then I don't see the postcode field error

    Scenario: Check error message when postCode is invalid
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    When I go to the postcode field and enter BH 1JD
    Then I see the postcode field error text Please enter valid postcode

    Scenario: Check the options that are available in insuredStatus
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    When I go to the insuredStatus field and look at the options available
    Then I see that the insuredStatus options are as expected

    Scenario: Check the options that are available in No Of Claim Free Years
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose currently insured
    When I go to the noOfClaimFreeYears field and look at the options available
    Then I see that the noOfClaimFreeYears options are as expected

    Scenario: Check the options that are available in No Of Claims
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    When I go to the noOfClaims field and look at the options available
    Then I see that the noOfClaims options are as expected


    Scenario: Check the options that are available in Members To Insure
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    When I go to the membersToInsure field and look at the options available
    Then I see that the membersToInsure options are as expected

    Scenario: Check the options that are available in No of Children (no Partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And I set the PartnerContext as NoPartner
    When I go to the noOfChildren field and look at the options available
    Then I see that the noOfChildren options are as expected

    Scenario: Check the options that are available in No of Children (with Partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I set the PartnerContext as WithPartner
    When I go to the noOfChildren field and look at the options available
    Then I see that the noOfChildren options are as expected

    Scenario: Check the options that are available in Marketing Permission
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Sarah
    And I go to the lastName field and enter Nicholas
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter sarah.nicholas@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    And I go to the postcode field and enter BH1 1JD
    When I go to the marketingPermission field and look at the options available
    Then I see that the marketingPermission options are as expected


