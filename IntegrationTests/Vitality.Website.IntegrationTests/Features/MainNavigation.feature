Feature: Main Navigation
    In order to test that the Main Navigation works
    As a Tester
    I want to perform basic navigation tests

	@SIT
    Scenario: Test Navigation to Business
    Given I am on presales /
    When I click on the Business section link
	Then I expect the presales /business/ to open

	@SIT
    Scenario: Test Navigation to Advisers
    Given I am on presales /
    When I click on the Advisers section link
	Then I expect the presales /advisers/ to open

	@SIT
    Scenario: Test Navigation to Personal
    Given I am on presales /business
    When I click on the Personal section link
	Then I expect the presales / to open

	@SIT
	Scenario: Click Navigation Logo
    Given I am on presales /business
    When I click on the navigation logo
	Then I expect the presales / to open

	@SIT
    Scenario: Resize home page to Mobile view and check for hamburger
    Given I am on presales /
    When I resize to mobile view
    Then I expect the hamburger to be visible

	@SIT
    Scenario: Resize home page from Mobile view to Full-screen and check that hamburger invisible
    Given I am on presales /
    When I resize to mobile view
    And I resize to full-screen view
    Then I expect the hamburger to be invisible

	@SIT
    Scenario: Check Member Zone login components show in Mobile view
    Given I am on presales /
    When I resize to mobile view
    And I click on Login small button
	Then I expect the Navigation Login button Member Zone to be visible
	And I expect the Navigation Login button Health Advisers to be visible

	@SIT
    Scenario: Check Member Zone login components show in Full-screen view
    Given I am on presales /
    When I resize to full-screen view
    And I click on Login large button
	Then I expect the Navigation Login button Member Zone to be visible
	And I expect the Navigation Login button Health Advisers to be visible

	@SIT
    Scenario: Resize home page from Mobile view to Full-screen and check that footer visible
    Given I am on presales /
    When I resize to mobile view
    And I resize to full-screen view
    Then I expect the Health insurance quote button to be visible
    And I expect the Life insurance quote button to be visible

    @SIT
    Scenario: resize home page Mobile view
    Given I am on presales /
    When I resize to mobile view

	@SIT
    Scenario: Check Footer links work in Mobile view
    Given I am on presales /
    When I resize to mobile view
    And I expand the mobile footer section Get a quote
    And I click on the footer mobile link Health insurance quote
	Then I see the webpage https://www.vitality.co.uk/health-insurance/quote/

	@SIT
    Scenario: Check console logs on presales
    Given I am on presales /
	Then I should not see any console logs

	@SIT
    Scenario: Check console logs on advisers
    Given I am on advisers /
	Then I should not see any console logs
