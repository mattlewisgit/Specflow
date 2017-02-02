﻿Feature: SearchingContent
	In order to search for content
	As a searching user
	I want to be search for specific content 



	@SITDEPLOYISSUE
	Scenario Outline: Searching Presales Content
    Given I am on presales /dev/search
    When I search content <Data> 
	Then I expect search contents <Results> to be visible
	And then I click on the <Results> results page
	Then I expect the presales <URL> to open
	
	Examples:
	| Data		            | Results				| URL				   |
	| Cards Stacked		    | Cards Stacked Title	| /dev/cards-stacked/  |
	| Home				    | Home Hero Desc		| /dev/home-hero/	   |


	@SITDEPLOYISSUE
	Scenario Outline: Searching Advisers Content
    Given I am on advisers /dev/search
    When I search content <Data> 
	Then I expect search contents <Results> to be visible
	And then I click on the <Results> results page
	Then I expect the advisers <URL> to open

	Examples:
	| Data		            | Results							| URL				   |
	| Sales				    | Sales Literature Library Title	| /dev/sales-library/  |
	| Literature		    | Member Literature Library Desc	| /dev/member-library/ | 