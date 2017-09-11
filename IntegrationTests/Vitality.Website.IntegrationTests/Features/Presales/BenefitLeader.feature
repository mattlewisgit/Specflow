Feature: BenefitLeader
	In order to avoid silly mistakes
	As a accordion user
	I want to be expand and retract the accordion


@Presales BenefitLeader SIT
Scenario: Check Benefit Leader in mobile view
	Given I am on presales /dev/benefit-leader
	When I resize to mobile view
	Then I expect the Benefit Leader Left alignment CSS values to appear
	And I expect the Benefit Leader Right alignment CSS values to appear

@Presales BenefitLeader SIT
Scenario: Check Benefit Leader in full size view
	Given I am on presales /dev/benefit-leader
	When I resize to full-screen view
	Then I expect the Benefit Leader Left alignment CSS values to appear
	And I expect the Benefit Leader Right alignment CSS values to appear

@Presales BenefitLeader SIT
Scenario: Check Benefit Leader button links internally
	Given I am on presales /dev/benefit-leader
	When I click on benefit leader Left alignment button Explore Vitality GP
	Then I expect the presales / to open

@Presales BenefitLeader
Scenario: Check Benefit Leader button links externally
	Given I am on presales /dev/benefit-leader
	When I click on benefit leader Right alignment button Explore Vitality GP
	Then I expect the presales / to open

