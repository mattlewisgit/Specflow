Feature: QuoteResults
    In order to test that Vitality can join new Members
	As a prospective Member
	I want Quote Results to offer me differing levels of insurance cover

	@QuoteAndApply    
    Scenario: Amend Hospital Network cover to Consultant Select
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Hospital Network / Treatment Pathway to Consultant Select
    Then I see the price of the Standard offering change to £ 0 per Month

	@QuoteAndApply
    Scenario: When Hospital Network amended to Consultant Select, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Hospital Network / Treatment Pathway to Consultant Select
    Then I see this reflected across all the offerings

	@QuoteAndApply
    Scenario: When Out-Patient cover amended to Full Cover, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Out-Patient cover to Full Cover
    Then I see this reflected across all the offerings

	@QuoteAndApply
    Scenario: When Excess Amount Per Year amended to £ 250, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Excess Amount Per Year to £ 250
    Then I see this reflected across all the offerings

	@QuoteAndApply
    Scenario: When Excess Type amended to Per Policy Year, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Excess Type to Per Policy Year
    Then I see this reflected across all the offerings

    @QuoteAndApply
    Scenario: When Underwriting Types amended to Moratorium, all offerings are updated to this
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I Edit the Underwriting Types to Moratorium
    Then I see this reflected across all the offerings

	@QuoteAndApply
    Scenario: Check the options in the Hospital Network are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Hospital Network / Treatment Pathway dropdown
    Then I see the following options
   	| Data              |
	| Consultant Select |
    | Countrywide Plus  |
    | Local             |

    @QuoteAndApply
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

    @QuoteAndApply
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

    @QuoteAndApply
    Scenario: Check the options in the Excess Type are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Excess Type dropdown
    Then I see the following options
   	| Data              |
   	| Per Claim         |
   	| Per Policy Year   |

    @QuoteAndApply
    Scenario: Check the options in the Underwriting Types are as expected
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the options available within the Underwriting Types dropdown
    Then I see the following options
   	| Data       |
   	| CPME       |
   	| FMU        |
   	| Moratorium |

    @QuoteAndApply
    Scenario: Check CTA button labelling
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I look at the cover available within the Enhanced offering
    Then I see that the Underwriting Types cover option is set to Moratorium
    And I see that the Quote CTA button text is set to BUY ONLINE

	@QuoteAndApply
    Scenario: Quote Result - Check navigation to complete purchase page
    Given I am on presales /dev/quote-result
    And I see the Quote Results page feed load has completed
    When I click on the quote result BUY ONLINE button link
	Then I expect the presales /dev/quote-complete-purchase to open