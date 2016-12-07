Feature: QuoteApply
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Get A Quote
	Given I am on the /quote
	When I enter the about you quote details
	And click on the Now get a quote button
	Then I expect the /yourquote to open
	And when I personalise your plan 
	Then I expect the /quotesummary to open
	And when continue the quote summary
	Then I expect the /fmumedicalquestions to open
	And when I complete the medical questions
	Then I expect the /paymentconfirmation to open
	And when I confirm payment now
	Then I expect the /thankyou to open
