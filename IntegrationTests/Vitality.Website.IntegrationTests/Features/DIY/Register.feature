Feature: Register
	In order to register a new user on DIY.com website
	As a new user
	I want to be able to create an account

    @DIY.com
Scenario: Register a new user
	Given I am on DIY.com URL /
    When I click on the top navigation Register link
    And I go to the email-address-reg text field and enter 10testuser@kingfisher.com
    And I go to the create-pwd text field and enter Password1
    And I go to the confirm-pwd text field and enter Password1
    And I click on the Continue button
    Then I expect 10testuser@kingfisher.com account to be logged in
