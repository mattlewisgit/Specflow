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
    And I go to the contactNumber field and enter 01202 223344
    And I go to the email field and enter sarah.nicholas@gmail.com
    And I go to the dateOfBirth field and enter 01/01/1970
    When I click on the Apply button
    Then I expect to see the interim panel

