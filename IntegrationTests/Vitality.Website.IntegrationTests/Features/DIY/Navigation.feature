Feature: Navigation
	In order to check kingfisher website
	As a kingfisher customer
	I want to be able to navigate to the kingfisher website

    @DIY.com
Scenario: Check DIY.com navigates to find a store
	Given I am on DIY.com URL /
    When I click on the top Left navigation Find a store link
    Then I expect the kingfisher URL /find-a-store to open

    @DIY.com
Scenario: Check DIY.com navigates to register
	Given I am on DIY.com URL /
    When I click on the top Right navigation Register link
    Then I expect the kingfisher URL /customer/register/ to open

    @DIY.com
Scenario: Check DIY.com navigates to bottom navigation Carrier Bags
	Given I am on DIY.com URL /
    When I click on the top Bottom navigation Carrier bags link
    Then I expect the page heading to be Carrier bags and URL to be https://pvt-storefront.diy.com/carrier-bags?icamp=footer_CarrierBags

    @DIY.com
Scenario: Check main navigation works
	Given I am on DIY.com URL /
    When I hover over the main navigation KITCHEN & BATHROOM and click on Fitted kitchens
    Then I expect the page heading to be Fitted kitchens and URL to be https://pvt-storefront.diy.com/departments/kitchen/fitted-kitchens/

    @DIY.com
Scenario: Check i can add an item to the basket
	Given I am on DIY.com URL /
    When I hover over the main navigation BUILDING & HARDWARE and click on Screws
