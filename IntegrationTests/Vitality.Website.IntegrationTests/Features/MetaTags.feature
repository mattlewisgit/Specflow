Feature: Meta Tags
	In order to test that the site pages contain meta tags
	As a Tester
	I want to check that each page has the appropriate content

	Scenario Outline: Common Meta Tags should appear on every page
	Given I am on the <initialpage>
	When I check the source
	Then I expect the common meta tags to be in the source

Examples:
	| initialpage                    |
	| /development/faq-leader        |
	| /development/accordion-content |
	| /development/benefit-leader    |


	Scenario Outline: Home meta tags should not appear on non-home pages
	Given I am on the <initialpage>
	When I check the source
	Then I do not expect the home meta tags to be in the source

Examples:
	| initialpage                    |
	| /development/faq-leader        |
	| /development/accordion-content |
	| /development/benefit-leader    |

	Scenario: Home meta tags should appear on the home page
	Given I am on the /home
	When I check the source
	Then I expect the home meta tags to be in the source
