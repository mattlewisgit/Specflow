Feature: Login
	In order to login to Riversand
	As an admin user
	I want to be able to login to Riversand

    @Riversand
Scenario: Check Riversand test environment opens
	Given I am on Riversand URL /Login/login.html
    Then I expect the Riversand URL /Login/login.html to open

    @Riversand
Scenario: Check Riversand login credentials
	Given I am on Riversand URL /Login/login.html
    When I enter username kfadmin and password kfadmin
    And click on the login button
    Then I expect the Riversand URL /Main/Entity/EntityExplorer.aspx to open
