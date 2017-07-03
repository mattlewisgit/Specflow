Feature: WFFM
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	@SIT
	Scenario Outline: Submit Valid Web Form
    Given I am on advisers /dev/wffm
	When I enter the form details <Firstname> <Lastname> <Othername> <Email> <Phone> <Day> <Month> <Year> <DropList>
	And I click on webform Submit button 
	Then I expect the web forms 'Thank you for filling in the form!' message to appear
	
	Examples:
	| Firstname  | Lastname		| Othername   | Email            | Phone			| Day | Month	| Year	| DropList  |
	| Matt		 | LeTissier	| Other		  | Test@Test.com	 | 02380999999		| 1	  | May		| 2016	| Magic	    |


	@SIT
	Scenario Outline: Submit Invalid Web Form
    Given I am on advisers /dev/wffm
	When I enter the form details <Firstname> <Lastname> <Othername> <Email> <Phone> <Day> <Month> <Year> <DropList>
	And I click on webform Submit button 
	Then I expect the web forms <ErrorMessage> error message to appear
	
	Examples:
	| Firstname   | Lastname	| Othername   | Email            | Phone			| Day | Month	| Year	| DropList  | ErrorMessage												| 
	| Matt		  | LeTissier	| Other		  | IncorrectEmail	 | 02380999999		| 1	  | May		| 2016	| Magic	    | The Email Address field contains an invalid email address.|
	| Matt		  | LeTissier	| Other		  | Test@Test.com	 | IncorrectPhone	| 1	  | May		| 2016	| Magic	    | The value of the Phone number field is not valid.			|
	|			  | LeTissier	| Other		  | Test@Test.com	 | 02380999999		| 1	  | May		| 2016	| Magic	    | The First name field is required.							|


	@SIT
	Scenario: Web Form single line tool tips - Presales
    Given I am on presales /dev/wffm
	When I click on field First name tool tips
	Then I expect Enter First Name tool tips to be displayed

	@SIT
	Scenario: Web Form Date tool tips - Presales
    Given I am on presales /dev/wffm
	When I click on field Submission Date tool tips
	Then I expect Enter Submission Date tool tips to be displayed

	@SIT
	Scenario: Web Form Phone Number tool tips - Advisers
    Given I am on advisers /dev/wffm
	When I click on field Phone number tool tips
	Then I expect Enter Phone Number tool tips to be displayed

	@SIT
	Scenario: Web Form Date Check box - Advisers
    Given I am on advisers /dev/wffm
	When I click on field How did you find us? tool tips
	Then I expect Select How To Find Us tool tips to be displayed
