Feature: Careers
	In order to recuit the very best
	As an HR employee
	I want to be able show potential candidates a list of current positions

Scenario: Check that the page loading information is shown
    Given I am on presales /careers/vacancies/
	When I see the Vacancies page feed is loading with a message Loading Vacancies...
    Then I see the Vacancies page feed load has completed

Scenario: Check that all business Locations exist in dropdown
	Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	Then I see the location All Locations
    And I see the location Bournemouth
    And I see the location Croydon
    And I see the location London
    And I see the location Stockport

Scenario: Check that all business Departments exist in dropdown
	Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	Then I see the department All Departments
    And I see the department Actuary
    And I see the department Digital
    And I see the department Finance
    And I see the department IT
    And I see the department Marketing
    And I see the department Sales

Scenario: Check that all filtering works for Bournemouth
    Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	When I select the location Bournemouth
	Then I see all the jobs belonging to location Bournemouth

    @ignore
Scenario: Check that all filtering works for Digital
    Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	When I select the department Digital
	Then I see all the jobs belonging to department Digital

Scenario: Check that there are no jobs available in Croydon
    Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	When I select the location Croydon
	Then I see there are no Vacancies available

Scenario: Check that filtering refreshes page display when repeatedly changed
    Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	When I select the location Bournemouth
    And I select the department All Departments
	Then I see all the jobs belonging to location Bournemouth
    And I select the department Actuary
    And I see there are no Vacancies available

Scenario: Check that we can follow the link to the Job page
    Given I am on presales /careers/vacancies/
    And I see the Vacancies page feed load has completed
	When I select the location Bournemouth
    And I select the department All Departments
	Then I see all the jobs belonging to location Bournemouth
    And I click the link for the job .Net Developer
    And I expect the presales /careers/vacancies/13654/ to open
    And I see the Vacancy page feed is loading with a message Retrieving job details...
    Then I see the Vacancy page feed load has completed