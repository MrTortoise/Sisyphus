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
	And I create the following events
		| name       | Description                          | Outcomes            | Places    | Duration | Characters | Event Type |
		| testEvent  | a test event to show how things work |                     | testPlace | 3        | jim,jim3   | story      |
		| testEvent2 | another test                         |                     | testPlace | 3        | jim,jim4   | story      |
		| testEvent3 | decision event                       | passed, failed, war | testPlace | 3        | jim,jim4   | decision   |
		| testEvent4 | decision event                       | passed, failed, war | testPlace | 3        | jim,jim4   | decision   |
		| testEvent5 | yet another test                     |                     | testPlace | 3        | jim,jim4   | story      |
	And I chain the following events
		| parent     | outcome | child      |
		| testEvent  |         | testEvent3 |
		| testEvent3 | passed  | testEvent2 |
		| testEvent2 |         | testEvent4 |
		| testEvent3 | failed  | testEvent5 |
	And I add to the event "testEvent3" from perspective of "jim" the following Narrative 
		| eventStepId | narrative           |
		| 0           | look its some story |
	And I add to the event "testEvent3" from perspective of "jim" the following lines of dialogue 
		| eventStepId | dialog                                         |
		| 1           | Jim says "Its awfully lonley in this scenario" |
	And I add to the event "testEvent3" from perspective of "jim" the following Narrative 
		| eventStepId | narrative                |
		| 2           | look its some more story |
	And I add to the event "testEvent5" from perspective of "jim" the following Narrative 
		| eventStepId | narrative                  |
		| 0           | boom we made it a long way |
	And I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | 0       |
		| 0   | 1        | 1       |
		| 0   | 2        | 2       |
		| 0   | 3        | 3       |
		| 0   | 4        | 4       |
		| 0   | 5        | 5       |	
		| 0   | 6        | 6       |	
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
        | 0   | 3        |
	And I expect the current event to be "testEvent3"
	And Then I expect "jim" to have the following story
		| eventStepId | story lines                                    |
		| 0           | look its some story                            |
		| 1           | Jim says "Its awfully lonley in this scenario" |
		| 2           | look its some more story                       |
	And I expect "jim" to have the following outcomes
		| outcome |
		| failed  |
		| passed  |
		| war     |

Scenario: Get to first decision make decision wait 3 verify at next event
	Given I set the time to
         | bit | bitvalue |
         | 0   | 0        |
	And I open the view "StoryNavigator"
	And I step the story 
	When I choose the outcome "failed"
	Then I expect the current time value to be
         | bit | bitvalue |
         | 0   | 6        |  
	And I expect the current event to be "testEvent5"
	And I expect "jim" to have the following story
         | eventStepId | story lines                |
         | 0           | Boom we made it a long way |
	


