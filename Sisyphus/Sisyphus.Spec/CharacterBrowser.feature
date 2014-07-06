Feature: CharacterBrowser
	In order to view a story from a character centric perspective or just explore a character
	As a consumer 
	I want to select and view a character to see its history

Background: 
	Given I have created a test database called "characterBrowserTest"	
	And I create the following places
		| name  | history  |
		| test1 | history1 |
	And I create the following characters
         | name | backstory | race | sex    | place     |
         | jim  | none      | foot | rarley | somewhere |
         | jim2 | none      | foot | rarley | somewhere |
         | jim3 | none      | foot | rarley | somewhere |
         | jim4 | none      | foot | rarley | somewhere |
	And I create the following event
		| name       | Description                          | Outcomes            | Places               |
		| testEvent  | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |
		| StoryStart | the start of the story               | started             | testPlace,testPlace2 |
	And I add the following characters to the event "testEvent"
		| name |
		| jim  |

Scenario: Open character browser and look at characters
	Given I open the view "CharacterBrowser"
	Then I expect the character browser to contain the following characters
         | name | backstory | race | sex    | place     |
         | jim  | none      | foot | rarley | somewhere |
		 | jim2 | none      | foot | rarley | somewhere |
         | jim3 | none      | foot | rarley | somewhere |
         | jim4 | none      | foot | rarley | somewhere | 

Scenario: Open a specific character from the browser
	Given I open the view "CharacterBrowser"
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
