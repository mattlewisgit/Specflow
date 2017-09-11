Feature: MessageBox
	In order to avoid silly mistakes
	As a Message Box User
	I want to be able to view messages

@Presales Messagebox SIT
Scenario: Check Message Box Error Message
	Given I am on presales /dev/message-box/
	Then I expect the Message Box Error Message to be displayed

@Presales Messagebox SIT
Scenario: Check Message Box Alert Message
	Given I am on presales /dev/message-box/
	Then I expect the Message Box Alert Message to be displayed

@Presales Messagebox SIT
Scenario: Check Message Box Expired Message
	Given I am on presales /dev/message-box/
	Then I expect the Message Box Expired Message to be displayed