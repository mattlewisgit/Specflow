Feature: ProductsComponent
	In order to avoid silly mistakes
	As a Products Component user
	I want to be able to view the Products Component


@Presales Productscomponent SIT
Scenario: Check Products Component displays in full view
	Given I am on presales /dev/products-component
	When I resize to full-screen view
	Then I expect the correct CSS Products Component values to appear in full view

@Presales Productscomponent SIT
Scenario: Check Products Component displays in mobile view
	Given I am on presales /dev/products-component
	When I resize to mobile view
	Then I expect the correct CSS Products Component values to appear in full view