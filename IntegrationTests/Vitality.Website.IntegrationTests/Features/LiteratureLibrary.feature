Feature: LiteratureLibrary
	In order to download a sales literature document
	As an advisers user
	I want to be able to download sales literature documents


	### Advisers Literature Library Tests

	@SITDEPLOYISSUE
	Scenario Outline: Advisers - Sales Literature - Searching
    Given I am on advisers <initialpage>
    When I search for <Literature Type> document
	Then I expect the <Literature Type> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | Literature Type          |
	| /dev/sales-library    | Business healthcare aid  | 


	@SITDEPLOYISSUE
	Scenario Outline: Advisers - Sales Literature - Choosing
    Given I am on advisers <initialpage>
    When I choose Literature Type <Literature Type>
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | Literature Type         | Available Literature    |
	| /dev/sales-library    | Business and Corporate  | Business healthcare aid | 


	@SITDEPLOYISSUE
	Scenario Outline: Advisers - Member Literature - Searching
    Given I am on advisers <initialpage>
	And I enter plan start date <DD> <MM> <YYYY>
	When click on the submit button
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | DD | MM | YYYY | Available Literature    |
	| /dev/member-library   | 01 | 12 | 2016 | Business healthcare aid |


	@SITDEPLOYISSUE
	Scenario Outline: Advisers - Member Literature - Choosing
    Given I am on advisers <initialpage>
    When I choose Literature Type <Literature Type>
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | Literature Type         | Available Literature    |
	| /dev/member-library   | Business and Corporate  | Business healthcare aid | 




	### Presales Literature Library Tests

		@SITDEPLOYISSUE
	Scenario Outline: Presales - Sales Literature - Searching
    Given I am on presales <initialpage>
    When I search for <Literature Type> document
	Then I expect the <Literature Type> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | Literature Type          |
	| /dev/sales-library    | Cinema				   | 


	@SITDEPLOYISSUE
	Scenario Outline: Presales - Sales Literature - Choosing
    Given I am on presales <initialpage>
    When I choose Literature Type <Literature Type>
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | Literature Type         | Available Literature    |
	| /dev/sales-library    | Understand your health  | Fitness assesment	    | 




	@SITDEPLOYISSUE
	Scenario Outline: Presales - Member Literature - Searching
    Given I am on presales <initialpage>
	And I enter plan start date <DD> <MM> <YYYY>
	When click on the submit button
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | DD | MM | YYYY | Available Literature    |
	| /dev/member-library   | 05 | 04 | 2017 | Eurostar				   |


	@SITDEPLOYISSUE
	Scenario Outline: Presales - Member Literature - Choosing
    Given I am on presales <initialpage>
    When I choose Literature Type <Literature Type>
	And I select on <Available Literature> Literature
	Then I expect the <Available Literature> document to be visible
	And I expect the download and email buttons to be visible

Examples:
	| initialpage           | Literature Type				 | Available Literature |
	| /dev/member-library   | Rewards to keep you motivated  | Apple Watch			| 


	@SITDEPLOYISSUE
	Scenario: Check Member literature card button works
    Given I am on presales /dev/member-library
	When I click on literature library card snippet Sales Literature link
	Then I expect the presales /dev/sales-library/ to open

	@SITDEPLOYISSUE
	Scenario: Check Sales literature card button works
    Given I am on presales /dev/sales-library
	When I click on literature library card snippet Member Literature link
	Then I expect the presales /dev/member-library/ to open