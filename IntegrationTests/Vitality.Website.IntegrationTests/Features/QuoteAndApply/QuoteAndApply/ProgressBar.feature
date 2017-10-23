Feature: ProgressBar
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	@QuoteAndApply
    Scenario: Progress Bar - initialise at 0%
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    Then I see that the Progress Bar is at 0 %

	@QuoteAndApply
    Scenario: Progress Bar - Name row at 10%
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    Then I see that the Progress Bar is at 10 %

    @QuoteAndApply
    Scenario: Progress Bar - Date of Birth row at 20% (not currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    Then I see that the Progress Bar is at 20 %

	@QuoteAndApply
    Scenario: Progress Bar - Phone Number row at 30%
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    Then I see that the Progress Bar is at 30 %

	@QuoteAndApply
    Scenario: Progress Bar - Email Address row at 40%
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    Then I see that the Progress Bar is at 40 %

    @QuoteAndApply
    Scenario: Progress Bar - Postcode row at 50% (not currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    Then I see that the Progress Bar is at 50 %

	@QuoteAndApply
    Scenario: Progress Bar - Insured Status row at 60% (not currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose not currently insured
    Then I see that the Progress Bar is at 60 %

	@QuoteAndApply
    Scenario: Progress Bar - Cover Start Date row at 70% (not currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose not currently insured
    And I go to the coverStartDate field and make the date today plus 0 days
    Then I see that the Progress Bar is at 70 %

	@QuoteAndApply
    Scenario: Progress Bar - Members to Insure row at 80% (not currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose not currently insured
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    Then I see that the Progress Bar is at 80 %

	@QuoteAndApply
    Scenario: Progress Bar - Insured Status row at 50% (currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    Then I see that the Progress Bar is at 50 %

	@QuoteAndApply
    Scenario: Progress Bar - No of Claim Free Years row at 58% (currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    Then I see that the Progress Bar is at 58 %

	@QuoteAndApply
    Scenario: Progress Bar - No of Claim Free Years row at 66% (currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    Then I see that the Progress Bar is at 66 %

	@QuoteAndApply
    Scenario: Progress Bar - Policy Start Date row at 75% (currently insured)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    Then I see that the Progress Bar is at 75 %

	@QuoteAndApply
    Scenario: Progress Bar - Members to Insure row at 83% (currently insured, just me)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    Then I see that the Progress Bar is at 83 %

	@QuoteAndApply
    Scenario: Progress Bar - Members to Insure row at 76% (currently insured, me and my partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my partner
    Then I see that the Progress Bar is at 76 %

	@QuoteAndApply
    Scenario: Progress Bar - Partner's Date of Birth row at 84% (currently insured, me and my partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my partner
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    Then I see that the Progress Bar is at 84 %

	@QuoteAndApply
    Scenario: Progress Bar - Members to Insure row at 71% (currently insured, me, my partner and kids)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    Then I see that the Progress Bar is at 71 %

	@QuoteAndApply
    Scenario: Progress Bar - Partner's Date of Birth row at 78% (currently insured, me, my partner and kids)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    Then I see that the Progress Bar is at 78 %

	@QuoteAndApply
    Scenario: Progress Bar - No of kids row at 85% (currently insured, me, my partner and kids)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    And I go to the noOfChildren field and choose 2 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2005
    Then I see that the Progress Bar is at 85 %

    @QuoteAndApply
    Scenario: Progress Bar - Multiselector at 91% (just me)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    And I go to the Discounted gym membership checkbox field and select the value
    Then I see that the Progress Bar is at 91 %

    @QuoteAndApply
    Scenario: Progress Bar - Terms and conditions (currently insured, just me)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose just me
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
    Then I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed

	@QuoteAndApply
    Scenario: Progress Bar - Terms and conditions (currently insured, me, my partner and kids)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    And I go to the noOfChildren field and choose 2 kids'
    And I go to the child1Dob field and enter 01/01/2005
    And I go to the child2Dob field and enter 01/02/2005
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
    Then I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed

    @QuoteAndApply
    Scenario: Progress Bar - Terms and conditions (currently insured, me and my partner)
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the postcode field and enter BH1 1JD
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    And I go to the noOfClaims field and choose 1 claim
    And I go to the dateOfBirth field and enter 01/01/1970
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my partner
    And I go to the partnerDateOfBirth field and enter 01/01/1971
    And I go to the Discounted gym membership checkbox field and select the value
    And I go to the marketingPermission field and choose Agreed
    Then I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed
