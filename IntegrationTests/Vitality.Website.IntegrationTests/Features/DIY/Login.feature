Feature: Login
	In order to check DIY.com website
	As a registered customer
	I want to be able to login to DIY.com

    @DIY.com
Scenario: Check valid user can log into DIY.com
	Given I am on DIY.com URL /
    When I click on the top Right navigation Sign in link
    And I go to the email-address text field and enter testuser@kingfisher.com
    And I go to the password text field and enter Password1
    And I click on the Sign in button
    Then I expect testuser@kingfisher.com account to be logged in

    @DIY.com
Scenario: Check invalid user cannot log into DIY.com
	Given I am on DIY.com URL /
    When I click on the top Right navigation Sign in link
    And I go to the email-address text field and enter InvalidUsername@gmail.com
    And I go to the password text field and enter InvalidPassword
    And I click on the Sign in button
    Then I expect an error message to appear
