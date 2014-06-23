Feature: TheStory
	In order to consume sisyphus I need a guiding frameork that will take me through it
	As a consumer
	I want to be able to traverse the time, decision space, locality and characters of Sisyphus

	Background: 
	Given I have created a test database called "storyTest"	
	And I create the following places
		| name  | history  |
		| test1 | history1 |
	And I create the following characters
         | name | backstory | race | sex    | place     |
         | jim  | none      | foot | rarley | somewhere |
	And I create the sollowing events
		| name       | Description                          | Outcomes            | Places               |
		| testEvent  | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |
		| StoryStart | the start of the story               | started             | testPlace,testPlace2 |
	And I add the following characters to the event "testEvent"
		| name |
		| jim  |
	And I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | 0       |
		| 0   | 1        | 1       |
		| 0   | 2        | 2       |
		| 0   | 3        | 3       |
		| 0   | 4        | 4       |
		| 0   | 5        | 5       |	
	And I have set the world narrative to "this is the world backstory"

Scenario: Start a path in the story
	Given I have created a test database called "placesTest"	
	When I start the starting point process off	
	Then I expect to be on the "BackStory" view

Scenario: Select one or more characters to follow and start a story
	Given I have chosen to start a story 
	And I open the view "CharacterBrowser"
	And I Choose to follow the following characters in the character browser
		| name |
		| jim  |
	When I select StartStory
	Then I expect to get the "StoryNavigator" view

Scenario: Ask storyNavigator for next set to interactions
	Given I set the time to
         | bit | bitvalue |
         | 0   | 0        |
	And I open the view "StoryNavigator"
	When I step the story 
	Then I expect the current time value to be
        | bit | bitvalue |
        |     |          |


