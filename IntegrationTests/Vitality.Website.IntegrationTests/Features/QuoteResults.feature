Feature: QuoteResults
    In order to test that Vitality can join new Members
	As a prospective Member
	I want Quote Results to offer me differing levels of insurance cover

    Scenario: Amend Hospital Network cover to Consultant Select
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Hospital Network / Treatment Pathway to Consultant Select
    Then I see the price of the Standard offering change to £ 0 per Month

    Scenario: When Hospital Network amended to Consultant Select, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Hospital Network / Treatment Pathway to Consultant Select
    Then I see this reflected across all the offerings

    Scenario: When Out-Patient cover amended to Full Cover, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Out-Patient cover to Full Cover
    Then I see this reflected across all the offerings

    Scenario: When Excess Amount Per Year amended to £ 250, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Excess Amount Per Year to £ 250
    Then I see this reflected across all the offerings

    Scenario: When Excess Type amended to Per Policy Year, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Excess Type to Per Policy Year
    Then I see this reflected across all the offerings

    Scenario: When Underwriting Types amended to Moratorium, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Underwriting Types to Moratorium
    Then I see this reflected across all the offerings

    Scenario: Check the options in the Hospital Network are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Hospital Network / Treatment Pathway dropdown
    Then I see the following options
   	| Data              |
	| Consultant Select |
    | Countrywide Plus  |
    | Local             |

    Scenario: Check the options in the Out-Patient cover are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Out-Patient cover dropdown
    Then I see the following options
   	| Data          |
	| £ 500         |
    | £ 750         |
    | £ 1000        |
    | £ 1250        |
    | £ 1500        |
    | Full Cover    |

    Scenario: Check the options in the Excess Amount Per Year are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Excess Amount Per Year dropdown
    Then I see the following options
   	| Data          |
	| £ 0           |
    | £ 100         |
    | £ 250         |
    | £ 500         |
    | £ 1000        |

    Scenario: Check the options in the Excess Type are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Excess Type dropdown
    Then I see the following options
   	| Data              |
   	| Per Claim         |
   	| Per Policy Year   |

    Scenario: Check the options in the Underwriting Types are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Underwriting Types dropdown
    Then I see the following options
   	| Data       |
   	| CPME       |
   	| FMU        |
   	| Moratorium |
