Feature: CurrentlyInsuredField
	In order to validation the currently insured field
	As a quote and apply user
	I want to be able to check the currently insured field

	@QuoteAndApply
    Scenario: Hide the fields relating to current insurance
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    When I go to the insuredStatus field and choose not currently insured
    Then the noOfClaimFreeYears field is not displayed
    And the noOfClaims field is not displayed

	@QuoteAndApply
    Scenario: Check the options that are available in insuredStatus
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    When I go to the insuredStatus field and look at the options available
    Then I see that the insuredStatus options are as expected

	@QuoteAndApply
    Scenario: Check the options that are available in No Of Claim Free Years
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose currently insured
    When I go to the noOfClaimFreeYears field and look at the options available
    Then I see that the noOfClaimFreeYears options are as expected

	@QuoteAndApply
    Scenario: Check the options that are available in No Of Claims
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose currently insured
    And I go to the noOfClaimFreeYears field and choose 1 year
    When I go to the noOfClaims field and look at the options available
    Then I see that the noOfClaims options are as expected


