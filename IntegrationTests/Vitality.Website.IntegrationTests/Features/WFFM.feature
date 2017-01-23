Feature: WFFM
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	@SIT
	Scenario Outline: Submit Valid Web Form
    Given I am on advisers /dev/wffm
    When I enter the form details <First Name> <Last Name> <Other Name> <Email> <Phone> <Day> <MM> <YYYY> <DropList> <CheckBox>
	And I click on the Submit button
	Then I expect the web forms 'Thank you for filling in the form!' message to appear
	
	Examples:
	| First Name  | Last Name	| Other Name  | Email            | Phone			| Day | MM	| YYYY	| DropList  | CheckBox | 
	| Matt		  | Le Tissier	| Other		  | Test@Test.com	 | 02380999999		| 1	  | May	| 2016	| Magic	    | Yes	   | 


	@SIT
	Scenario Outline: Submit Invalid Web Form
    Given I am on advisers /dev/wffm
    When I enter the form details <First Name> <Last Name> <Other Name> <Email> <Phone> <Day> <MM> <YYYY> <DropList> <CheckBox>
	And I click on the Submit button
	Then I expect the web forms mandatory error message to appear
	
	Examples:
	| First Name  | Last Name	| Other Name  | Email            | Phone			| Day | MM	| YYYY	| DropList  | CheckBox | 
	| Matt		  | LeTissier	| Other		  | IncorrectEmail	 | 02380999999		| 1	  | May	| 2016	| Magic	    | Yes	   | 
	| Matt		  | LeTissier	| Other		  | Test@Test.com	 | IncorrectPhone	| 1	  | May	| 2016	| Magic	    | Yes	   | 
	|			  | LeTissier	| Other		  | Test@Test.com	 | 02380999999		| 1	  | May	| 2016	| Magic	    | Yes	   | 