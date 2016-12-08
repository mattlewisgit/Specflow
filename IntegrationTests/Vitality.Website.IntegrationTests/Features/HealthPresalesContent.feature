Feature: Health Presales Content
    In order to test that the Vitality Health Presales site is correct
    As a Tester
    I want to perform basic navigation and content tests

    @ignore
    Scenario: UserJourney 1: Health Insurance Menu Get a Quote
    Given I am on the /
    When I hover over Health Insurance and click on Get a quote
    Then I see the https://join.pruhealth.co.uk/ page

    @ignore
    Scenario: UserJourney 2: Health Insurance Menu Health insurance quote
    Given I am on the /
    When I hover over Health Insurance and click on Health insurance quote
    Then I see the https://join.pruhealth.co.uk/ page

    @ignore
    Scenario: UserJourney 3: Navigate to Core Cover, Awards page
    Given I am on the /
    When I hover over Health Insurance and click on Core Cover
    And I click on the Learn more page link
    Then I expect the /about/awards/ to open

    @ignore
    Scenario: UserJourney 4: Navigate to Cover options, Get a quote
    Given I am on the /
    When I hover over Health Insurance and click on Cover Options
    And I click on the Get a quote page link
    Then I see the https://join.pruhealth.co.uk/ page

    @ignore
    Scenario: UserJourney 5: Navigate to Vitality GP, Hospital page
    Given I am on the /
    When I hover over Health Insurance and click on Vitality GP
    And I click on the Learn more page link
    Then I expect the /health-insurance/hospitals/ to open

    @ignore
    Scenario: UserJourney 6: Navigate to Vitality GP, Get a Quote
    Given I am on the /
    When I hover over Health Insurance and click on Vitality GP
    And I click on the Get a quote page link
    Then I see the https://join.pruhealth.co.uk/ page

    @ignore
    Scenario: UserJourney 7: Switch to Us and get a quote
    Given I am on the /
    When I hover over Health Insurance and click on Switch to Vitality
    And I click on the Get a quote page link
    Then I see the https://join.pruhealth.co.uk/ page

    @ignore
    Scenario: UserJourney 8: Switch to Us, In Patient Care page
    Given I am on the /
    When I hover over Health Insurance and click on Switch to Vitality
    And I click on the Read more page link
    Then I expect the /health-insurance/core-cover/in-patient/#anchor_1470237471794 to open
