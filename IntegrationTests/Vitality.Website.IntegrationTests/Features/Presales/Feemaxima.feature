Feature: Feemaxima
	In order to search in feemaxima
	As an presales user
	I want to be able to search for feemaimxa rates


	@ignore
	Scenario: Feemaxima Searching for code
    Given I am on presales /dev/feemaxima/
    When I search for feemaxima G1900 data
	Then I expect the feemaxima table to contain G1900 search results
	And I click on the feemaxima Back button
	Then I expect the feemaxima home table to be displayed

	@ignore
	Scenario: Feemaxima Searching for Chapters - Breast
    Given I am on presales /dev/feemaxima/
    When I search for feemaxima Breast data
	Then I expect the feemaxima table to contain B3220 search results
	And I expect the feemaxima table to contain Contact us at cons_helpline@vitality.co.uk search results
	And I click on the feemaxima Back button
	Then I expect the feemaxima home table to be displayed

	@ignore
	Scenario: Feemaxima Clicking - Chapter 1, Chapter 1.1
    Given I am on presales /dev/feemaxima/
	When I click on feemaxima Chapter 1 and select on subcolumn Chapter 1.1
	Then I expect the feemaxima table to contain T2710 search results
	And I expect the feemaxima table to contain Contact us at cons_helpline@vitality.co.uk search results
	And I click on the feemaxima Back button
	Then I expect the feemaxima home table to be displayed

	@ignore
	Scenario: Feemaxima Clicking - Chapter 2, Elbow
    Given I am on presales /dev/feemaxima/
	When I click on feemaxima Chapter 2 and select on subcolumn Elbow
	Then I expect the feemaxima table to contain W5502 search results
	And I click on the feemaxima Back button
	Then I expect the feemaxima home table to be displayed

	@ignore
	Scenario: Feemaxima Clicking - Abdomen (ExcL. Urinary & Reproductive Organs), Chapter 1.7
    Given I am on presales /dev/feemaxima/
	When I click on feemaxima Abdomen (ExcL. Urinary & Reproductive Organs) and select on subcolumn Chapter 1.7
	Then I expect the feemaxima table to contain H3590 search results
	And I expect the feemaxima table to contain £ search results
	And I expect the feemaxima table to contain Anaesthetist Alternate text search results
	And I click on the feemaxima Back button
	Then I expect the feemaxima home table to be displayed

	@ignore
	Scenario: Feemaxima Clicking - Breast, reconstruction of Breast
    Given I am on presales /dev/feemaxima/
	When I click on feemaxima Breast and select on subcolumn Reconstruction of Breast
	Then I expect the feemaxima table to contain B3014 search results
	And I click on the feemaxima Back button
	Then I expect the feemaxima home table to be displayed