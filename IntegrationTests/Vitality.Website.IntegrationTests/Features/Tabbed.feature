Feature: Tabbed Content Component
	In order to avoid silly mistakes
	As a Tabbed Content user
	I want to be select on different tabbed content


@SIT
Scenario: Check Tabbed Content Selected on Page Load
	Given I am on presales /dev/tabbed-content
	Then I expect the tabbed content description '#tab1' to appear

@SIT
Scenario: Check Tabbed Content Selected on Click in full size view
	Given I am on presales /dev/tabbed-content
	When I click on tabbed content tab 'Tab2'
	Then I expect the tabbed content description '#tab2' to appear

@SIT
Scenario: Check Tabbed Content Opens Multiple Times
	Given I am on presales /dev/tabbed-content
	When I click on tabbed content tab 'Tab2'
	Then I expect the tabbed content description '#tab2' to appear
	When I click on tabbed content tab 'Tab3'
	Then I expect the tabbed content description '#tab3' to appear