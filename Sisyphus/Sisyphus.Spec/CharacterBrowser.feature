Feature: CharacterBrowser
	In order to view a story from a character centric perspective or just explore a character
	As a consumer 
	I want to select and view a character to see its history

Background: 
	Given I have set up configuration to use testConfig
	And I set the config key "SessionTimeout" to "15"
	And I set ContextWrapper To use TestContextWrapper 
	And I set the user Identity to "writer@admin.com"
	And I have set SisyphusDateTime to TestDateTime
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
	And I have created a test database called "characterBrowserTest"	
	And I create the following places
		| name  | history  |
		| test1 | history1 |
	And I create the following characters
        | name | backstory | race | sex      | place     |
        | jim  | none      | foot | rarley   | somewhere |
        | jim2 | none      | foot | bannanas | somewhere |
        | jim3 | none      | foot | rarley   | somewhere |
        | jim4 | none      | foot | bannanas | somewhere |
	And I create the following events
		| name       | Description                          | Outcomes            | Places               | Duration | Characters | Event Type |
		| testEvent  | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 3        | jim,jim3   | story      |
		| testEvent  | a test event to show how things work | passed, failed, war | testPlace,testPlace2 | 4        | jim,jim3   | story      |
		| StoryStart | the start of the story               | started             | testPlace,testPlace2 | 5        | jim,jim3   | story      |
	And I add the following characters to the event "testEvent"
		| name |
		| jim  |
	And I create the following races
		| name | backstory        |
		| foot | bulling you rleg |

Scenario: Open character browser and look at characters
	Given I open the view Character Browser
	Then I expect the character browser to contain the following characters
         | name | backstory | race | sex    |
         | jim  | none      | foot | rarley |
		 | jim2 | none      | foot | rarley |
         | jim3 | none      | foot | rarley |
         | jim4 | none      | foot | rarley | 

Scenario: Open a specific character from the browser
	Given I open the view Character Browser
	When I select the character "jim" in the character browser
	Then I expect to get the "CharacterInformation" view
	And I expect the chatacter "jim" to be the CharacterInformation views subject

Scenario: View a specific characters involvement in events
	Given I have chosen to start a story 
	And I open the view "CharacterBrowser"
	And I select the character "jim" in the character browser
	When I select view events in the character browser
	Then The resulting RedirectToRouteResult should be to controller "CharacterEventBrowser" action "Index"
	And I expect the events in the events browser to be
		| name      |
		| testEvent |

Scenario: Add characters to a following list
	Given I have chosen to start a story 
	And I open the view "CharacterBrowser"
	When I select the following characters to be followed
		| name |
		| jim  |
		| jim2 |
	Then I expect the following characters to be followed
		| name |
		| jim  |
		| jim2 |
