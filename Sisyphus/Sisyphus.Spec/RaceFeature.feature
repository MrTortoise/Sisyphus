Feature: RaceFeature
	In order to have characters in different Races
	As a writer adn reader
	I want to be abke to select and read about them

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have created a test database called "placesTest"	
	And I create a user with email "writer@admin.com" with password "testtest"
	And I assign the following roles to user "writer@admin.com"
		| role   |
		| Admin  |
		| Writer |
		| Reader |
	And I log in with the user "writer@admin.com" and password "testtest"
	And I have created the stories
	| name  | backStory                      |
	| test1 | ooo itS BACK STORY             |
	| test2 | COR HE THINKS ITS A WEAL STOWY |
	And I select the story "test1"

@mytag
Scenario: Create some races and verify they exist	
	When I create the following races
	| name  | BackStory                    |
	| human | they are shits               |
	| slave | they are allegedly not human |
	Then I expect the following races to exist
	| name  | BackStory                    |
	| human | they are shits               |
	| slave | they are allegedly not human |
