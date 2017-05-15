Feature: ArticleIndex
	In order to avoid silly mistakes
	As a Article Index user
	I want to be able to view Article Index


	@SIT
Scenario: Check Article index display in full view
	Given I am on presales /dev/article-index
	When I resize to full-screen view
	Then I expect the correct CSS Article Index values to appear in full view

	@SIT
Scenario: Check Article index display in mobile view
	Given I am on presales /dev/article-index
	When I resize to mobile view
	Then I expect the correct CSS Article Index values to appear in mobile view

	@SIT
Scenario: Check Article index card link works in full view
	Given I am on presales /dev/article-index
	When I resize to full-screen view
	When I click on Article Index Active Rewards card
	Then I expect the presales /rewards/partners/active-rewards/ to open

	@SIT
Scenario: Check Article index card link works in  mobile view
	Given I am on presales /dev/article-index
	And I resize to mobile view
	When I click on Article Index The healthy food hall card
	Then I expect the presales /rewards/partners/healthy-eating/ to open
