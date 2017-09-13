Feature: PersonaliseGreeting
	In order to validation the personalised greeting field
	As a quote and apply user
	I want to be able to check the personalised greeting appears on the reults page

	@QuoteAndApply
    Scenario: Check first name appears in the personalise greeting quote results
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
    And I go to the marketingPermission field and choose Agreed
	And I see that the Progress Bar is not displayed
    And I see that the quote and apply Apply button is displayed
	And I click on the quote and apply Apply button
	Then I expect the presales /dev/quote-result to open
	And I expect the quote result personalised greeting to contain the users first name
