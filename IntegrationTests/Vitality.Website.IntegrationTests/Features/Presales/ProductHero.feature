Feature: ProductHero
	In order validate the Product hero
	As a Product Hero user
	I want to be able to check the product hero works as expected


@Presales Producthero SIT
	Scenario: Check Product Hero Component in full screen
	Given I am on presales /dev/product-hero
	When I resize to full-screen view
	Then I expect the correct CSS product hero values to appear for full view

@Presales Producthero SIT
	Scenario: Check Product Hero Component in mobile view
	Given I am on presales /dev/product-hero
	When I resize to mobile view
	Then I expect the correct CSS product hero values to appear for mobile view

@Presales Producthero SIT
	Scenario: Check Product Hero Component button works
	Given I am on presales /dev/product-hero
	When I click on the Product Hero Have you tried turning it off and on again? Button
	Then I expect the presales / to open