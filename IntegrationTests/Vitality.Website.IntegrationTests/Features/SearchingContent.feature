Feature: SearchingContent
	In order to search for content
	As a searching user
	I want to be search for specific content 



	@SIT
	Scenario Outline: Searching Presales Content
    Given I am on presales /dev/search
    When I search for <Data> 
	Then I expect the <Results> to be visible
	And then I click on the <Results> results page
	Then I expect the presales /dev/cards-stacked/ to open
	
	Examples:
	| Data		            | Results				|
	| Cards Stacked		    | Cards Stacked Title	| 


	@SIT
	Scenario Outline: Searching Advisers Content
    Given I am on advisers /dev/search
    When I search for <Data> 
	Then I expect the <Results> to be visible
	And then I click on the <Results> results page
	Then I expect the advisers '/dev/sales-library/' to open

	Examples:
	| Data		            | Results							|
	| Sales				    | Sales Literature Library Title	| 