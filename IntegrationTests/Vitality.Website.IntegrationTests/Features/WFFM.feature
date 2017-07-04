Feature: WFFM
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


	@SIT
	Scenario: Submit Valid Web Form
    Given I am on presales /dev/wffm
	And I have entered web forms section 0 and field 0 text box Matt
	And I have entered web forms section 0 and field 1 text box LeTissier
	And I have entered web forms section 0 and field 2 text box Other Names
	And I have entered web forms section 0 and field 3 text box Test@Test.com
	And I have entered web forms section 0 and field 4 text box 02380999999
	And I have entered web forms section 0 and field 5 date field 1 January 2016
	And I have entered web forms section 1 and field 0 dropdown list Magic
	And I have entered web forms section 1 and field 1 check box Yes
	When I click on webform Submit button 
	Then I expect the web forms Thank you for filling in the form! message to appear

	@SIT
	Scenario: Invalid Web Form - Email address
    Given I am on presales /dev/wffm
	And I have entered web forms section 0 and field 0 text box Matt
	And I have entered web forms section 0 and field 1 text box LeTissier
	And I have entered web forms section 0 and field 2 text box Other Names
	And I have entered web forms section 0 and field 3 text box IncorrectEmail
	And I have entered web forms section 0 and field 4 text box 02380999999
	And I have entered web forms section 0 and field 5 date field 1 January 2016
	And I have entered web forms section 1 and field 0 dropdown list Magic
	And I have entered web forms section 1 and field 1 check box Yes
	When I click on webform Submit button 
	Then I expect the web forms The Email Address field contains an invalid email address. message to appear

	@SIT
	Scenario: Invalid Web Form - Phone number
    Given I am on presales /dev/wffm
	And I have entered web forms section 0 and field 0 text box Matt
	And I have entered web forms section 0 and field 1 text box LeTissier
	And I have entered web forms section 0 and field 2 text box Other Names
	And I have entered web forms section 0 and field 3 text box Test@Test.com
	And I have entered web forms section 0 and field 4 text box IncorrectPhone
	And I have entered web forms section 0 and field 5 date field 1 January 2016
	And I have entered web forms section 1 and field 0 dropdown list Magic
	And I have entered web forms section 1 and field 1 check box Yes
	When I click on webform Submit button 
	Then I expect the web forms The value of the Phone number field is not valid. message to appear

	@SIT
	Scenario: Invalid Web Form - First name
    Given I am on presales /dev/wffm
	And I have entered web forms section 0 and field 1 text box LeTissier
	And I have entered web forms section 0 and field 2 text box Other Names
	And I have entered web forms section 0 and field 3 text box Test@Test.com
	And I have entered web forms section 0 and field 4 text box 02380999999
	And I have entered web forms section 0 and field 5 date field 1 January 2016
	And I have entered web forms section 1 and field 0 dropdown list Magic
	And I have entered web forms section 1 and field 1 check box Yes
	When I click on webform Submit button 
	Then I expect the web forms The First name field is required. message to appear

	@SIT
	Scenario: Web Form single line tool tips - Presales
    Given I am on presales /dev/wffm
	And I have entered web forms section 0 and field 0 text box Matt
	When I click on field First name tool tips
	Then I expect Enter First Name tool tips to be displayed

	@SIT
	Scenario: Web Form Date tool tips - Presales
    Given I am on presales /dev/wffm
	And I have entered web forms section 0 and field 5 date field 1 January 2016
	When I click on field Submission Date tool tips
	Then I expect Enter Submission Date tool tips to be displayed

	@SIT
	Scenario: Web Form Phone Number tool tips - Advisers
    Given I am on advisers /dev/wffm
	And I have entered web forms section 0 and field 4 text box 02380999999
	When I click on field Phone number tool tips
	Then I expect Enter Phone Number tool tips to be displayed

	@SIT
	Scenario: Web Form Date Check box - Advisers
    Given I am on advisers /dev/wffm
	And I have entered web forms section 1 and field 0 dropdown list Magic
	When I click on field How did you find us? tool tips
	Then I expect Select How To Find Us tool tips to be displayed
