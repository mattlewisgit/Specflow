﻿Feature: RichText
	In order to avoid silly mistakes
	As a rich text dialog box user
	I want to be able to view the rich text dialog box

	@SIT
Scenario: Check Rich Text Dialog Box in full size view
	Given I am on presales /dev/content
	When I click on the rich text dialog This is the Dialog Link link
	Then I expect the dialog pop up box to appear
	And I click on the close dialog box

	@SIT
Scenario: Check Rich Text Dialog Box in mobile view
	Given I am on presales /dev/content
    And I resize to mobile view
	When I click on the rich text dialog This is the Dialog Link link
	Then I expect the dialog pop up box to appear
	And I click on the close dialog box