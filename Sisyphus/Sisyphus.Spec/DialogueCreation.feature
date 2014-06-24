Feature: DialogueCreation
	In order to advance characters development and the story
	As a writer
	I want to be able to create diaglogue between 2 characters

	Background: 
	Given I have created a test database called "storyTest"	
	And I create the following places
		| name  | history  |
		| test1 | history1 |
	And I create the following characters
         | name | backstory | race | sex    | place     |
         | jim  | none      | foot | rarley | somewhere |
         | jim2 | none      | foot | rarley | somewhere |
	And I create the following events
		| name       | Description                          | Outcomes            | Places               |
		| testEvent  | a test event to show how things work | passed, failed, war | testPlace,testPlace2 |
		| StoryStart | the start of the story               | started             | testPlace,testPlace2 |
	And I add the following characters to the event "testEvent"
		| name |
		| jim  |
		| jim2 |
	And I create a time system with the following members
		| bit | bitValue | bitText |
		| 0   | 0        | 0       |
		| 0   | 1        | 1       |
		| 0   | 2        | 2       |
		| 0   | 3        | 3       |
		| 0   | 4        | 4       |
		| 0   | 5        | 5       |	
		 
Scenario: Create dialogue between 2 characters
	Given I open the view "DialogueCreation"
	


