Feature: DateOfBirth
	In order to validation the date of birth field
	As a quote and apply user
	I want to be able to check the date of birth field

	@QuoteAndApply
    Scenario: Check error message when dateOfBirth date format incorrect
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and enter 01/01/197
    Then I see the dateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: Check error message when dateOfBirth makes Member too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 80 plus 0 days
    Then I see the dateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: Check error message when dateOfBirth makes Member too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 18 minus 1 days
    Then I see the dateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: Check error message does not appear when dateOfBirth makes Member almost too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 80 minus 1 days
    Then I don't see the dateOfBirth field error

	@QuoteAndApply
    Scenario: Check error message does not appear when dateOfBirth makes Member almost too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    When I go to the dateOfBirth field and make the age 18 minus 0 days
    Then I don't see the dateOfBirth field error

	@QuoteAndApply	
    Scenario: Check error message when dateOfBirth makes Partner too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 16 minus 1 days
    Then I see the partnerDateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: Check error message when dateOfBirth makes Partner too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 80 plus 0 days
    Then I see the partnerDateOfBirth field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: Check error message does not appears when dateOfBirth makes Partner almost too young
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 16 minus 0 days
    Then I don't see the partnerDateOfBirth field error

	@QuoteAndApply
    Scenario: Check error message does not appear when dateOfBirth makes Partner almost too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me, my partner and kids
    When I go to the partnerDateOfBirth field and make the age 80 minus 1 days
    Then I don't see the partnerDateOfBirth field error

	@QuoteAndApply
    Scenario: Check error message when dateOfBirth makes Child1 too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose kid's
    When I go to the child1Dob field and make the age 18 plus 0 days
    Then I see the child1Dob field error text Please enter valid birth date

	@QuoteAndApply
    Scenario: Check error message when dateOfBirth makes Child3 too old
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
    And I go to the phoneNumber field and enter 01202 223344
    And I go to the emailAddress field and enter test.user@gmail.com
    And I go to the insuredStatus field and choose not currently insured
    And I go to the dateOfBirth field and make the age 18 minus 0 days
    And I go to the coverStartDate field and make the date today plus 0 days
    And I go to the membersToInsure field and choose me and my kids
    And I go to the noOfChildren field and choose 3 kids'
    When I go to the child1Dob field and make the age 12 plus 0 days
    When I go to the child2Dob field and make the age 14 plus 0 days
    When I go to the child3Dob field and make the age 18 plus 0 days
    Then I see the child3Dob field error text Please enter valid birth date
