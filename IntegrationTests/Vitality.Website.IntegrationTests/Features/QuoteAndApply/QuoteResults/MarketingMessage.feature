Feature: MarketingMessage
    In order to test the marketing message page appears before the quote result
	As a prospective Member
	I want marketing message to display

    Scenario: Check marketing message is displayed
    Given I am on presales /dev/quote-result
    Then I expect the marketing message Fetching your quote to be displayed
