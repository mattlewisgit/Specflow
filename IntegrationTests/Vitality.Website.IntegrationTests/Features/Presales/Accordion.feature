Feature: Accordion Component
	In order to avoid silly mistakes
	As a accordion user
	I want to be expand and retract the accordion


@Presales Accordion SIT
Scenario: Check Accordion Expands on Page Load
	Given I am on presales /dev/accordion-content
	Then I expect the accordion description '#tab1' to appear

@Presales Accordion SIT
Scenario: Check Accordion Expands on Click in full size view
	Given I am on presales /dev/accordion-content
	When I click on accordion tab This is Tab 2
	Then I expect the accordion description #tab2 to appear

@Presales Accordion SIT
Scenario: Check Accordion Expands on Click in mobile view
	Given I am on presales /dev/accordion-content
    When I resize to mobile view
	And I click on accordion tab This is Tab 4
	Then I expect the accordion description #tab4 to appear

@Presales Accordion SIT
Scenario: Check Accordion Expands Multiple Times
	Given I am on presales /dev/accordion-content
	When I click on accordion tab This is Tab 2
	Then I expect the accordion description #tab2 to appear
	When I click on accordion tab This is Tab 3
	Then I expect the accordion description #tab3 to appear
	When I click on accordion tab This is Tab 4
	Then I expect the accordion description #tab4 to appear
