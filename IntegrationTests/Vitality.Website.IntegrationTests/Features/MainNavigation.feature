Feature: Main Navigation
    In order to test that the Main Navigation works
    As a Tester
    I want to perform basic navigation tests

    Scenario: Test Navigation
    Given I am on the /
    When I click on the business section link
    Then I expect the /business/ to open

    Scenario: Click Navigation Logo
    Given I am on the /business
    When I click on the navigation logo
    Then I expect the / to open

    Scenario: Resize home page to Mobile view and check for hamburger
    Given I am on the /
    When I resize to mobile view
    Then I expect the hamburger to be visible

    Scenario: Resize home page from Mobile view to Full-screen and check that hamburger invisible
    Given I am on the /
    When I resize to mobile view
    And I resize to full-screen view
    Then I expect the hamburger to be invisible

    @ignore
    Scenario: Check Member Zone login components show in Mobile view
    Given I am on the /
    When I resize to mobile view
	And I click on the Login button
    Then I expect the Member Zone button to be visible
    And I expect the Health Advisers button to be visible
    And I expect the Life Advisers button to be visible

    Scenario: Check Member Zone login components show in Full-screen view
    Given I am on the /
    When I resize to full-screen view
	And I click on the Login button
	Then I expect the Member Zone button to be visible
	And I expect the Health Advisers button to be visible
	And I expect the Life Advisers button to be visible
