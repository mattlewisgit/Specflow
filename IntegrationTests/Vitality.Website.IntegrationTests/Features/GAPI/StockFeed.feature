Feature: StockFeed
	In order to check the stock endpoint
	As a stock feed user
	I want to be able to check stock levels change

    @GAPI
Scenario: Check stock feed levels are updated
	Given I am on stock API endpoint URL /1011/00804256
    Then I expect the quantity to be 300
