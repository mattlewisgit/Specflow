Feature: LiteratureLibrary
	In order to download a sales literature document
	As an advisers user
	I want to be able to download sales literature documents


	@SIT
	Scenario Outline: Sales Literature - Searching
    Given I am on the <initialpage>
    When I search for <Literature Type> document
	Then I expect the <Literature Type> document to be visible
	And I expect the download and email  buttons to be visible

Examples:
	| initialpage           | Literature Type          |
	| /dev/sales-library    | Business healthcare aid  | 


	@SIT
	Scenario Outline: Sales Literature - Choosing
    Given I am on the <initialpage>
    When I choose Literature Type <Literature Type>
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email  buttons to be visible

Examples:
	| initialpage           | Literature Type         | Available Literature    |
	| /dev/sales-library    | Business and Corporate  | Business healthcare aid | 



	@SIT
	Scenario Outline: Member Literature - Searching
	Given I am on the <initialpage>
	And I enter plan start date <DD> <MM> <YYYY>
	When click on the submit button
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email  buttons to be visible

Examples:
	| initialpage           | DD | MM | YYYY | Available Literature    |
	| /dev/member-library   | 01 | 12 | 2016 | Business healthcare aid |

	@SIT
	Scenario Outline: Member Literature - Choosing
    Given I am on the <initialpage>
    When I choose Literature Type <Literature Type>
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email  buttons to be visible

Examples:
	| initialpage           | Literature Type         | Available Literature    |
	| /dev/member-library   | Business and Corporate  | Business healthcare aid | 
