﻿Feature: NameField
	In order to validation the email field
	As a quote and apply user
	I want to be able to check the email field

	@QuoteAndApply
    Scenario: Name - Check name field can be populated
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mrs
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter User
	Then I don't see the lastName field error

	@QuoteAndApply
    Scenario: Name - Check name field can be populated with special character double barrelled name
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    And I go to the title field and choose Mr
    And I go to the firstName field and enter James
    And I go to the lastName field and enter Ward-Prowse
	Then I don't see the lastName field error

	@QuoteAndApply
    Scenario: Name - Check error message when name contains a number
    Given I am on presales /dev/quote-and-apply
    And I see the Quote And Apply page feed load has completed
    When I go to the title field and choose Mr
    And I go to the firstName field and enter Test
    And I go to the lastName field and enter 123
	Then I see the lastName field error text Please enter your full name
