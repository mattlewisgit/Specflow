Feature: AccountHolderName
	In order to validation the accountholder name field
	As a quote and apply user
	I want to be able to check the accountholder name field

@mytag
Scenario: Complete Purchase - Account holder name
    Given I am on presales /dev/quote-complete-purchase
    When I go to the accountType field and choose a joint account
