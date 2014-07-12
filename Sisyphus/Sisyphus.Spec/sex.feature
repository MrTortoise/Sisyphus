Feature: Sex
	In order to have characters of different sexes to explain differing social interactinos
	As a writer 
	I want to be able to create sexes

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "placesTest"	
	And I create a user with email "writer@admin.com" with password "testtest"
	And I assign the following roles to user "writer@admin.com"
		| role   |
		| Admin  |
		| Writer |
		| Reader |
	And I log in with the user "writer@admin.com" and password "testtest"
	And I use the controller WriterHome
	And I have created the stories
	| name  | backStory                      |
	| test1 | ooo itS BACK STORY             |
	| test2 | COR HE THINKS ITS A WEAL STOWY |
	And I select the story "test1"

@mytag
Scenario: Create some sexes and verify they exist	
	When I create the following sexes
	| name   | BackStory      |
	| male   | they are manly |
	| femals | they are girly |
	Then I expect the following sexes to exist
	| name   | BackStory      |
	| male   | they are manly |
	| femals | they are girly |

Scenario: Create a sex and then edit it changing all info
	Given I create the following sexes
	| name   | BackStory      |
	| male   | they are manly |
	When I edit the sex "male" to have name "female" and description "not male"
	Then I expect the following sexes to exist
	| name   | BackStory |
	| female | not male  |  
