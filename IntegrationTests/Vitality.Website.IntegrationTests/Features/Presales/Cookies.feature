﻿Feature: Cookies
	In order to avoid silly mistakes
	As a cookies user browsing the website
	I want to be able to accept the cookies


@Presales Cookies SIT
Scenario: Cookies appears on presales after clearing cache
	Given I am on presales /
	And I have cleared the browser cache
	Then I expect cookies pop up to be visible

@Presales Cookies SIT
Scenario: Accepting cookies on presales closes down the cookie message
	Given I am on presales /
	And I have cleared the browser cache
	When I click on close cookies
	Then I expect cookies pop up to be hidden


Scenario: Cookies appears on advisers after clearing cache
	Given I am on advisers /
	And I have cleared the browser cache
	Then I expect cookies pop up to be visible


Scenario: Accepting cookies on advisers closes down the cookie message
	Given I am on advisers /
	And I have cleared the browser cache
	When I click on close cookies
	Then I expect cookies pop up to be hidden