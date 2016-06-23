Feature: Meta Tags
	In order to test that the site pages contain meta tags
	As a Tester
	I want to check that each page has the appropriate content



	Scenario Outline: Test Tags following Deployment
	Given I am on the <initialpage>
	When I check the source
	Then I expect the <tag> to be in the source
	
Examples:
	| initialpage        | tag        |
	| /quote-footer      | commonTags |
	| /accordion-content | commonTags |
	| /benefit-leader    | commonTags |


