Feature: RichText
	In order to validation the personalised greeting field
	As a quote and apply user
	I want to be able to check the personalised greeting appears on the reults page

    @QuoteAndApply
Scenario: Check Rich Text quote result page
	Given I am on presales /dev/quote-result
	Then I expect the quote result rich text component to appear
