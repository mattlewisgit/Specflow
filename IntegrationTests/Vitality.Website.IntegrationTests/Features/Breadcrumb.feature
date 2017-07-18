Feature: Breadcrumb Component
	In order to verify breadcrumbs exists
	As a standard User
	I want to be able to check breadcrumbs show the correct routing


	@SIT
Scenario: Check Breadcrumbs on presales
	Given I am on presales /dev/search
	Then I expect the breadcrumb to show Dev
	Then I expect the breadcrumb to show Search
	And then I click on breadcrumbs Dev
	Then I expect the presales /dev/ to open

Scenario: Check Breadcrumbs on advisers
	Given I am on advisers /dev/member-library
	Then I expect the breadcrumb to show Dev
	Then I expect the breadcrumb to show Member Library
	And then I click on breadcrumbs Dev
	Then I expect the advisers /dev/ to open

	@SIT
Scenario: Check Breadcrumbs exists in full size view
	Given I am on presales /dev/article-index
	Then I expect the breadcrumb to show Dev
	Then I expect the breadcrumb to show Article index

	@SIT
Scenario: Check Breadcrumbs does not exists in mobile view
	Given I am on presales /dev/article-index
	Then I expect the breadcrumb to show Dev
	Then I expect the breadcrumb to show Article index
	When I resize to mobile view
	Then I expect the breadcrumb to be hidden 

	@SIT
Scenario: Check Breadcrumbs navigation link
	Given I am on presales /dev/article-index
	Then I expect the breadcrumb to show Dev
	Then I expect the breadcrumb to show Article index
	And then I click on breadcrumbs Dev
	Then I expect the presales /dev/ to open

