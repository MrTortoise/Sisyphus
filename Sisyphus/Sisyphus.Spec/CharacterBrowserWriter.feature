Feature: CharacterBrowserWriter
	In order to view a story from a character centric perspective or just explore a character
	As a writer 
	I want to Create and edit characters

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
	And I have set the date to year "2014" Month "7" Day "20" hour "19" minute "24" second "12" millisecond "123"
	And I have created a test database called "characterBrowserTest"	
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
	And I create the following places
		| name  | history  |
		| test1 | history1 |
	And I create the following races
		| name | backstory        |
		| foot | bulling you rleg |
	And I create the following sexes
		| name     | description |
		| rarley   | nto often   |
		| bannanas | yellowZ     |
	And I create the following characters
		| name | backstory | race | sex      | place     |
		| jim  | none      | foot | rarley   | somewhere |
		| jim2 | none      | foot | bannanas | somewhere |
		| jim3 | none      | foot | rarley   | somewhere |
		| jim4 | none      | foot | bannanas | somewhere |

Scenario: Open character browser and look at characters
	When I open the view Character Browser
	Then I expect the character browser to contain the following characters
		 | name | backstory | race | sex      |
		 | jim  | none      | foot | rarley   |
		 | jim2 | none      | foot | bannanas |
		 | jim3 | none      | foot | rarley   |
		 | jim4 | none      | foot | bannanas |

Scenario: Open a specific character from the browser
	Given I open the view Character Browser
	When I select the character "jim" in the character browser	
	Then I expect the chatacter "jim" to be the Character Details views subject

Scenario: Open a character in the editor
	Given I open the character editor with "jim" selected
	Then I expect the following character to be int he editor
		| name | backstory | race | sex    |
		| jim  | none      | foot | rarley |
	And I expect the races to be the following
		| name | backstory        |
		| foot | bulling you rleg |
	And I expect the sexes to the be the following
		| name     | description |
		| rarley   | nto often   |
		| bannanas | yellowZ     |

Scenario: Edit a character, save and confirm changtes
	Given I open the character editor with "jim" selected
	When I save that character with info name "test" backstory "test" raceid "1" and sexid "2"
	Then I expect the following characters to exist
         | name | backstory | race | sex      |
         | test | test      | foot | bannanas |
